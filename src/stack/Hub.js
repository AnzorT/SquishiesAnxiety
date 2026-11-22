import React, { memo } from 'react';
import { GameHub } from '../squishdoku/Hub';
import { LEVELS, doneOf } from './levels';

// Squish Stack's front page, as Squishdoku's (2026-11-16, the user: "the same thing" for Squish Stack): the title on
// its own, REGULAR MODE (the 50-level map) and BLITZ MODE as the new design's wood cards with a picture each
// (tools/games/mode-art.mjs), tapped as a whole, and HOW TO PLAY with a ?.

const PICS = { regular: require('../../assets/stack/mode-regular.jpg'), blitz: require('../../assets/stack/mode-blitz.jpg') };

function Hub({ rec, onRegular, onBlitz, onRules }) {
  return <GameHub title="SQUISH STACK" pics={PICS} lv={rec.lv} done={doneOf(rec)} total={LEVELS} top={rec.blitz.top} onRegular={onRegular} onBlitz={onBlitz} onRules={onRules} />;
}

export default memo(Hub);
