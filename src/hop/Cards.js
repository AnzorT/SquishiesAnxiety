import React, { useEffect, useState } from 'react';
import { Image, StyleSheet, Text, View } from 'react-native';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import { CoinIcon } from '../squad/ui';
import sfx from '../audio/sfx';
import { CountUp, PopIn, Rock, SlideIn } from '../squishdoku/fx';
import { Overlay, XpGain, XpPlus } from '../squishdoku/Overlays';
import { BtnLabel, Head, SdButton } from '../squishdoku/ui';
import { F, INK } from '../squishdoku/theme';
import { Star } from '../sort/Cards';
import { LEVELS, ROOMS, TIER_NAMES, TWISTS } from './levels';

// Squish Hop's cards over the game (SQUISH_HOP.md): the win (stars popping in
// one by one, coins counting up), STUCK, pause, the hint offer, and how to
// play. Squish Stack's cards, with this game's words.

const TITLES = ['', 'HOPPED!', 'NICE HOPPING!', 'ALL CLEAR!'];
const STEP = 480;

// res: { stars, coins, xp, before, after, levelUps, hops, left, hinted,
// unlocked }; `next`: the next level's room (null on the last level)
export function ResultCard({ visible, res, spec, nextRoom, onNext, onReplay, onHub }) {
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
  const what = ROOMS[spec.room].dance ? 'tile' : 'cushion';
  const last = spec.lv >= LEVELS;
  return (
    <Overlay visible={visible}>
      <PopIn trigger={key} delay={80}>
        <OutlinedTitle text={TITLES[res.stars]} size={res.stars === 3 ? 30 : 28} fill={res.stars === 3 ? 'gold' : 'pink'} />
      </PopIn>
      <Text style={styles.sub}>{`LEVEL ${spec.lv} · ${TIER_NAMES[spec.tier]} · ${res.hops} HOPS · ${res.left} LEFT${res.hinted ? ' · HINT' : ''}`}</Text>
      {res.left > 0 && !res.hinted ? <Text style={styles.hint}>{`Clear every ${what} before the ★ for 3 stars!`}</Text> : null}
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
      <PopIn trigger={key} delay={coinsAt + 500}>
        <Text style={styles.unlocked}>{last ? 'YOU HOPPED THROUGH THE WHOLE CRIB!' : res.unlocked ? `LEVEL ${spec.lv + 1} UNLOCKED · ${(nextRoom || '').toUpperCase()}` : `NEXT: LEVEL ${spec.lv + 1} · ${(nextRoom || '').toUpperCase()}`}</Text>
      </PopIn>
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

// Nowhere left to hop. `head`: the hopper's sad head (squishdoku/heads.js),
// or `uri` its still; `shut`: the ★ is next to it but still shut.
export function StuckCard({ visible, head, uri, shut, onUndo, onRetry }) {
  return (
    <Overlay visible={visible} tint="rgba(80,0,30,0.5)">
      <PopIn trigger={visible} delay={60}>
        <OutlinedTitle text="STUCK!" size={32} fill="pink" />
      </PopIn>
      <PopIn trigger={visible} delay={220}>
        <Rock deg={8} ms={1800}>
          {head ? (
            <View style={styles.sadHead}>
              <View style={styles.sadInner}>
                <Image source={head} fadeDuration={0} style={styles.sadImg} />
              </View>
            </View>
          ) : (
            <Head uri={uri} size={86} dim ring="#ffffff" bg="#efe9f5" />
          )}
        </Rock>
      </PopIn>
      <Text style={styles.body}>{shut ? 'The ★ is shut until every friend is with you, and there is nowhere else to hop.' : 'There is nowhere left to hop.'}</Text>
      <SlideIn trigger={visible} delay={380} style={styles.btnRow}>
        <SdButton kind="white" onPress={onUndo} sound="sd_select" faceStyle={styles.smallFace}>
          <BtnLabel kind="purple" size={15}>
            UNDO
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

export function PauseCard({ visible, onResume, onRestart, onQuit }) {
  return (
    <Overlay visible={visible}>
      <OutlinedTitle text="PAUSED" size={30} fill="pink" />
      <View style={styles.col}>
        <SdButton kind="green" onPress={onResume} sound="sd_resume" faceStyle={styles.wideFace}>
          <BtnLabel kind="green" size={18}>
            RESUME
          </BtnLabel>
        </SdButton>
        <SdButton kind="purple" onPress={onRestart} sound="sd_select" faceStyle={styles.wideFace}>
          <BtnLabel kind="purple" size={16}>
            RESTART
          </BtnLabel>
        </SdButton>
        <SdButton kind="white" onPress={onQuit} sound="sd_boardOut" faceStyle={styles.wideFace}>
          <BtnLabel kind="purple" size={16}>
            LEVELS
          </BtnLabel>
        </SdButton>
      </View>
    </Overlay>
  );
}

// A hint costs an ad (free with Remove Ads) and one star off this level, like
// Squish Stack's. Asked the first time in a level only.
export function HintCard({ visible, adReady, adsFree, onWatch, onClose }) {
  return (
    <Overlay visible={visible}>
      <OutlinedTitle text="NEED A HINT?" size={28} fill="gold" />
      <Text style={styles.body}>{adsFree ? "We'll show you the next hop." : "Watch a short ad and we'll show you the next hop."}</Text>
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
  ['1', 'Hop', 'Swipe, or tap a cushion next to you. A long swipe can turn corners.'],
  ['2', 'Puff!', 'The cushion you hop off puffs away. No going back!'],
  ['3', 'The ★', 'Hop onto it to finish. Clear every other cushion first for 3 stars.'],
];
const ROOM_ORDER = ['friends', 'arrows', 'bubbles', 'piles', 'ordered', 'beats'];
const LINES = {
  friends: 'pick them all up. The ★ opens when everyone is with you.',
  arrows: 'you can only hop off an arrow cushion the way it points.',
  bubbles: 'land on a bubble and it bounces you one cushion further.',
  piles: 'two cushions on top of each other take two hops.',
  ordered: 'numbered friends are picked up 1, 2, 3…',
  beats: 'in the Dance Room, coloured tiles light up every third hop. Land on them lit.',
};

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
      <Text style={styles.twistHead}>ROOM BY ROOM</Text>
      {ROOM_ORDER.map((k) => (
        <Text key={k} style={styles.twist}>
          <Text style={styles.twistName}>{`${TWISTS[k].name}  `}</Text>
          {LINES[k]}
        </Text>
      ))}
      <Text style={styles.twist}>
        <Text style={styles.twistName}>{'HINT  '}</Text>
        Shows the next hop, for an ad and one star.
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
  unlocked: { fontFamily: F.display, fontSize: 12.5, color: '#16a86a', letterSpacing: 0.6, textAlign: 'center' },
  btnRow: { flexDirection: 'row', alignItems: 'flex-start', justifyContent: 'center', gap: 8, marginTop: 6 },
  col: { alignSelf: 'stretch', gap: 4, marginTop: 6 },
  smallFace: { paddingHorizontal: 14, paddingVertical: 10 },
  bigFace: { paddingHorizontal: 22, paddingVertical: 12 },
  wideFace: { paddingVertical: 12 },
  body: { fontFamily: F.heavy, fontSize: 14, color: INK, textAlign: 'center', paddingHorizontal: 6 },
  cost: { fontFamily: F.display, fontSize: 13, color: '#e01e4a', textAlign: 'center' },
  sadHead: { width: 86, height: 86, borderRadius: 43, backgroundColor: '#ffffff', padding: 5 },
  sadInner: { flex: 1, borderRadius: 40, backgroundColor: '#efe9f5', overflow: 'hidden', alignItems: 'center', justifyContent: 'center' },
  sadImg: { width: '92%', height: '92%', resizeMode: 'contain' },
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
