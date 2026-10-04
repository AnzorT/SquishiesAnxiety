import React, { useCallback, useEffect, useRef, useState } from 'react';
import { View, Text, StyleSheet, Pressable, ScrollView, TextInput, Image, Animated, Easing } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import * as ImagePicker from 'expo-image-picker';
import * as ImageManipulator from 'expo-image-manipulator';
import * as DocumentPicker from 'expo-document-picker';
import { Audio } from 'expo-av';
import { candyColors, candyFonts } from '../theme/candyTheme';
import CandyBackground from '../components/candy/CandyBackground';
import CandyButton, { ButtonText } from '../components/candy/CandyButton';
import RoundButton, { BackGlyph } from '../components/candy/RoundButton';
import OutlinedTitle, { HaloText } from '../components/candy/OutlinedTitle';
import { CandyProgress, RaysSpin } from '../components/candy/Decor';
import { Twinkle } from '../components/candy/Sparkles';
import { PhotoBadge } from '../components/CustomCards';
import AssembleCreature, { ASSEMBLE_BODY_COLORS, ASSEMBLE_DEFAULT } from '../components/AssembleCreature';
import PaintCanvas from '../components/PaintCanvas';

// CREATE A SQUISHY — the creator flow in the v3 candy look. Name, then a
// picture (upload a photo, or CREATE ONE: paint it, or assemble it from
// parts), an optional short squish sound.
//
// On submit this hands a payload to `onCreated` (App): for a photo it uploads
// the resized JPEG to Storage and creates a `status: 'pending'` doc — the
// `generateCustomModel` Cloud Function then runs Tripo image-to-3D in the
// background and the MY CREATURES card tracks its progress. A painting takes
// the same path as a photo (it's rendered to a JPEG first). Assemble-path
// creatures are born ready and play as their 2D art.
//
// A creation uses one generation credit: the free one every player starts
// with, or one bought right here — with none left, the button shows the
// store's price and buys one (Google Play / the App Store, src/billing),
// then carries straight on with the creation. A credit bought earlier that
// wasn't used yet (`paidCredits`: the creation failed to upload, or the
// store confirmed it late) shows as PAID, not FREE, and is used first.

const MAX_AUDIO_CHARS = 700000; // ~500 KB of base64 — keeps the Firestore doc small

const ASSEMBLE_ROWS = [
  { key: 'body', label: 'BODY', options: [['blob', 'Blob'], ['round', 'Round'], ['tall', 'Tall'], ['wide', 'Wide']] },
  { key: 'eyes', label: 'EYES', options: [['round', 'Round'], ['wide', 'Wide'], ['slit', 'Sleepy'], ['star', 'Star']] },
  { key: 'mouth', label: 'MOUTH', options: [['smile', 'Smile'], ['open', 'Open'], ['flat', 'Flat'], ['fang', 'Fang']] },
  { key: 'extra', label: 'EXTRA', options: [['none', 'None'], ['antenna', 'Antenna'], ['ears', 'Ears'], ['horns', 'Horns']] },
];

export default function CreateScreen({ onBack, onCreated, generationCredits = 1, paidCredits = 0, priceLabel = '$4.99', discountPct = 0, onBuyCreation, buying = false }) {
  const insets = useSafeAreaInsets();

  const [name, setName] = useState('');
  const [source, setSource] = useState('upload'); // 'upload' | 'draw'
  const [drawMode, setDrawMode] = useState('paint'); // 'paint' | 'assemble' (under CREATE ONE)
  const [drawing, setDrawing] = useState(false); // a paint stroke is in progress
  const paintRef = useRef(null);
  const [imageUri, setImageUri] = useState(null); // resized local JPEG
  const [imageError, setImageError] = useState(null);
  const [build, setBuild] = useState(ASSEMBLE_DEFAULT);
  const [audio, setAudio] = useState(null); // { uri, name, dataUrl }
  const [audioError, setAudioError] = useState(null);

  const [converting, setConverting] = useState(false);
  const [uploadUri, setUploadUri] = useState(null); // the picture being uploaded
  const [submitError, setSubmitError] = useState(null);
  const previewSoundRef = useRef(null);

  useEffect(
    () => () => {
      previewSoundRef.current?.unloadAsync?.().catch(() => {});
    },
    []
  );

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
  const assembling = source === 'draw' && drawMode === 'assemble';
  const painting = source === 'draw' && drawMode === 'paint';
  // A painting is checked on submit (the pad tells whether it's blank).
  const imgOk = source === 'draw' || !!imageUri;
  // One free generation credit covers either path — the assemble path has no
  // Tripo/backend cost, but it's still gated the same way so it actually
  // consumes the shared credit (see generateCustomModel's assemble-path
  // branch in functions/index.js) instead of always reading as free.
  const hasCredit = generationCredits > 0;
  const creditPaid = hasCredit && paidCredits > 0;
  const ready = nameOk && imgOk && !converting && !buying;

  const submit = useCallback(async () => {
    if (!ready) return;
    setSubmitError(null);
    // No credit: buy one first. (Paid creations get no ad break.)
    let paid = false;
    if (!hasCredit) {
      if (!onBuyCreation || !(await onBuyCreation())) return;
      paid = true;
    }
    const isPhoto = !assembling;
    let picture = imageUri;
    if (painting) {
      if (!paintRef.current || paintRef.current.isEmpty()) {
        setSubmitError('Paint something first.');
        return;
      }
      try {
        picture = await paintRef.current.exportImage();
      } catch (e) {
        setSubmitError('Could not save your painting — try again.');
        return;
      }
    }
    if (isPhoto) {
      setUploadUri(picture);
      setConverting(true);
    }
    try {
      // App uploads the photo to Storage (if any) and writes the Firestore
      // doc; the Cloud Function takes it from there. It navigates home on
      // success, so this screen just unmounts.
      await onCreated({
        name: name.trim(),
        imageUri: isPhoto ? picture : null,
        build: isPhoto ? null : build,
        audio: audio?.dataUrl || null,
        paid,
      });
    } catch (e) {
      setConverting(false);
      // Was silently swallowed into a generic message before — logging the
      // real error (Storage/Firestore error code, permission-denied, etc.)
      // so it shows up in Metro/logcat instead of being a dead end.
      // eslint-disable-next-line no-console
      console.error('[CreateScreen] submit failed:', (e && e.stack) || e);
      const detail = e?.code || e?.message;
      setSubmitError(detail ? `Upload failed — ${detail}` : 'Upload failed — check your connection and try again.');
    }
  }, [ready, hasCredit, onBuyCreation, name, assembling, painting, build, imageUri, audio, onCreated]);

  const setBuildPart = (key, val) => setBuild((b) => ({ ...b, [key]: val }));

  return (
    <CandyBackground style={styles.container}>
      <View style={[styles.header, { paddingTop: insets.top + 10 }]}>
        <RoundButton size={36} onPress={onBack} hitSlop={8}>
          <BackGlyph />
        </RoundButton>
        <OutlinedTitle text="CREATE A SQUISHY" fill="pink" size={19} outline={3} />
      </View>

      <ScrollView contentContainerStyle={[styles.body, { paddingBottom: 20 }]} keyboardShouldPersistTaps="handled" scrollEnabled={!drawing}>
        <View style={styles.field}>
          <Text style={styles.fieldLabel}>TOY NAME</Text>
          <TextInput value={name} onChangeText={setName} placeholder="e.g. Sir Wobbles" placeholderTextColor="#a98bc9" maxLength={18} style={styles.input} />
        </View>

        <View style={styles.field}>
          <Text style={styles.fieldLabel}>PICTURE</Text>
          <View style={styles.segment}>
            {[
              ['upload', 'UPLOAD'],
              ['draw', 'CREATE ONE'],
            ].map(([val, label]) => {
              const on = source === val;
              return (
                <Pressable key={val} style={styles.segBtn} onPress={() => setSource(val)}>
                  {on ? <LinearGradient colors={['#ff8fd8', '#ff3ea5']} style={StyleSheet.absoluteFill} /> : null}
                  <Text style={[styles.segText, on && styles.segTextOn]}>{label}</Text>
                </Pressable>
              );
            })}
          </View>

          {source === 'upload' ? (
            <>
              <Pressable style={styles.dropZone} onPress={pickImage}>
                {imageUri ? (
                  <Image source={{ uri: imageUri }} style={styles.uploadPreview} />
                ) : (
                  <View style={styles.dropIcon}>
                    <View style={styles.dropSun} />
                    <View style={styles.dropHill} />
                  </View>
                )}
                <Text style={styles.dropLabel}>{imageUri ? 'Picture added — tap to replace' : 'Tap to choose a picture'}</Text>
                <Text style={styles.dropHint}>PNG or JPG · we crop it square</Text>
              </Pressable>
              {imageError ? <Text style={styles.errorText}>{imageError}</Text> : null}
            </>
          ) : (
            <View style={styles.drawWrap}>
              <View style={styles.drawTabs}>
                {[
                  ['paint', 'PAINT'],
                  ['assemble', 'ASSEMBLE'],
                ].map(([val, label]) => {
                  const on = drawMode === val;
                  return (
                    <Pressable key={val} onPress={() => setDrawMode(val)} style={[styles.drawTab, on && styles.drawTabOn]} hitSlop={6}>
                      <Text style={[styles.drawTabText, on && styles.drawTabTextOn]}>{label}</Text>
                    </Pressable>
                  );
                })}
              </View>
              {/* kept mounted, so switching tabs doesn't lose the painting */}
              <View style={painting ? null : styles.gone}>
                <PaintCanvas ref={paintRef} onStroke={setDrawing} />
              </View>
              {assembling ? (
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
              ) : null}
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
              <Pressable
                style={styles.smallBtn}
                onPress={() => {
                  setAudio(null);
                  setAudioError(null);
                }}
              >
                <Text style={styles.smallBtnRedText}>REMOVE</Text>
              </Pressable>
            </View>
          ) : null}
        </View>
      </ScrollView>

      <View style={[styles.footer, { paddingBottom: insets.bottom + 12 }]}>
        {submitError ? <Text style={styles.errorText}>{submitError}</Text> : null}
        <CandyButton variant={ready ? 'pink' : 'grey'} size="md" radius={18} onPress={submit} disabled={!ready} dim={!ready} loading={buying} style={styles.createBtn}>
          <View style={styles.createRow}>
            <ButtonText ring={ready ? '#8e1580' : '#5a4a80'} size={17}>
              {creditPaid ? 'PAID' : hasCredit ? 'FREE' : priceLabel}
            </ButtonText>
            <View style={styles.createDivider} />
            <ButtonText ring={ready ? '#8e1580' : '#5a4a80'} size={13} style={styles.createLabel}>
              {assembling ? 'CREATE' : 'CREATE IN 3D'}
            </ButtonText>
          </View>
        </CandyButton>
        <Text style={styles.footerHint}>
          {!nameOk
            ? 'Add a name to continue'
            : !imgOk
            ? 'Add a picture to continue'
            : !hasCredit && discountPct
            ? `One-time purchase · your Daily Spin prize takes ${discountPct}% off`
            : !hasCredit
            ? 'One-time purchase · your creature stays in My Creatures'
            : creditPaid
            ? 'Uses the creation you bought'
            : assembling
            ? 'Uses one creature generation · plays as your assembled art'
            : painting
            ? 'Uses one creature generation · we turn your painting into a 3D squishy'
            : 'Uses one creature generation · we turn your photo into a 3D squishy'}
        </Text>
      </View>

      {converting ? <CreatingOverlay uri={uploadUri} /> : null}
    </CandyBackground>
  );
}

// Shown while the picture uploads (a few seconds), before Home takes over:
// the picture in the custom card's round candy frame under spinning rays,
// a white-and-pink shine sweeping down it, and a candy bar easing towards
// full. The 3D model itself is built afterwards, on MY CREATURES.
function CreatingOverlay({ uri }) {
  const fill = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    // `width` can't run on the native driver
    const a = Animated.timing(fill, { toValue: 0.92, duration: 6000, easing: Easing.out(Easing.cubic), useNativeDriver: false });
    a.start();
    return () => a.stop();
  }, [fill]);
  const width = fill.interpolate({ inputRange: [0, 1], outputRange: ['0%', '100%'] });
  return (
    <View style={styles.creatingOverlay}>
      <CandyBackground sparkles>
        <View style={styles.creatingBody}>
          <OutlinedTitle text="CREATING…" fill="gold" size={34} outline={4} />
          <View style={styles.creatingStage}>
            <View style={styles.creatingRays} pointerEvents="none">
              <RaysSpin size={330} durationMs={9000} opacity={0.5} />
            </View>
            <PhotoBadge uri={uri} size={180} busy />
            <Twinkle size={18} duration={1.6} style={styles.twinkleA} />
            <Twinkle size={12} duration={2.1} delay={500} style={styles.twinkleB} />
            <Twinkle size={14} color="#fff3a0" duration={1.8} delay={900} style={styles.twinkleC} />
          </View>
          <HaloText style={styles.creatingStep}>Uploading your picture…</HaloText>
          <CandyProgress height={14} ring={candyColors.pinkRing} fill={['#ffa8e6', '#ff4fbf']} animatedWidth={width} style={styles.creatingBar} />
          <View style={styles.creatingNote}>
            <Text style={styles.creatingNoteText}>Next we build it in 3D. It will be waiting for you in MY CREATURES.</Text>
          </View>
        </View>
      </CandyBackground>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1 },
  header: { flexDirection: 'row', alignItems: 'center', gap: 8, paddingHorizontal: 16, paddingBottom: 10 },

  body: { paddingHorizontal: 16, gap: 16 },
  field: { gap: 8 },
  fieldLabel: {
    color: '#ffffff',
    fontFamily: candyFonts.bodyBlack,
    fontSize: 10,
    letterSpacing: 1.6,
    textShadowColor: candyColors.outline,
    textShadowOffset: { width: 0, height: 1 },
    textShadowRadius: 1,
  },
  rowBetween: { flexDirection: 'row', alignItems: 'center', gap: 7 },
  optionalTag: {
    color: '#a283c9',
    fontFamily: candyFonts.bodyHeavy,
    fontSize: 9,
    letterSpacing: 1,
    backgroundColor: '#ffffff',
    borderRadius: 6,
    overflow: 'hidden',
    paddingHorizontal: 6,
    paddingVertical: 2,
  },
  input: {
    backgroundColor: '#ffffff',
    borderWidth: 1.5,
    borderColor: candyColors.inkSoft,
    borderRadius: 12,
    paddingHorizontal: 13,
    paddingVertical: 11,
    color: candyColors.ink,
    fontFamily: candyFonts.bodyHeavy,
    fontSize: 14,
  },

  segment: { flexDirection: 'row', gap: 8, backgroundColor: candyColors.paper, borderWidth: 1, borderColor: '#e3cff5', borderRadius: 13, padding: 4 },
  segBtn: { flex: 1, borderRadius: 10, paddingVertical: 9, alignItems: 'center', overflow: 'hidden' },
  segText: { color: candyColors.inkSoft, fontFamily: candyFonts.bodyBlack, fontSize: 11, letterSpacing: 1.2 },
  segTextOn: { color: '#fff' },

  dropZone: {
    minHeight: 150,
    borderRadius: 16,
    borderWidth: 1.5,
    borderColor: '#c9a8e8',
    borderStyle: 'dashed',
    backgroundColor: candyColors.paper,
    alignItems: 'center',
    justifyContent: 'center',
    gap: 8,
    padding: 16,
  },
  dropIcon: { width: 44, height: 36, borderWidth: 2, borderColor: '#a283c9', borderRadius: 6, overflow: 'hidden' },
  dropSun: { position: 'absolute', left: 6, bottom: 5, width: 12, height: 12, borderRadius: 6, backgroundColor: '#a283c9' },
  dropHill: {
    position: 'absolute',
    right: 5,
    bottom: 4,
    width: 0,
    height: 0,
    borderLeftWidth: 11,
    borderRightWidth: 11,
    borderBottomWidth: 15,
    borderLeftColor: 'transparent',
    borderRightColor: 'transparent',
    borderBottomColor: '#a283c9',
  },
  dropLabel: { color: candyColors.inkSoft, fontFamily: candyFonts.bodyHeavy, fontSize: 12 },
  dropHint: { color: '#a283c9', fontFamily: candyFonts.body, fontSize: 10 },
  uploadPreview: { width: 104, height: 104, borderRadius: 14, borderWidth: 2, borderColor: candyColors.inkSoft },
  errorText: {
    color: '#ffffff',
    backgroundColor: 'rgba(229,72,77,0.85)',
    borderRadius: 8,
    overflow: 'hidden',
    paddingHorizontal: 10,
    paddingVertical: 4,
    fontFamily: candyFonts.bodyHeavy,
    fontSize: 11,
  },

  drawWrap: { gap: 10 },
  drawTabs: { flexDirection: 'row', gap: 16, borderBottomWidth: 1.5, borderBottomColor: 'rgba(255,255,255,0.35)', paddingLeft: 2 },
  drawTab: { paddingBottom: 8, borderBottomWidth: 2.5, borderBottomColor: 'transparent', marginBottom: -1.5 },
  drawTabOn: { borderBottomColor: '#ff3ea5' },
  drawTabText: { color: '#a283c9', fontFamily: candyFonts.bodyBlack, fontSize: 10, letterSpacing: 1.4 },
  drawTabTextOn: { color: '#4a1a73' },
  gone: { display: 'none' },
  assembleWrap: { gap: 11, backgroundColor: candyColors.paper, borderRadius: 16, padding: 12 },
  assemblePreview: {
    alignSelf: 'center',
    width: 170,
    height: 170,
    borderRadius: 16,
    borderWidth: 1.5,
    borderColor: candyColors.inkSoft,
    backgroundColor: '#ffffff',
    alignItems: 'center',
    justifyContent: 'center',
  },
  assembleRow: { gap: 6 },
  assembleRowLabel: { color: '#a283c9', fontFamily: candyFonts.bodyBlack, fontSize: 9, letterSpacing: 1.2 },
  chips: { flexDirection: 'row', flexWrap: 'wrap', gap: 7 },
  chip: { borderWidth: 1.5, borderColor: '#e3cff5', borderRadius: 10, paddingHorizontal: 11, paddingVertical: 7, backgroundColor: '#ffffff' },
  chipOn: { borderColor: candyColors.inkSoft, backgroundColor: '#ffe4f5' },
  chipText: { color: candyColors.inkSoft, fontFamily: candyFonts.bodyHeavy, fontSize: 10 },
  chipTextOn: { color: candyColors.ink },
  swatch: { width: 26, height: 26, borderRadius: 13, borderWidth: 2.5, borderColor: 'transparent' },
  swatchOn: { borderColor: candyColors.inkSoft },

  audioZone: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 11,
    borderRadius: 14,
    borderWidth: 1.5,
    borderColor: '#c9a8e8',
    borderStyle: 'dashed',
    backgroundColor: candyColors.paper,
    padding: 12,
  },
  audioIcon: { width: 34, height: 34, borderRadius: 11, backgroundColor: '#ffffff', flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 2.5 },
  audioBar: { width: 2.5, borderRadius: 1, backgroundColor: candyColors.teal },
  audioTextWrap: { flex: 1, gap: 2 },
  audioName: { color: candyColors.inkSoft, fontFamily: candyFonts.bodyHeavy, fontSize: 12 },
  audioActions: { flexDirection: 'row', gap: 8 },
  smallBtn: { flex: 1, borderWidth: 1.5, borderColor: candyColors.inkSoft, borderRadius: 11, paddingVertical: 9, alignItems: 'center', backgroundColor: '#ffffff' },
  smallBtnTeal: { borderColor: candyColors.teal, backgroundColor: '#e0fbf7' },
  smallBtnTealText: { color: '#0f9d90', fontFamily: candyFonts.bodyBlack, fontSize: 10, letterSpacing: 1.2 },
  smallBtnRedText: { color: candyColors.danger, fontFamily: candyFonts.bodyBlack, fontSize: 10, letterSpacing: 1.2 },

  footer: { paddingHorizontal: 16, paddingTop: 12, borderTopWidth: 1, borderTopColor: '#e3cff5', backgroundColor: candyColors.paper, gap: 8 },
  createBtn: { width: '100%' },
  createRow: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  createDivider: { width: 1.5, height: 16, backgroundColor: 'rgba(74,26,115,0.3)' },
  createLabel: { letterSpacing: 1.6 },
  footerHint: { color: '#a283c9', fontFamily: candyFonts.body, fontSize: 10, textAlign: 'center' },

  creatingOverlay: { ...StyleSheet.absoluteFillObject, zIndex: 50, elevation: 50 },
  creatingBody: { flex: 1, alignItems: 'center', justifyContent: 'center', paddingHorizontal: 32, gap: 18 },
  creatingStage: { width: 240, height: 240, alignItems: 'center', justifyContent: 'center' },
  creatingRays: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
  twinkleA: { position: 'absolute', top: 18, right: 22 },
  twinkleB: { position: 'absolute', bottom: 34, left: 18 },
  twinkleC: { position: 'absolute', top: 44, left: 30 },
  creatingStep: { fontSize: 19, textAlign: 'center' },
  creatingBar: { width: 220 },
  creatingNote: {
    borderRadius: 18,
    backgroundColor: candyColors.glass,
    borderWidth: 2,
    borderColor: 'rgba(255,255,255,0.7)',
    paddingVertical: 9,
    paddingHorizontal: 16,
    maxWidth: 300,
  },
  creatingNoteText: { color: '#ffffff', fontFamily: candyFonts.bodyHeavy, fontSize: 12.5, lineHeight: 17, textAlign: 'center' },
});
