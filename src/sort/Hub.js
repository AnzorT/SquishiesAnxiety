import React, { memo, useMemo } from 'react';
import { Easing } from 'react-native';
import { stepKeys, useKeyLoop } from '../components/idleLoop';
import { GameHub } from '../squishdoku/Hub';
import { LEVELS, doneIn } from './levels';

// Squish Sort's front page, as the other games' (2026-11-17, the user: "make sure the screens of squish sort matches
// the other game's screen"): the title on its own, REGULAR MODE (the fridge's 50-level map) and BLITZ MODE as the
// design's wood cards with a picture each (tools/sort/mode-art.mjs), tapped as a whole, and HOW TO PLAY with a ?. Only
// the fridge since 2026-11-17 ("lets make it only with food ok ? so delete the toy cupboard").

const PICS = { regular: require('../../assets/sort/mode-regular.jpg'), blitz: require('../../assets/sort/mode-blitz.jpg') };

function Hub({ rec, onRegular, onBlitz, onRules }) {
  return <GameHub title="SQUISH SORT" pics={PICS} lv={rec.fridge.lv} done={doneIn(rec, 'fridge')} total={LEVELS} top={rec.blitz.top} onRegular={onRegular} onBlitz={onBlitz} onRules={onRules} />;
}

export default memo(Hub);

// Doors that open, stay, shut, rattle and open again, forever (the game picker's little fridge): open 1.4 s, shut in
// 380 ms, a 450 ms rattle, shut 200 ms, then open with a little overshoot in 420 ms. One native loop of a phase, read
// as the door and the rattle (idleLoop.js; a loop around the sequence went back to JS at every step).
const DOOR = stepKeys(1, [
  [1, 1400],
  [0, 380, Easing.in(Easing.quad)],
  [0, 650],
  [1, 420, Easing.out(Easing.back(1.4))],
]);
const RATTLE = stepKeys(0, [
  [0, 1780],
  ...[1, -1, 1, -1, 0].map((v) => [v, 90, Easing.inOut(Easing.quad)]),
  [0, 620],
]);
const LINE = [0, 1];
export function useDoorLoop() {
  const p = useKeyLoop(DOOR.ms, { at: LINE, values: LINE });
  return useMemo(
    () => ({
      door: p.interpolate({ inputRange: DOOR.at, outputRange: DOOR.values }),
      rotate: p.interpolate({ inputRange: RATTLE.at, outputRange: RATTLE.values.map((v) => `${v * 5}deg`) }),
    }),
    [p],
  );
}
