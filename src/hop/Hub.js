import React, { memo } from 'react';
import { GameHub } from '../squishdoku/Hub';
import { LEVELS, doneOf } from './levels';

// Squish Hop's front page (2026-11-16, the user: "the same thing" as Squishdoku's hub): the title on its own, REGULAR
// MODE (the 100-level map through the Crib's rooms) and BLITZ MODE as the new design's wood cards with a picture each
// (tools/games/mode-art.mjs), tapped as a whole, and HOW TO PLAY with a ?.

const PICS = { regular: require('../../assets/hop/mode-regular.jpg'), blitz: require('../../assets/hop/mode-blitz.jpg') };

function Hub({ rec, onRegular, onBlitz, onRules }) {
  return <GameHub title="SQUISH HOP" pics={PICS} lv={rec.lv} done={doneOf(rec)} total={LEVELS} top={rec.blitz.top} onRegular={onRegular} onBlitz={onBlitz} onRules={onRules} />;
}

export default memo(Hub);
