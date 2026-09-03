import React, { useCallback, useEffect, useRef, useState } from 'react';
import { View, Text, StyleSheet, Pressable, ScrollView, TextInput, Image, Animated, Easing } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import * as ImagePicker from 'expo-image-picker';
import * as ImageManipulator from 'expo-image-manipulator';
import * as DocumentPicker from 'expo-document-picker';
import { Audio } from 'expo-av';
import { squadColors, squadFonts } from '../theme/squadTheme';
import AssembleCreature, { ASSEMBLE_BODY_COLORS, ASSEMBLE_DEFAULT } from '../components/AssembleCreature';

// CREATE A SQUISHY — the creator flow, ported from the decoded
// "ASMR Creature Squash Game.html". Name, then a picture (upload a photo or
// assemble one from parts), an optional short squish sound.
//
// On submit this hands a payload to `onCreated` (App): for a photo it uploads
// the resized JPEG to Storage and creates a `status: 'pending'` doc — the
// `generateCustomModel` Cloud Function then runs Tripo image-to-3D in the
// background and the MY CREATURES card tracks its progress. Assemble-path
// creatures are born ready and play as their 2D art.

const MAX_AUDIO_CHARS = 700000; // ~500 KB of base64 — keeps the Firestore doc small

const ASSEMBLE_ROWS = [
  { key: 'body', label: 'BODY', options: [['blob', 'Blob'], ['round', 'Round'], ['tall', 'Tall'], ['wide', 'Wide']] },
  { key: 'eyes', label: 'EYES', options: [['round', 'Round'], ['wide', 'Wide'], ['slit', 'Sleepy'], ['star', 'Star']] },
  { key: 'mouth', label: 'MOUTH', options: [['smile', 'Smile'], ['open', 'Open'], ['flat', 'Flat'], ['fang', 'Fang']] },
  { key: 'extra', label: 'EXTRA', options: [['none', 'None'], ['antenna', 'Antenna'], ['ears', 'Ears'], ['horns', 'Horns']] },
];

export default function CreateScreen({ onBack, onCreated }) {
  const insets = useSafeAreaInsets();

  const [name, setName] = useState('');
  const [source, setSource] = useState('upload'); // 'upload' | 'assemble'
  const [imageUri, setImageUri] = useState(null); // resized local JPEG
  const [imageError, setImageError] = useState(null);
  const [build, setBuild] = useState(ASSEMBLE_DEFAULT);
  const [audio, setAudio] = useState(null); // { uri, name, dataUrl }
  const [audioError, setAudioError] = useState(null);

  const [converting, setConverting] = useState(false);
  const [submitError, setSubmitError] = useState(null);
  const previewSoundRef = useRef(null);

  useEffect(
    () => () => {
      previewSoundRef.current?.unloadAsync?.().catch(() => {});
    },
    []
  );

  const scan = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!converting) return undefined;
    scan.setValue(0);
    const loop = Animated.loop(Animated.timing(scan, { toValue: 1, duration: 1600, easing: Easing.linear, useNativeDriver: true }));
    loop.start();
    return () => loop.stop();
  }, [converting, scan]);

  const pickImage = useCallback(async () => {
    setImageError(null);
    const perm = await ImagePicker.requestMediaLibraryPermissionsAsync();
    if (!perm.granted) {
      setImageError('Photo access is off — enable it in Settings to upload.');
      return;
    }
    const res = await ImagePicker.launchImageLibraryAsync({
      mediaTypes: ImagePicker.MediaTypeOptions.Images,
      allowsEditing: true,
      aspect: [1, 1],
      quality: 1,
    });
    if (res.canceled || !res.assets?.length) return;
    try {
      // Downscale to ~1024px for Tripo (plenty of detail, keeps the upload
      // small). No base64 — the file is uploaded to Storage on submit.
      const out = await ImageManipulator.manipulateAsync(
        res.assets[0].uri,
        [{ resize: { width: 1024 } }],
        { compress: 0.85, format: ImageManipulator.SaveFormat.JPEG }
      );
      setImageUri(out.uri);
    } catch (e) {
      setImageError('Could not process that image — try another.');
    }
  }, []);

  const pickAudio = useCallback(async () => {
    setAudioError(null);
    const res = await DocumentPicker.getDocumentAsync({ type: 'audio/*', copyToCacheDirectory: true });
    if (res.canceled || !res.assets?.length) return;
    const file = res.assets[0];
    if (file.size && file.size > 2 * 1024 * 1024) {
      setAudioError('That track is over 2 MB.');
      return;
    }
    // duration check
    try {
      const { sound } = await Audio.Sound.createAsync({ uri: file.uri }, { shouldPlay: false });
      const status = await sound.getStatusAsync();
      await sound.unloadAsync();
      if (status.isLoaded && status.durationMillis && status.durationMillis > 3200) {
        setAudioError(`Keep it under 3 seconds (yours is ${(status.durationMillis / 1000).toFixed(1)} s).`);
        return;
      }
    } catch (e) {
      setAudioError('Could not read that audio file.');
      return;
    }
    // base64 for persistence
    try {
      const blob = await (await fetch(file.uri)).blob();
      const dataUrl = await new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.onload = () => resolve(reader.result);
        reader.onerror = reject;
        reader.readAsDataURL(blob);
      });
      if (typeof dataUrl === 'string' && dataUrl.length > MAX_AUDIO_CHARS) {
        setAudioError('That clip is too large to save — try a shorter one.');
        return;
      }
      setAudio({ uri: file.uri, name: file.name, dataUrl });
    } catch (e) {
      setAudioError('Could not read that audio file.');
    }
  }, []);

  const previewAudio = useCallback(async () => {
    if (!audio?.uri) return;
    try {
      previewSoundRef.current?.unloadAsync?.().catch(() => {});
      const { sound } = await Audio.Sound.createAsync({ uri: audio.uri }, { shouldPlay: true });
      previewSoundRef.current = sound;
    } catch (e) {
      // no-op
    }
  }, [audio]);

  const nameOk = !!name.trim();
  const imgOk = source === 'assemble' || !!imageUri;
  const ready = nameOk && imgOk && !converting;

  const submit = useCallback(async () => {
    if (!ready) return;
    setSubmitError(null);
    const isPhoto = source === 'upload';
    if (isPhoto) setConverting(true);
    try {
      // App uploads the photo to Storage (if any) and writes the Firestore
      // doc; the Cloud Function takes it from there. It navigates home on
      // success, so this screen just unmounts.
      await onCreated({
        name: name.trim(),
        imageUri: isPhoto ? imageUri : null,
        build: isPhoto ? null : build,
        audio: audio?.dataUrl || null,
      });
    } catch (e) {
      setConverting(false);
      setSubmitError('Upload failed — check your connection and try again.');
    }
  }, [ready, name, source, build, imageUri, audio, onCreated]);

  const setBuildPart = (key, val) => setBuild((b) => ({ ...b, [key]: val }));

  const scanTop = scan.interpolate({ inputRange: [0, 1], outputRange: ['-14%', '104%'] });

  return (
    <LinearGradient colors={[squadColors.bgHomeTop, squadColors.bgHomeBottom]} style={styles.container}>
      <View style={[styles.header, { paddingTop: insets.top + 8 }]}>
        <Pressable onPress={onBack} style={styles.backBtn} hitSlop={8}>
          <Text style={styles.backGlyph}>‹</Text>
        </Pressable>
        <Text style={styles.title}>CREATE A SQUISHY</Text>
      </View>

      <ScrollView contentContainerStyle={[styles.body, { paddingBottom: insets.bottom + 20 }]} keyboardShouldPersistTaps="handled">
        <View style={styles.field}>
          <Text style={styles.fieldLabel}>TOY NAME</Text>
          <TextInput
            value={name}
            onChangeText={setName}
            placeholder="e.g. Sir Wobbles"
            placeholderTextColor={squadColors.textFaint}
            maxLength={18}
            style={styles.input}
          />
        </View>

        <View style={styles.field}>
          <Text style={styles.fieldLabel}>PICTURE</Text>
          <View style={styles.segment}>
            <Pressable style={[styles.segBtn, source === 'upload' && styles.segBtnOn]} onPress={() => setSource('upload')}>
              <Text style={[styles.segText, source === 'upload' && styles.segTextOn]}>UPLOAD</Text>
            </Pressable>
            <Pressable style={[styles.segBtn, source === 'assemble' && styles.segBtnOn]} onPress={() => setSource('assemble')}>
              <Text style={[styles.segText, source === 'assemble' && styles.segTextOn]}>CREATE ONE</Text>
            </Pressable>
          </View>

          {source === 'upload' ? (
            <>
              <Pressable style={styles.dropZone} onPress={pickImage}>
                {imageUri ? (
                  <Image source={{ uri: imageUri }} style={styles.uploadPreview} />
                ) : (
                  <View style={styles.dropIcon} />
                )}
                <Text style={styles.dropLabel}>{imageUri ? 'Picture added — tap to replace' : 'Tap to choose a picture'}</Text>
                <Text style={styles.dropHint}>PNG or JPG · we crop it square</Text>
              </Pressable>
              {imageError ? <Text style={styles.errorText}>{imageError}</Text> : null}
            </>
          ) : (
            <View style={styles.assembleWrap}>
              <View style={styles.assemblePreview}>
                <AssembleCreature build={build} size={150} />
              </View>
              {ASSEMBLE_ROWS.map((row) => (
                <View key={row.key} style={styles.assembleRow}>
                  <Text style={styles.assembleRowLabel}>{row.label}</Text>
                  <View style={styles.chips}>
                    {row.options.map(([val, label]) => {
                      const on = build[row.key] === val;
                      return (
                        <Pressable key={val} style={[styles.chip, on && styles.chipOn]} onPress={() => setBuildPart(row.key, val)}>
                          <Text style={[styles.chipText, on && styles.chipTextOn]}>{label}</Text>
                        </Pressable>
                      );
                    })}
                  </View>
                </View>
              ))}
              <View style={styles.assembleRow}>
                <Text style={styles.assembleRowLabel}>BODY COLOR</Text>
                <View style={styles.chips}>
                  {ASSEMBLE_BODY_COLORS.map((c) => (
                    <Pressable
                      key={c}
                      onPress={() => setBuildPart('color', c)}
                      style={[styles.swatch, { backgroundColor: c }, build.color === c && styles.swatchOn]}
                    />
                  ))}
                </View>
              </View>
            </View>
          )}
        </View>

        <View style={styles.field}>
          <View style={styles.rowBetween}>
            <Text style={styles.fieldLabel}>SQUISH SOUND</Text>
            <Text style={styles.optionalTag}>OPTIONAL</Text>
          </View>
          <Pressable style={styles.audioZone} onPress={pickAudio}>
            <View style={styles.audioIcon}>
              {[9, 17, 12, 6].map((h, i) => (
                <View key={i} style={[styles.audioBar, { height: h }]} />
              ))}
            </View>
            <View style={styles.audioTextWrap}>
              <Text style={styles.audioName} numberOfLines={1}>
                {audio?.name || 'Tap to add your squish sound'}
              </Text>
              <Text style={styles.dropHint}>MP3, WAV or M4A · max 3 s · max 2 MB</Text>
            </View>
          </Pressable>
          {audioError ? <Text style={styles.errorText}>{audioError}</Text> : null}
          {audio ? (
            <View style={styles.audioActions}>
              <Pressable style={[styles.smallBtn, styles.smallBtnTeal]} onPress={previewAudio}>
                <Text style={styles.smallBtnTealText}>▶ PREVIEW</Text>
              </Pressable>
              <Pressable style={styles.smallBtn} onPress={() => { setAudio(null); setAudioError(null); }}>
                <Text style={styles.smallBtnRedText}>REMOVE</Text>
              </Pressable>
            </View>
          ) : null}
        </View>
      </ScrollView>

      <View style={[styles.footer, { paddingBottom: insets.bottom + 12 }]}>
        {submitError ? <Text style={styles.errorText}>{submitError}</Text> : null}
        <Pressable disabled={!ready} onPress={submit} style={[styles.createBtn, !ready && styles.createBtnDim]}>
          <Text style={styles.createPrice}>$4.99</Text>
          <View style={styles.createDivider} />
          <Text style={styles.createLabel}>{source === 'assemble' ? 'CREATE' : 'CREATE IN 3D'}</Text>
        </Pressable>
        <Text style={styles.footerHint}>
          {!nameOk
            ? 'Add a name to continue'
            : !imgOk
            ? 'Add a picture to continue'
            : source === 'assemble'
            ? 'One-time purchase · plays as your assembled art'
            : 'One-time purchase · we turn your photo into a 3D squishy'}
        </Text>
      </View>

      {converting ? (
        <View style={styles.convertOverlay}>
          <View style={styles.convertFrame}>
            {imageUri ? <Image source={{ uri: imageUri }} style={styles.convertImg} /> : null}
            <Animated.View style={[styles.scanLine, { top: scanTop }]} />
          </View>
          <View style={styles.convertMeta}>
            <Text style={styles.convertStage}>Uploading your picture…</Text>
            <Text style={styles.convertPctText}>Then we build the 3D model in the background — check MY CREATURES.</Text>
          </View>
        </View>
      ) : null}
    </LinearGradient>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1 },
  header: { flexDirection: 'row', alignItems: 'center', gap: 12, paddingHorizontal: 16, paddingBottom: 12 },
  backBtn: { width: 36, height: 36, borderRadius: 10, backgroundColor: squadColors.panel, alignItems: 'center', justifyContent: 'center' },
  backGlyph: { color: '#fff', fontSize: 20, fontFamily: squadFonts.headingExtraBold },
  title: { fontFamily: squadFonts.headingExtraBold, fontSize: 19, color: '#fff' },

  body: { paddingHorizontal: 16, gap: 16 },
  field: { gap: 8 },
  fieldLabel: { color: '#b7a3e0', fontFamily: squadFonts.bodyExtraBold, fontSize: 10, letterSpacing: 1.6 },
  rowBetween: { flexDirection: 'row', alignItems: 'center', gap: 7 },
  optionalTag: {
    color: squadColors.textFaint,
    fontFamily: squadFonts.bodyExtraBold,
    fontSize: 9,
    letterSpacing: 1,
    backgroundColor: squadColors.panel,
    borderRadius: 6,
    paddingHorizontal: 6,
    paddingVertical: 2,
  },
  input: {
    backgroundColor: squadColors.panel,
    borderWidth: 1.5,
    borderColor: squadColors.panelBorder,
    borderRadius: 12,
    paddingHorizontal: 13,
    paddingVertical: 11,
    color: '#fff',
    fontFamily: squadFonts.bodyExtraBold,
    fontSize: 14,
  },

  segment: { flexDirection: 'row', gap: 8, backgroundColor: squadColors.inputBg, borderWidth: 1, borderColor: '#2f1c5a', borderRadius: 13, padding: 4 },
  segBtn: { flex: 1, borderRadius: 10, paddingVertical: 9, alignItems: 'center' },
  segBtnOn: { backgroundColor: squadColors.pink },
  segText: { color: '#b7a3e0', fontFamily: squadFonts.bodyExtraBold, fontSize: 11, letterSpacing: 1.2 },
  segTextOn: { color: '#fff' },

  dropZone: {
    minHeight: 150,
    borderRadius: 16,
    borderWidth: 1.5,
    borderColor: '#4c3a80',
    borderStyle: 'dashed',
    backgroundColor: squadColors.inputBg,
    alignItems: 'center',
    justifyContent: 'center',
    gap: 8,
    padding: 16,
  },
  dropIcon: { width: 44, height: 36, borderWidth: 2, borderColor: squadColors.textFaint, borderRadius: 6 },
  dropLabel: { color: squadColors.textLavender, fontFamily: squadFonts.bodyExtraBold, fontSize: 12 },
  dropHint: { color: squadColors.textFaint, fontFamily: squadFonts.bodyBold, fontSize: 10 },
  uploadPreview: { width: 104, height: 104, borderRadius: 14, borderWidth: 2, borderColor: squadColors.panelBorder },
  errorText: { color: '#f87171', fontFamily: squadFonts.bodyExtraBold, fontSize: 11 },

  assembleWrap: { gap: 11 },
  assemblePreview: {
    alignSelf: 'center',
    width: 170,
    height: 170,
    borderRadius: 16,
    borderWidth: 1.5,
    borderColor: squadColors.panelBorder,
    backgroundColor: '#f6f2ff',
    alignItems: 'center',
    justifyContent: 'center',
  },
  assembleRow: { gap: 6 },
  assembleRowLabel: { color: squadColors.textFaint, fontFamily: squadFonts.bodyExtraBold, fontSize: 9, letterSpacing: 1.2 },
  chips: { flexDirection: 'row', flexWrap: 'wrap', gap: 7 },
  chip: { borderWidth: 1.5, borderColor: squadColors.panelBorder, borderRadius: 10, paddingHorizontal: 11, paddingVertical: 7, backgroundColor: squadColors.panel },
  chipOn: { borderColor: squadColors.pinkLight, backgroundColor: '#3b1d63' },
  chipText: { color: '#b7a3e0', fontFamily: squadFonts.bodyExtraBold, fontSize: 10 },
  chipTextOn: { color: '#fff' },
  swatch: { width: 26, height: 26, borderRadius: 13, borderWidth: 2.5, borderColor: 'transparent' },
  swatchOn: { borderColor: '#ffffff' },

  audioZone: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 11,
    borderRadius: 14,
    borderWidth: 1.5,
    borderColor: '#4c3a80',
    borderStyle: 'dashed',
    backgroundColor: squadColors.inputBg,
    padding: 12,
  },
  audioIcon: { width: 34, height: 34, borderRadius: 11, backgroundColor: squadColors.panel, flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 2.5 },
  audioBar: { width: 2.5, borderRadius: 1, backgroundColor: squadColors.teal },
  audioTextWrap: { flex: 1, gap: 2 },
  audioName: { color: squadColors.textLavender, fontFamily: squadFonts.bodyExtraBold, fontSize: 12 },
  audioActions: { flexDirection: 'row', gap: 8 },
  smallBtn: { flex: 1, borderWidth: 1.5, borderColor: squadColors.panelBorder, borderRadius: 11, paddingVertical: 9, alignItems: 'center', backgroundColor: squadColors.panel },
  smallBtnTeal: { borderColor: squadColors.teal, backgroundColor: '#152b33' },
  smallBtnTealText: { color: squadColors.teal, fontFamily: squadFonts.bodyExtraBold, fontSize: 10, letterSpacing: 1.2 },
  smallBtnRedText: { color: '#f87171', fontFamily: squadFonts.bodyExtraBold, fontSize: 10, letterSpacing: 1.2 },

  footer: { paddingHorizontal: 16, paddingTop: 12, borderTopWidth: 1, borderTopColor: '#2f1c5a', backgroundColor: squadColors.bgDeepest, gap: 8 },
  createBtn: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'center',
    gap: 10,
    borderRadius: 16,
    paddingVertical: 14,
    backgroundColor: squadColors.gold,
  },
  createBtnDim: { opacity: 0.45 },
  createPrice: { fontFamily: squadFonts.headingExtraBold, fontSize: 17, color: squadColors.bgDeepest },
  createDivider: { width: 1.5, height: 16, backgroundColor: 'rgba(13,6,32,0.3)' },
  createLabel: { color: squadColors.bgDeepest, fontFamily: squadFonts.bodyExtraBold, fontSize: 12, letterSpacing: 1.6 },
  footerHint: { color: squadColors.textFaint, fontFamily: squadFonts.bodyBold, fontSize: 10, textAlign: 'center' },

  convertOverlay: { ...StyleSheet.absoluteFillObject, backgroundColor: 'rgba(13,6,32,0.94)', alignItems: 'center', justifyContent: 'center', gap: 22, padding: 32 },
  convertFrame: {
    width: 150,
    height: 150,
    borderRadius: 20,
    overflow: 'hidden',
    borderWidth: 1.5,
    borderColor: squadColors.panelBorder,
    backgroundColor: squadColors.inputBg,
    alignItems: 'center',
    justifyContent: 'center',
  },
  convertImg: { width: '100%', height: '100%', opacity: 0.85 },
  scanLine: { position: 'absolute', left: 0, right: 0, height: '14%', backgroundColor: 'rgba(34,224,208,0.55)' },
  convertMeta: { alignItems: 'center', gap: 12, width: '100%', maxWidth: 260 },
  convertStage: { fontFamily: squadFonts.headingExtraBold, fontSize: 17, color: '#fff', textAlign: 'center' },
  convertTrack: { width: '100%', height: 6, borderRadius: 3, backgroundColor: squadColors.panel, overflow: 'hidden' },
  convertFill: { height: '100%', borderRadius: 3, backgroundColor: squadColors.teal },
  convertPctText: { color: squadColors.textFaint, fontFamily: squadFonts.bodyExtraBold, fontSize: 10, letterSpacing: 1.4 },
});
