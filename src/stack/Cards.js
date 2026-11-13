import React, { useEffect, useState } from 'react';
import { StyleSheet, Text, View } from 'react-native';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import { CoinIcon } from '../squad/ui';
import sfx from '../audio/sfx';
import { CountUp, PopIn, Rock, SlideIn } from '../squishdoku/fx';
import { Overlay, XpGain, XpPlus } from '../squishdoku/Overlays';
import { BtnLabel, Head, SdButton } from '../squishdoku/ui';
import { F, INK } from '../squishdoku/theme';
import { Star } from '../sort/Cards';
import { BLITZ_ROUNDS, CLOCK_FROM, PICTURE_FROM, TIER_NAMES } from './levels';

// Squish Stack's cards over the game: the win (stars popping in one by one,
// coins counting up), time's up, pause, the hint offer, and how to play.

const TITLES = ['', 'STACKED!', 'NICE STACKING!', 'PERFECT STACK!'];
const STEP = 480;

// res: { stars, coins, xp, before, after, levelUps, moves, par, hinted,
// unlocked }; `last`: level 50, no NEXT
export function ResultCard({ visible, res, spec, last, onNext, onReplay, onHub }) {
  const [key, setKey] = useState(0);
  useEffect(() => {
    if (!visible || !res) return undefined;
    setKey((k) => k + 1);
    const timers = [0, 1, 2].map((i) => setTimeout(() => sfx.play(i < res.stars ? `sd_star${i + 1}` : 'sd_starEmpty'), 380 + i * STEP));
    if (res.stars === 3) timers.push(setTimeout(() => sfx.play('sd_perfect'), 380 + 3 * STEP));
    return () => timers.forEach(clearTimeout);
  }, [visible, res]);
  if (!res) return <Overlay visible={false} />;
  const coinsAt = 380 + 3 * STEP + 200;
  return (
    <Overlay visible={visible}>
      <PopIn trigger={key} delay={80}>
        <OutlinedTitle text={TITLES[res.stars]} size={res.stars === 3 ? 27 : 30} fill={res.stars === 3 ? 'gold' : 'pink'} />
      </PopIn>
      <Text style={styles.sub}>{`LEVEL ${spec.lv} · ${TIER_NAMES[spec.tier]} · ${res.moves} MOVES · PAR ${res.par}${res.hinted ? ' · HINT' : ''}`}</Text>
      {res.stars < 3 && !res.hinted ? <Text style={styles.hint}>{`Do it in ${res.par} moves for 3 stars!`}</Text> : null}
      {res.hinted ? <Text style={styles.hint}>A hint costs one star</Text> : null}
      <View key={key} style={styles.stars}>
        {[0, 1, 2].map((i) => (
          <Star key={i} earned={i < res.stars} delay={380 + i * STEP} big={i === 1} />
        ))}
      </View>
      <SlideIn trigger={key} delay={coinsAt - 150} dy={20} style={styles.rewardRow}>
        <CoinIcon size={26} />
        <CountUp value={res.coins} delay={coinsAt} ms={800} style={styles.coins} prefix="+" onTick={() => sfx.play('sd_coinTick')} />
        <XpPlus xp={res.xp} />
      </SlideIn>
      <XpGain trigger={key} res={res} delay={coinsAt + 500} />
      {res.unlocked ? (
        <PopIn trigger={key} delay={coinsAt + 500}>
          <Text style={styles.unlocked}>{`LEVEL ${spec.lv + 1} UNLOCKED`}</Text>
        </PopIn>
      ) : null}
      <SlideIn trigger={key} delay={380 + 2 * STEP + 300} dy={30} style={styles.btnRow}>
        <SdButton kind="white" onPress={onHub} sound="sd_select" faceStyle={styles.smallFace}>
          <BtnLabel kind="purple" size={15}>
            MENU
          </BtnLabel>
        </SdButton>
        <SdButton kind="purple" onPress={onReplay} sound="sd_select" faceStyle={styles.smallFace}>
          <BtnLabel kind="purple" size={15}>
            REPLAY
          </BtnLabel>
        </SdButton>
        {!last ? (
          <SdButton kind="green" onPress={onNext} sound="sd_select" faceStyle={styles.bigFace}>
            <BtnLabel kind="green" size={18}>
              NEXT ▶
            </BtnLabel>
          </SdButton>
        ) : null}
      </SlideIn>
    </Overlay>
  );
}

// The clock ran out.
export function FailCard({ visible, uri, onRetry, onHub }) {
  return (
    <Overlay visible={visible} tint="rgba(80,0,30,0.5)">
      <PopIn trigger={visible} delay={60}>
        <OutlinedTitle text="TIME'S UP!" size={32} fill="pink" />
      </PopIn>
      <PopIn trigger={visible} delay={220}>
        <Rock deg={8} ms={1800}>
          <Head uri={uri} size={86} dim ring="#ffffff" bg="#efe9f5" />
        </Rock>
      </PopIn>
      <Text style={styles.body}>The clock ran out before the stack was done. Try again!</Text>
      <SlideIn trigger={visible} delay={380} style={styles.btnRow}>
        <SdButton kind="white" onPress={onHub} sound="sd_select" faceStyle={styles.smallFace}>
          <BtnLabel kind="purple" size={15}>
            MENU
          </BtnLabel>
        </SdButton>
        <SdButton kind="pink" onPress={onRetry} sound="sd_select" faceStyle={styles.bigFace}>
          <BtnLabel kind="pink" size={18}>
            RETRY
          </BtnLabel>
        </SdButton>
      </SlideIn>
    </Overlay>
  );
}

export function PauseCard({ visible, clock, onResume, onRestart, onQuit }) {
  return (
    <Overlay visible={visible}>
      <OutlinedTitle text="PAUSED" size={30} fill="pink" />
      {clock ? <Text style={styles.body}>The clock is stopped.</Text> : null}
      <View style={styles.col}>
        <SdButton kind="green" onPress={onResume} sound="sd_resume" faceStyle={styles.wideFace}>
          <BtnLabel kind="green" size={18}>
            RESUME
          </BtnLabel>
        </SdButton>
        <SdButton kind="purple" onPress={onRestart} sound="sd_select" faceStyle={styles.wideFace}>
          <BtnLabel kind="purple" size={16}>
            NEW PUZZLE
          </BtnLabel>
        </SdButton>
        <SdButton kind="white" onPress={onQuit} sound="sd_boardOut" faceStyle={styles.wideFace}>
          <BtnLabel kind="purple" size={16}>
            QUIT
          </BtnLabel>
        </SdButton>
      </View>
    </Overlay>
  );
}

// A hint costs an ad (free with Remove Ads) and one star off this level
// (the user, 2026-10-24). Asked the first time in a level only.
export function HintCard({ visible, adReady, adsFree, onWatch, onClose }) {
  return (
    <Overlay visible={visible}>
      <OutlinedTitle text="NEED A HINT?" size={28} fill="gold" />
      <Text style={styles.body}>{adsFree ? "We'll show you the next best move." : "Watch a short ad and we'll show you the next best move."}</Text>
      <Text style={styles.cost}>This level gives one star less</Text>
      <View style={styles.col}>
        <SdButton kind="gold" onPress={onWatch} disabled={!adsFree && !adReady} sound="sd_select" faceStyle={styles.wideFace}>
          <BtnLabel kind="gold" size={17}>{adsFree ? 'SHOW ME' : adReady ? '▶ WATCH AD' : 'LOADING AD…'}</BtnLabel>
        </SdButton>
        <SdButton kind="white" onPress={onClose} sound="sd_select" faceStyle={styles.wideFace}>
          <BtnLabel kind="purple" size={15}>
            NO THANKS
          </BtnLabel>
        </SdButton>
      </View>
    </Overlay>
  );
}

const RULES = [
  ['1', 'Lift', "Tap a cushion to lift the squishy on top. Or drag it."],
  ['2', 'Stack', 'Tap another cushion to put it there. A big squishy can never sit on a smaller one!'],
  ['3', 'Goal', 'Get everyone onto the ★ cushion, or make the cushions look like the GOAL card.'],
  ['★', 'Par', 'Use the fewest moves there are for 3 stars. The meter shows what you can still get.'],
];
const LATER = [
  ['GOAL CARD', `From level ${PICTURE_FROM}: match a picture, not just one tower.`],
  ['CLOCK', `From level ${CLOCK_FROM}: finish before the time runs out.`],
  ['4 CUSHIONS', 'Later on, an extra cushion and more squishies.'],
];

export function RulesCard({ visible, onClose }) {
  return (
    <Overlay visible={visible}>
      <OutlinedTitle text="HOW TO PLAY" size={26} fill="pink" />
      <View style={styles.rules}>
        {RULES.map(([n, title, line]) => (
          <View key={title} style={styles.rule}>
            <View style={styles.ruleNum}>
              <Text style={styles.ruleNumText}>{n}</Text>
            </View>
            <View style={{ flex: 1 }}>
              <Text style={styles.ruleTitle}>{title}</Text>
              <Text style={styles.ruleLine}>{line}</Text>
            </View>
          </View>
        ))}
      </View>
      <Text style={styles.twistHead}>LATER LEVELS ADD</Text>
      {LATER.map(([name, line]) => (
        <Text key={name} style={styles.twist}>
          <Text style={styles.twistName}>{`${name}  `}</Text>
          {line}
        </Text>
      ))}
      <Text style={styles.twist}>
        <Text style={styles.twistName}>{'HINT  '}</Text>
        Shows the next best move, for an ad and one star.
      </Text>
      <Text style={styles.twist}>
        <Text style={[styles.twistName, { color: '#0c5a9c' }]}>{'BLITZ ⚡  '}</Text>
        {`${BLITZ_ROUNDS} puzzles on one clock. Drop a big one on a smaller one and it's back to puzzle 1 (one revive per run).`}
      </Text>
      <SdButton kind="green" onPress={onClose} sound="sd_select" faceStyle={styles.bigFace} style={{ marginTop: 8 }}>
        <BtnLabel kind="green" size={18}>
          GOT IT!
        </BtnLabel>
      </SdButton>
    </Overlay>
  );
}

const styles = StyleSheet.create({
  sub: { fontFamily: F.display, fontSize: 12, letterSpacing: 0.6, color: '#8a5fc0', textAlign: 'center' },
  hint: { fontFamily: F.heavy, fontSize: 11.5, color: '#b86200', textAlign: 'center' },
  stars: { flexDirection: 'row', alignItems: 'center', justifyContent: 'center', marginTop: 4, marginBottom: 8 },
  rewardRow: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  coins: { fontFamily: F.display, fontSize: 28, color: '#b86200', includeFontPadding: false, minWidth: 70 },
  unlocked: { fontFamily: F.display, fontSize: 13, color: '#16a86a', letterSpacing: 0.8 },
  btnRow: { flexDirection: 'row', alignItems: 'flex-start', justifyContent: 'center', gap: 8, marginTop: 6 },
  col: { alignSelf: 'stretch', gap: 4, marginTop: 6 },
  smallFace: { paddingHorizontal: 14, paddingVertical: 10 },
  bigFace: { paddingHorizontal: 22, paddingVertical: 12 },
  wideFace: { paddingVertical: 12 },
  body: { fontFamily: F.heavy, fontSize: 14, color: INK, textAlign: 'center', paddingHorizontal: 6 },
  cost: { fontFamily: F.display, fontSize: 13, color: '#e01e4a', textAlign: 'center' },
  rules: { alignSelf: 'stretch', gap: 8, marginTop: 4 },
  rule: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  ruleNum: { width: 30, height: 30, borderRadius: 15, backgroundColor: '#ff5cc6', borderWidth: 2.5, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  ruleNumText: { fontFamily: F.display, fontSize: 15, color: '#ffffff', includeFontPadding: false },
  ruleTitle: { fontFamily: F.display, fontSize: 15, color: '#8e1580' },
  ruleLine: { fontFamily: F.heavy, fontSize: 12, lineHeight: 16, color: INK },
  twistHead: { marginTop: 6, fontFamily: F.display, fontSize: 12, letterSpacing: 1, color: '#8a5fc0' },
  twist: { alignSelf: 'stretch', fontFamily: F.heavy, fontSize: 11.5, lineHeight: 15.5, color: INK },
  twistName: { fontFamily: F.display, fontSize: 11.5, color: '#e01e4a' },
});
