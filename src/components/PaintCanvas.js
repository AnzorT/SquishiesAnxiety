import React, { forwardRef, memo, useCallback, useImperativeHandle, useMemo, useRef, useState } from 'react';
import { PanResponder, Pressable, StyleSheet, Text, View } from 'react-native';
import Svg, { Circle, Path, Rect } from 'react-native-svg';
import * as FileSystem from 'expo-file-system';
import * as ImageManipulator from 'expo-image-manipulator';
import { candyFonts } from '../theme/candyTheme';

// PAINT, the v3 design's drawing pad: a white square to finger-paint on, 8
// colours, a brush size slider (4–48), ERASER, UNDO and CLEAR. Strokes are
// kept as SVG paths in the pad's own 320×320 space (the design's canvas);
// `exportImage()` renders them to a square JPEG file for the photo → 3D
// path, the same as an uploaded picture.

export const PAINT_COLORS = ['#0f172a', '#ff3ea5', '#ffb703', '#2dd4bf', '#a855f7', '#4ade80', '#38bdf8', '#ffffff'];
const SPACE = 320; // drawing units, like the design's <canvas width="320">
const SHOW = 190; // on screen, like its CSS width
const EXPORT_PX = 1024;
const MIN_BRUSH = 4;
const MAX_BRUSH = 48;
const HISTORY = 12;

// ---- brush size slider (the design's range input) ---------------------------

const BrushSlider = memo(function BrushSlider({ value, onChange }) {
  const [w, setW] = useState(0);
  const wRef = useRef(0);
  wRef.current = w;
  const set = useCallback(
    (x) => {
      if (!wRef.current) return;
      const t = Math.max(0, Math.min(1, x / wRef.current));
      onChange(Math.round((MIN_BRUSH + t * (MAX_BRUSH - MIN_BRUSH)) / 2) * 2);
    },
    [onChange]
  );
  const pan = useMemo(
    () =>
      PanResponder.create({
        onStartShouldSetPanResponder: () => true,
        onMoveShouldSetPanResponder: () => true,
        onPanResponderTerminationRequest: () => false,
        onPanResponderGrant: (e) => set(e.nativeEvent.locationX),
        onPanResponderMove: (e) => set(e.nativeEvent.locationX),
      }),
    [set]
  );
  const t = (value - MIN_BRUSH) / (MAX_BRUSH - MIN_BRUSH);
  return (
    <View style={styles.slider} onLayout={(e) => setW(e.nativeEvent.layout.width)} {...pan.panHandlers}>
      <View style={styles.sliderTrack} pointerEvents="none">
        <View style={[styles.sliderFill, { width: `${t * 100}%` }]} />
      </View>
      <View style={[styles.sliderKnob, { left: t * w - 9 }]} pointerEvents="none" />
    </View>
  );
});

// ---- the pad -------------------------------------------------------------

const toPath = (pts) => {
  if (pts.length === 1) return null;
  let d = `M${pts[0][0].toFixed(1)} ${pts[0][1].toFixed(1)}`;
  for (let i = 1; i < pts.length; i++) d += ` L${pts[i][0].toFixed(1)} ${pts[i][1].toFixed(1)}`;
  return d;
};

// One finished stroke. Memoised: only the stroke being drawn re-renders.
const Stroke = memo(function Stroke({ stroke }) {
  const d = toPath(stroke.pts);
  if (!d) return <Circle cx={stroke.pts[0][0]} cy={stroke.pts[0][1]} r={stroke.w / 2} fill={stroke.color} />;
  return <Path d={d} stroke={stroke.color} strokeWidth={stroke.w} strokeLinecap="round" strokeLinejoin="round" fill="none" />;
});

// `onStroke(true/false)`: a stroke started / ended (the Create screen
// stops scrolling meanwhile).
function PaintCanvas({ onStroke }, ref) {
  // `layers`: the drawing, as a list of strokes; each undo step is a whole
  // snapshot of it (the design keeps 12), so CLEAR can be undone too.
  const [layers, setLayers] = useState([]);
  const [live, setLive] = useState(null); // the stroke under the finger
  const [color, setColor] = useState('#ff3ea5');
  const [brush, setBrush] = useState(18);
  const [eraser, setEraser] = useState(false);
  const historyRef = useRef([]);
  const layersRef = useRef(layers);
  layersRef.current = layers;
  const liveRef = useRef(null);
  const toolRef = useRef({ color, brush, eraser });
  toolRef.current = { color, brush, eraser };
  const svgRef = useRef(null);

  const snapshot = useCallback(() => {
    historyRef.current.push(layersRef.current);
    if (historyRef.current.length > HISTORY) historyRef.current.shift();
  }, []);

  const originRef = useRef([0, 0]);
  const finish = useCallback(() => {
    const s = liveRef.current;
    liveRef.current = null;
    setLive(null);
    if (s) setLayers((l) => [...l, s]);
    onStroke && onStroke(false);
  }, [onStroke]);

  const k = SPACE / SHOW;
  const pan = useMemo(
    () =>
      PanResponder.create({
        onStartShouldSetPanResponder: () => true,
        onMoveShouldSetPanResponder: () => true,
        // keep the stroke even if the finger drifts (the page scroll would
        // otherwise take it over)
        onPanResponderTerminationRequest: () => false,
        onPanResponderGrant: (e) => {
          snapshot();
          // Work from page coordinates: `location` is relative to whatever
          // element is under the finger, which can change mid-stroke.
          const { pageX, pageY, locationX, locationY } = e.nativeEvent;
          originRef.current = [pageX - locationX, pageY - locationY];
          const { color: c, brush: b, eraser: er } = toolRef.current;
          const s = { color: er ? '#ffffff' : c, w: b * k, pts: [[locationX * k, locationY * k]] };
          liveRef.current = s;
          setLive({ ...s });
          onStroke && onStroke(true);
        },
        onPanResponderMove: (e) => {
          const s = liveRef.current;
          if (!s) return;
          const [ox, oy] = originRef.current;
          const x = Math.max(0, Math.min(SPACE, (e.nativeEvent.pageX - ox) * k));
          const y = Math.max(0, Math.min(SPACE, (e.nativeEvent.pageY - oy) * k));
          const [px, py] = s.pts[s.pts.length - 1];
          if ((x - px) ** 2 + (y - py) ** 2 < 4) return;
          s.pts.push([x, y]);
          setLive({ ...s, pts: s.pts.slice() });
        },
        onPanResponderRelease: () => finish(),
        onPanResponderTerminate: () => finish(),
      }),
    [k, snapshot, finish, onStroke]
  );

  const undo = useCallback(() => {
    const prev = historyRef.current.pop();
    if (prev) setLayers(prev);
  }, []);
  const clear = useCallback(() => {
    if (!layersRef.current.length) return;
    snapshot();
    setLayers([]);
  }, [snapshot]);
  const pick = useCallback((c) => {
    setColor(c);
    setEraser(false);
  }, []);

  useImperativeHandle(
    ref,
    () => ({
      isEmpty: () => !layersRef.current.some((s) => s.color !== '#ffffff'),
      // Renders the drawing to a EXPORT_PX square JPEG file; resolves its uri.
      exportImage: () =>
        new Promise((resolve, reject) => {
          if (!svgRef.current) return reject(new Error('no canvas'));
          svgRef.current.toDataURL(
            async (base64) => {
              try {
                const png = `${FileSystem.cacheDirectory}paint-${Date.now()}.png`;
                await FileSystem.writeAsStringAsync(png, base64, { encoding: FileSystem.EncodingType.Base64 });
                const out = await ImageManipulator.manipulateAsync(png, [], { compress: 0.9, format: ImageManipulator.SaveFormat.JPEG });
                FileSystem.deleteAsync(png, { idempotent: true }).catch(() => {});
                resolve(out.uri);
              } catch (e) {
                reject(e);
              }
            },
            { width: EXPORT_PX, height: EXPORT_PX }
          );
        }),
    }),
    []
  );

  return (
    <View style={styles.wrap}>
      <View style={styles.pad} {...pan.panHandlers}>
        <Svg ref={svgRef} width={SHOW} height={SHOW} viewBox={`0 0 ${SPACE} ${SPACE}`}>
          <Rect x={0} y={0} width={SPACE} height={SPACE} fill="#ffffff" />
          {layers.map((s, i) => (
            <Stroke key={i} stroke={s} />
          ))}
          {live ? <Stroke stroke={live} /> : null}
        </Svg>
      </View>

      <View style={styles.swatches}>
        {PAINT_COLORS.map((c) => (
          <Pressable
            key={c}
            onPress={() => pick(c)}
            hitSlop={3}
            style={[styles.swatch, { backgroundColor: c, borderColor: !eraser && color === c ? '#6b3fa0' : c === '#ffffff' ? '#e3cff5' : 'transparent' }]}
          />
        ))}
      </View>
      <View style={styles.brushRow}>
        <Text style={styles.brushLabel}>BRUSH</Text>
        <BrushSlider value={brush} onChange={setBrush} />
        <Text style={styles.brushValue}>{brush}</Text>
      </View>
      <View style={styles.tools}>
        <Pressable style={[styles.tool, eraser && styles.toolOn]} onPress={() => setEraser((e) => !e)}>
          <Text style={[styles.toolText, eraser && styles.toolTextOn]}>ERASER</Text>
        </Pressable>
        <Pressable style={styles.tool} onPress={undo}>
          <Text style={styles.toolText}>UNDO</Text>
        </Pressable>
        <Pressable style={styles.tool} onPress={clear}>
          <Text style={[styles.toolText, styles.toolTextRed]}>CLEAR</Text>
        </Pressable>
      </View>
    </View>
  );
}

export default memo(forwardRef(PaintCanvas));

const styles = StyleSheet.create({
  wrap: { gap: 9 },
  pad: {
    alignSelf: 'center',
    width: SHOW + 3,
    height: SHOW + 3,
    borderRadius: 16,
    borderWidth: 1.5,
    borderColor: '#6b3fa0',
    overflow: 'hidden',
    backgroundColor: '#ffffff',
  },
  swatches: { flexDirection: 'row', flexWrap: 'wrap', gap: 7, marginTop: 1 },
  swatch: { width: 26, height: 26, borderRadius: 13, borderWidth: 2.5 },
  brushRow: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  brushLabel: { color: '#a283c9', fontFamily: candyFonts.bodyBlack, fontSize: 9, letterSpacing: 1.2 },
  brushValue: { width: 24, textAlign: 'right', color: '#6b3fa0', fontFamily: candyFonts.bodyHeavy, fontSize: 11 },
  slider: { flex: 1, height: 26, justifyContent: 'center' },
  sliderTrack: { height: 6, borderRadius: 3, backgroundColor: '#ead9f7', overflow: 'hidden' },
  sliderFill: { height: '100%', backgroundColor: '#ff3ea5' },
  sliderKnob: { position: 'absolute', top: 4, width: 18, height: 18, borderRadius: 9, backgroundColor: '#ff3ea5', borderWidth: 2, borderColor: '#ffffff' },
  tools: { flexDirection: 'row', gap: 8 },
  tool: {
    flex: 1,
    borderWidth: 1.5,
    borderColor: '#6b3fa0',
    borderRadius: 11,
    paddingVertical: 9,
    paddingHorizontal: 4,
    alignItems: 'center',
    backgroundColor: '#ffffff',
  },
  toolOn: { backgroundColor: '#ffd6ee' },
  toolText: { color: '#6b3fa0', fontFamily: candyFonts.bodyBlack, fontSize: 10, letterSpacing: 1.2 },
  toolTextOn: { color: '#4a1a73' },
  toolTextRed: { color: '#e5484d' },
});
