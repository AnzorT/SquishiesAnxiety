import React, { memo, useEffect, useMemo, useRef } from 'react';
import { Animated, Easing, Pressable, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Defs, RadialGradient, Stop, Circle, Ellipse, Path, Polygon, Rect } from 'react-native-svg';
import OutlinedTitle from '../candy/OutlinedTitle';
import { Shine } from '../candy/CandyButton';

// The Mystery Box's gift, 1:1 with the v3 design (a 210×210 box): pink base
// with white polka dots and a gold ribbon, a lid with a gold bow that lifts
// and tilts a little more on every tap, a wobbling gold "?" coin, and — per
// tap — a shake, a white shock ring, a word ("POP!", "WOBBLE!"…), three
// flying chips and one more glowing crack. Tapping too slowly makes it
// shake "no" (boxSad) and the cracks heal. On the 10th tap it squashes and
// vanishes (boxOpen) while the lid flies off.
//
// Everything is driven from props: `taps` (0–10), `phase` ('closed' |
// 'opening'), `draining`, and `shakeKey`, which changes on every tap.

const S = 210;
const LID_W = S - 32;
const WORDS = ['', 'POP!', 'WOBBLE!', 'SHAKE!', 'RATTLE!', 'FASTER!', 'KEEP GOING!', 'WOAH!', 'ALMOST!', 'ONE MORE!', 'OPEN!'];
// The design's crack paths, except that none may cross the "?" coin (a
// disc of radius ~34 around 105,136): the design's 3rd crack climbed from
// the bottom edge into the coin and its 8th ran right over the "?", so those
// two now zigzag across the box just above the coin instead (3rd, then 8th
// continuing it), and the 6th and 9th keep a little further off its edge.
const CRACKS = [
  'M40 94 L52 101 L47 111 L60 118',
  'M172 96 L161 106 L167 114 L154 124',
  'M68 97 L80 92 L90 99 L103 94',
  'M32 150 L48 146 L54 157 L69 151',
  'M178 160 L163 154 L159 166 L146 162',
  'M60 118 L69 128 L64 141',
  'M154 124 L146 136 L151 147',
  'M103 94 L114 100 L126 93 L140 99',
  'M69 151 L79 162 L76 174',
  'M146 162 L133 170 L138 184',
];
const CHIP_COLORS = ['#ff95d2', '#ffe066', '#ffb8e4'];
const LID_EASE = Easing.bezier(0.3, 1.6, 0.5, 1);
const CSS_EASE = Easing.bezier(0.25, 0.1, 0.25, 1);
const EASE_OUT = Easing.bezier(0, 0, 0.58, 1);
const EASE_IN = Easing.bezier(0.42, 0, 1, 1);
const EASE_IN_OUT = Easing.bezier(0.42, 0, 0.58, 1);

const AnimatedPath = Animated.createAnimatedComponent(Path);

function useLoop(ms, easing = EASE_IN_OUT) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(t, {
          toValue: 1,
          duration: ms / 2,
          easing,
          useNativeDriver: true,
        }),
        Animated.timing(t, {
          toValue: 0,
          duration: ms / 2,
          easing,
          useNativeDriver: true,
        }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [t, ms, easing]);
  return t;
}

// ---- behind the box: pulsing halo + three orbiting sparkles ----------------

const Halo = memo(function Halo() {
  const t = useLoop(1600);
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [0.9, 1.12] });
  const opacity = t.interpolate({
    inputRange: [0, 1],
    outputRange: [0.55, 0.95],
  });
  return (
    <Animated.View
      pointerEvents="none"
      style={[
        styles.center,
        {
          width: 260,
          height: 260,
          marginLeft: -130,
          marginTop: -130,
          opacity,
          transform: [{ scale }],
        },
      ]}
    >
      <Svg width={260} height={260}>
        <Defs>
          <RadialGradient id="boxHalo" cx="130" cy="130" r="184" gradientUnits="userSpaceOnUse">
            <Stop offset="0" stopColor="#ffffff" stopOpacity={1} />
            <Stop offset="0.3" stopColor="#ffe6a0" stopOpacity={0.7} />
            <Stop offset="0.5" stopColor="#ff78dc" stopOpacity={0.45} />
            <Stop offset="0.7" stopColor="#c89bff" stopOpacity={0} />
          </RadialGradient>
        </Defs>
        <Rect x={0} y={0} width={260} height={260} fill="url(#boxHalo)" />
      </Svg>
    </Animated.View>
  );
});

const Orbiter = memo(function Orbiter({ color, size, offset }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    t.setValue(offset);
    const first = Animated.timing(t, {
      toValue: 1,
      duration: 4000 * (1 - offset),
      easing: Easing.linear,
      useNativeDriver: true,
    });
    let loop;
    first.start(({ finished }) => {
      if (!finished) return;
      t.setValue(0);
      loop = Animated.loop(
        Animated.timing(t, {
          toValue: 1,
          duration: 4000,
          easing: Easing.linear,
          useNativeDriver: true,
        })
      );
      loop.start();
    });
    return () => {
      first.stop();
      loop && loop.stop();
    };
  }, [t, offset]);
  // rotate(a) translateX(122px) rotate(-a): circles the centre, stays upright
  const spin = t.interpolate({
    inputRange: [0, 1],
    outputRange: ['0deg', '360deg'],
  });
  const back = t.interpolate({
    inputRange: [0, 1],
    outputRange: ['0deg', '-360deg'],
  });
  return (
    <Animated.View
      pointerEvents="none"
      style={[
        styles.center,
        {
          transform: [{ rotate: spin }, { translateX: 122 }, { rotate: back }],
        },
      ]}
    >
      <Text
        renderToHardwareTextureAndroid
        style={[
          styles.orbitGlyph,
          {
            fontSize: size,
            color,
            lineHeight: size * 1.1,
            marginLeft: -8,
            marginTop: -10,
          },
        ]}
      >
        ✦
      </Text>
    </Animated.View>
  );
});

// ---- per-tap effects -----------------------------------------------------

// The shock ring and the word for each tap. Both stay mounted and just
// replay: the words (sticker titles, which measure themselves once) are all
// laid out up front, so the right one can pop the instant a tap lands.
function TapFx({ shakeKey, taps, active }) {
  const ring = useRef(new Animated.Value(1)).current;
  const words = useRef(WORDS.map(() => new Animated.Value(1))).current;
  useEffect(() => {
    if (!active || !taps) return;
    ring.setValue(0);
    Animated.timing(ring, {
      toValue: 1,
      duration: 550,
      easing: EASE_OUT,
      useNativeDriver: true,
    }).start();
    const w = words[taps];
    if (!w) return;
    w.setValue(0);
    Animated.timing(w, {
      toValue: 1,
      duration: 700,
      easing: EASE_OUT,
      useNativeDriver: true,
    }).start();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [shakeKey]);
  const look = useMemo(
    () => ({
      ring: {
        opacity: ring.interpolate({
          inputRange: [0, 1],
          outputRange: [0.9, 0],
        }),
        transform: [
          {
            scale: ring.interpolate({
              inputRange: [0, 1],
              outputRange: [0.2, 1.6],
            }),
          },
        ],
      },
      // translate(-50%, -50%) → translate(-50%, -130%) of its own height,
      // growing 0.4 → 1.3 while it fades
      words: words.map((w) => ({
        opacity: w.interpolate({ inputRange: [0, 1], outputRange: [1, 0] }),
        transform: [
          {
            translateY: w.interpolate({
              inputRange: [0, 1],
              outputRange: [0, -0.8 * 44],
            }),
          },
          {
            scale: w.interpolate({
              inputRange: [0, 1],
              outputRange: [0.4, 1.3],
            }),
          },
        ],
      })),
    }),
    [ring, words]
  );
  return (
    <View pointerEvents="none" style={[styles.center, { zIndex: 3 }]}>
      <Animated.View style={[styles.shock, look.ring]} />
      {WORDS.map((word, i) =>
        word ? (
          <Animated.View key={word} style={[styles.word, look.words[i]]}>
            <OutlinedTitle text={word} fill="gold" size={30} />
          </Animated.View>
        ) : null
      )}
    </View>
  );
}

function Chip({ x, y, s, c, dx, dy }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.timing(t, {
      toValue: 1,
      duration: 600,
      easing: Easing.bezier(0.2, 0.7, 0.4, 1),
      useNativeDriver: true,
    }).start();
  }, [t]);
  const tx = t.interpolate({ inputRange: [0, 1], outputRange: [0, dx] });
  const ty = t.interpolate({ inputRange: [0, 1], outputRange: [0, dy] });
  const rot = t.interpolate({
    inputRange: [0, 1],
    outputRange: ['0deg', '260deg'],
  });
  const opacity = t.interpolate({ inputRange: [0, 1], outputRange: [1, 0] });
  // polygon(50% 0, 100% 40%, 75% 100%, 10% 85%, 0 30%), white edge, pink ring
  const pts = [
    [0.5, 0],
    [1, 0.4],
    [0.75, 1],
    [0.1, 0.85],
    [0, 0.3],
  ]
    .map(([px, py]) => `${2 + px * s},${2 + py * s}`)
    .join(' ');
  return (
    <Animated.View
      pointerEvents="none"
      style={{
        position: 'absolute',
        left: x - 2,
        top: y - 2,
        opacity,
        transform: [{ translateX: tx }, { translateY: ty }, { rotate: rot }],
      }}
    >
      <Svg width={s + 4} height={s + 4}>
        <Polygon points={pts} fill={c} stroke="#8e1580" strokeWidth={5} strokeLinejoin="round" />
        <Polygon points={pts} fill={c} stroke="#ffffff" strokeWidth={2} strokeLinejoin="round" />
      </Svg>
    </Animated.View>
  );
}

function chipsFor(shakeKey) {
  return [0, 1, 2].map((j) => {
    const k = shakeKey * 3 + j;
    const a = (((k * 137) % 360) * Math.PI) / 180;
    const d = 50 + ((k * 29) % 40);
    return {
      key: `${shakeKey}-${j}`,
      x: 95 + Math.round(Math.cos(a) * 40),
      y: 125 + Math.round(Math.sin(a) * 30),
      s: 7 + (k % 3) * 3,
      c: CHIP_COLORS[k % 3],
      dx: Math.round(Math.cos(a) * d),
      dy: Math.round(Math.sin(a) * d) - 20,
    };
  });
}

// One crack, drawn in over 0.22s the moment it appears.
function Crack({ d, glow }) {
  const t = useRef(new Animated.Value(140)).current;
  useEffect(() => {
    Animated.timing(t, {
      toValue: 0,
      duration: 220,
      easing: EASE_OUT,
      useNativeDriver: false,
    }).start();
  }, [t]);
  return (
    <>
      <AnimatedPath
        d={d}
        fill="none"
        stroke="#6a1b9a"
        strokeWidth={5}
        strokeLinecap="round"
        strokeLinejoin="round"
        strokeDasharray="140"
        strokeDashoffset={t}
      />
      <AnimatedPath
        d={d}
        fill="none"
        stroke="#ffd84a"
        strokeOpacity={0.55}
        strokeWidth={2 + glow}
        strokeLinecap="round"
        strokeLinejoin="round"
        strokeDasharray="140"
        strokeDashoffset={t}
      />
      <AnimatedPath
        d={d}
        fill="none"
        stroke="#fff6c0"
        strokeWidth={2}
        strokeLinecap="round"
        strokeLinejoin="round"
        strokeDasharray="140"
        strokeDashoffset={t}
      />
    </>
  );
}

// ---- the box art ---------------------------------------------------------

const PolkaBase = memo(function PolkaBase() {
  return (
    <View style={styles.baseRim}>
      <LinearGradient colors={['#ffb8e4', '#ff7cc6']} style={styles.baseFace}>
        <View
          style={[
            styles.dot,
            {
              left: '20%',
              top: '30%',
              width: 12,
              height: 12,
              marginLeft: -6,
              marginTop: -6,
            },
          ]}
        />
        <View
          style={[
            styles.dot,
            {
              left: '70%',
              top: '60%',
              width: 14,
              height: 14,
              marginLeft: -7,
              marginTop: -7,
            },
          ]}
        />
        <View
          style={[
            styles.dot,
            {
              left: '40%',
              top: '80%',
              width: 10,
              height: 10,
              marginLeft: -5,
              marginTop: -5,
            },
          ]}
        />
        <View style={styles.baseTopBand} />
      </LinearGradient>
    </View>
  );
});

function Ribbon({ style }) {
  return <View style={[styles.ribbon, style]} />;
}

// The design's egg-shaped bow loop (border-radius 50% / 60% 60% 40% 40%):
// a 40×30 gold loop in a 4px white border and a 2.5px ring. SVG, since a
// View's corner radius can't be elliptical.
function egg(x, y, w, h) {
  const rx = w / 2;
  const top = h * 0.6;
  const bot = h * 0.4;
  return `M${x} ${y + top} A${rx} ${top} 0 0 1 ${x + rx} ${y} A${rx} ${top} 0 0 1 ${x + w} ${y + top} A${rx} ${bot} 0 0 1 ${x + rx} ${y + h} A${rx} ${bot} 0 0 1 ${x} ${y + top} Z`;
}
const BOW_W = 40 + 8 + 5;
const BOW_H = 30 + 8 + 5;
const BOW_RING = egg(0, 0, BOW_W, BOW_H);
const BOW_WHITE = egg(2.5, 2.5, 48, 38);
const BOW_GOLD = egg(6.5, 6.5, 40, 30);

const BowLoop = memo(function BowLoop({ left, rotate }) {
  return (
    <View
      style={{
        position: 'absolute',
        left: left - 2.5,
        top: -26 - 2.5,
        width: BOW_W,
        height: BOW_H,
        transform: [{ rotate }],
      }}
    >
      <Svg width={BOW_W} height={BOW_H}>
        <Path d={BOW_RING} fill="#8e1580" />
        <Path d={BOW_WHITE} fill="#ffffff" />
        <Path d={BOW_GOLD} fill="#ffe066" />
      </Svg>
    </View>
  );
});

const QuestionCoin = memo(function QuestionCoin() {
  const t = useLoop(1400);
  const rotate = t.interpolate({
    inputRange: [0, 1],
    outputRange: ['-3deg', '3deg'],
  });
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [1, 1.05] });
  return (
    <Animated.View style={[styles.coinWrap, { transform: [{ rotate }, { scale }] }]}>
      <View style={styles.coinLip} />
      <View style={styles.coinRing}>
        <View style={styles.coinRim}>
          <Svg width={54} height={54} style={StyleSheet.absoluteFill}>
            <Defs>
              <RadialGradient id="qCoin" cx="35%" cy="28%" r="80%">
                <Stop offset="0" stopColor="#fffbe0" />
                <Stop offset="0.35" stopColor="#ffe45c" />
                <Stop offset="0.65" stopColor="#ffc21a" />
                <Stop offset="1" stopColor="#e08a00" />
              </RadialGradient>
            </Defs>
            <Circle cx={27} cy={27} r={40} fill="url(#qCoin)" />
          </Svg>
          <Shine inset="14%" height="40%" />
          <OutlinedTitle text="?" fill="pink" size={34} outline={2} ring={1.5} drop={0} letterSpacing={0} style={styles.qMark} />
        </View>
      </View>
    </Animated.View>
  );
});

function GiftBox({ taps, phase, draining, shakeKey, drainKey, onPress }) {
  const opening = phase === 'opening';

  const bob = useLoop(2400);
  const bobY = useMemo(() => bob.interpolate({ inputRange: [0, 1], outputRange: [0, -8] }), [bob]);

  // boxShake, once per tap
  const shake = useRef(new Animated.Value(1)).current;
  useEffect(() => {
    if (!taps || draining || opening) return;
    shake.setValue(0);
    Animated.timing(shake, {
      toValue: 1,
      duration: 450,
      easing: EASE_OUT,
      useNativeDriver: true,
    }).start();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [shakeKey]);
  const shakeT = useMemo(
    () => [
      {
        rotate: shake.interpolate({
          inputRange: [0, 0.2, 0.45, 0.7, 1],
          outputRange: ['0deg', '-9deg', '8deg', '-4deg', '0deg'],
        }),
      },
      {
        scaleX: shake.interpolate({
          inputRange: [0, 0.2, 0.45, 0.7, 1],
          outputRange: [1, 1.04, 0.97, 1, 1],
        }),
      },
      {
        scaleY: shake.interpolate({
          inputRange: [0, 0.2, 0.45, 0.7, 1],
          outputRange: [1, 0.96, 1.04, 1, 1],
        }),
      },
    ],
    [shake]
  );

  // boxSad when the taps run out
  const sad = useRef(new Animated.Value(1)).current;
  useEffect(() => {
    if (!draining) return;
    sad.setValue(0);
    Animated.timing(sad, {
      toValue: 1,
      duration: 500,
      easing: EASE_OUT,
      useNativeDriver: true,
    }).start();
  }, [draining, drainKey, sad]);
  const sadT = useMemo(
    () => [
      {
        translateX: sad.interpolate({
          inputRange: [0, 0.2, 0.4, 0.6, 0.8, 1],
          outputRange: [0, -8, 8, -5, 4, 0],
        }),
      },
      {
        rotate: sad.interpolate({
          inputRange: [0, 0.2, 0.4, 0.6, 1],
          outputRange: ['0deg', '-3deg', '3deg', '0deg', '0deg'],
        }),
      },
    ],
    [sad]
  );

  // boxOpen: squash, then shrink away
  const open = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!opening) {
      open.setValue(0);
      return undefined;
    }
    const a = Animated.sequence([
      Animated.delay(200),
      Animated.timing(open, {
        toValue: 1,
        duration: 650,
        easing: EASE_IN,
        useNativeDriver: true,
      }),
    ]);
    a.start();
    return () => a.stop();
  }, [opening, open]);
  const openStyle = useMemo(
    () => ({
      opacity: open.interpolate({ inputRange: [0, 1], outputRange: [1, 0] }),
      transform: [
        {
          scaleX: open.interpolate({
            inputRange: [0, 0.4, 1],
            outputRange: [1, 1.15, 0.2],
          }),
        },
        {
          scaleY: open.interpolate({
            inputRange: [0, 0.4, 1],
            outputRange: [1, 0.85, 0.2],
          }),
        },
      ],
    }),
    [open]
  );

  // the lid lifts (overshooting) and tilts a little more each tap
  const lidTop = opening ? -60 : draining ? 40 : 40 - taps * 1.8;
  const lidRot = opening ? -24 : draining ? 0 : taps ? (taps % 2 ? -1 : 1) * (3 + taps * 1.3) : 0;
  const lidY = useRef(new Animated.Value(0)).current;
  const lidR = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.parallel([
      Animated.timing(lidY, {
        toValue: lidTop - 40,
        duration: 450,
        easing: LID_EASE,
        useNativeDriver: true,
      }),
      Animated.timing(lidR, {
        toValue: lidRot,
        duration: 450,
        easing: CSS_EASE,
        useNativeDriver: true,
      }),
    ]).start();
  }, [lidTop, lidRot, lidY, lidR]);
  const lidT = useMemo(
    () => [
      { translateY: lidY },
      {
        rotate: lidR.interpolate({
          inputRange: [-360, 360],
          outputRange: ['-360deg', '360deg'],
        }),
      },
    ],
    [lidY, lidR]
  );

  // inner glow builds up from the 4th tap
  const glowTo = opening ? 1 : draining ? 0 : Math.max(0, (taps - 3) / 7) * 0.85;
  const glow = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.timing(glow, {
      toValue: glowTo,
      duration: 250,
      easing: CSS_EASE,
      useNativeDriver: true,
    }).start();
  }, [glowTo, glow]);

  const crackCount = opening ? 10 : draining ? 0 : taps;
  const crackGlow = 2 + crackCount * 0.6;
  const showFx = taps > 0 && !opening && !draining;

  return (
    <View style={styles.wrap}>
      <Halo />
      <Orbiter color="#ffc233" size={18} offset={0} />
      <Orbiter color="#ff6fbd" size={14} offset={1 / 3} />
      <Orbiter color="#7cc8ff" size={16} offset={2 / 3} />
      <TapFx shakeKey={shakeKey} taps={taps} active={showFx} />

      <Pressable onPressIn={onPress} style={styles.box}>
        <Animated.View style={[styles.fill, { transform: [{ translateY: bobY }] }]}>
          <Animated.View style={[styles.fill, { transform: sadT }]}>
            <Animated.View style={[styles.fill, { transform: shakeT }]}>
              <Animated.View style={[styles.fill, openStyle]}>
                <Svg width={170} height={18} style={styles.shadow}>
                  <Ellipse cx={85} cy={9} rx={85} ry={9} fill="rgba(107,63,160,0.18)" />
                </Svg>
                <PolkaBase />
                <Ribbon style={{ top: 74, bottom: 22 }} />
                <Animated.View style={[styles.lid, { transform: lidT }]}>
                  <LinearGradient colors={['#ffd0ee', '#ff95d2']} style={styles.lidFace}>
                    <View style={styles.lidTopBand} />
                  </LinearGradient>
                  <Ribbon style={{ left: LID_W / 2 - 13, top: 0, bottom: 0 }} />
                  <BowLoop left={LID_W / 2 - 44} rotate="-18deg" />
                  <BowLoop left={LID_W / 2 + 4} rotate="18deg" />
                  <View style={styles.knotRing}>
                    <View style={styles.knot} />
                  </View>
                </Animated.View>
                <QuestionCoin />
                <Animated.View pointerEvents="none" style={[styles.innerGlow, { opacity: glow }]}>
                  <Svg width={146} height={106}>
                    <Defs>
                      <RadialGradient id="boxInnerGlow" cx="73" cy="58.3" r="93.4" gradientUnits="userSpaceOnUse">
                        <Stop offset="0" stopColor="#fff6be" stopOpacity={0.95} />
                        <Stop offset="0.35" stopColor="#ffd25a" stopOpacity={0.5} />
                        <Stop offset="0.7" stopColor="#ffd25a" stopOpacity={0} />
                      </RadialGradient>
                    </Defs>
                    <Path d="M18 0 H128 A18 18 0 0 1 146 18 V88 A18 18 0 0 1 128 106 H18 A18 18 0 0 1 0 88 V18 A18 18 0 0 1 18 0 Z" fill="url(#boxInnerGlow)" />
                  </Svg>
                </Animated.View>
                <Svg width={S} height={S} style={StyleSheet.absoluteFill} pointerEvents="none">
                  {CRACKS.slice(0, crackCount).map((d, i) => (
                    <Crack key={`${drainKey}-${i}`} d={d} glow={crackGlow} />
                  ))}
                </Svg>
                {showFx ? chipsFor(shakeKey).map((ch) => <Chip {...ch} key={ch.key} />) : null}
              </Animated.View>
            </Animated.View>
          </Animated.View>
        </Animated.View>
      </Pressable>
    </View>
  );
}

export default memo(GiftBox);
export const GIFT_SIZE = S;

const styles = StyleSheet.create({
  wrap: { width: S, height: S, alignItems: 'center', justifyContent: 'center' },
  center: {
    position: 'absolute',
    left: S / 2,
    top: S / 2 - 15,
    width: 0,
    height: 0,
  },
  orbitGlyph: { position: 'absolute', includeFontPadding: false },
  box: { width: S, height: S },
  fill: { ...StyleSheet.absoluteFillObject },
  shock: {
    position: 'absolute',
    left: -120,
    top: -120,
    width: 240,
    height: 240,
    borderRadius: 120,
    borderWidth: 6,
    borderColor: '#ffffff',
    shadowColor: '#ff9fd6',
    shadowOpacity: 1,
    shadowRadius: 18,
  },
  word: {
    position: 'absolute',
    left: -150,
    width: 300,
    top: -90 - 22,
    alignItems: 'center',
  },
  shadow: { position: 'absolute', left: S / 2 - 85, bottom: 6 },
  baseRim: {
    position: 'absolute',
    left: 28,
    right: 28,
    top: 74,
    bottom: 22,
    borderRadius: 22,
    backgroundColor: '#ffffff',
    padding: 4,
  },
  baseFace: { flex: 1, borderRadius: 18, overflow: 'hidden' },
  baseTopBand: {
    position: 'absolute',
    left: 0,
    right: 0,
    top: 0,
    height: 8,
    backgroundColor: 'rgba(255,255,255,0.45)',
  },
  dot: { position: 'absolute', borderRadius: 999, backgroundColor: '#ffffff' },
  ribbon: {
    position: 'absolute',
    left: S / 2 - 13,
    width: 26,
    backgroundColor: '#ffe066',
    borderLeftWidth: 3,
    borderRightWidth: 3,
    borderColor: '#ffffff',
  },
  lid: {
    position: 'absolute',
    left: 16,
    right: 16,
    top: 40,
    height: 48,
    borderRadius: 18,
    backgroundColor: '#ffffff',
    padding: 4,
  },
  lidFace: { flex: 1, borderRadius: 14, overflow: 'hidden' },
  lidTopBand: {
    position: 'absolute',
    left: 0,
    right: 0,
    top: 0,
    height: 6,
    backgroundColor: 'rgba(255,255,255,0.55)',
  },
  knotRing: {
    position: 'absolute',
    left: LID_W / 2 - 10 - 2.5,
    top: -14 - 2.5,
    width: 25,
    height: 25,
    borderRadius: 13,
    backgroundColor: '#8e1580',
    padding: 2.5,
  },
  knot: {
    flex: 1,
    borderRadius: 10,
    backgroundColor: '#ffcf33',
    borderWidth: 4,
    borderColor: '#ffffff',
  },
  coinWrap: {
    position: 'absolute',
    left: S / 2 - 30,
    top: 106,
    width: 60,
    height: 60,
  },
  coinLip: {
    position: 'absolute',
    left: -2,
    right: -2,
    top: 2,
    bottom: -6,
    borderRadius: 32,
    backgroundColor: '#a0520a',
  },
  coinRing: {
    position: 'absolute',
    left: -2,
    top: -2,
    right: -2,
    bottom: -2,
    borderRadius: 32,
    backgroundColor: '#a0520a',
    padding: 2,
    shadowColor: '#ffdc5a',
    shadowOpacity: 0.9,
    shadowRadius: 18,
  },
  coinRim: {
    flex: 1,
    borderRadius: 30,
    borderWidth: 3,
    borderColor: '#ffffff',
    overflow: 'hidden',
    alignItems: 'center',
    justifyContent: 'center',
  },
  qMark: { marginTop: 2 },
  innerGlow: { position: 'absolute', left: 32, top: 78 },
});
