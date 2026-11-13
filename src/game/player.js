// What the new design's game (src/game/GameScreen.js, webgame/) shows of the player, from the app's profile:
// the game knows creatures by key (the design's roster numbers them its own way), the app by id (functions/squad.js).
import { BY_ID, ROSTER, isOut, owns, wallet } from '../squad/data';
import { selectedId } from '../squad/lobby';
import { LEVELS as SDK_LEVELS, record as sdkRecord } from '../squishdoku/levels';
import { record as sortRecord } from '../sort/levels';
import { LEVELS as STACK_LEVELS, record as stackRecord, starsOf as stackStars } from '../stack/levels';
import { LEVELS as HOP_LEVELS, record as hopRecord, starsOf as hopStars } from '../hop/levels';

// The app's games on the Main Menu's Mini Games page (PLAY / GAMES), after the design's own Squish Time card.
// `best` is the card's progress line.
export function menuGames(profile) {
  const sdk = sdkRecord(profile);
  const srt = sortRecord(profile);
  const stk = stackRecord(profile);
  const hop = hopRecord(profile);
  const stars = (n) => (n ? ` · ★ ${n}` : '');
  return [
    { id: 'squishdoku', name: 'Squishdoku', item: `${SDK_LEVELS} puzzle levels`, best: `Level ${Math.min(sdk.lv, SDK_LEVELS)} / ${SDK_LEVELS}`, color: '#3fc4ec' },
    { id: 'sort', name: 'Squish Sort', item: 'Fridge & cupboard', best: `Fridge ${srt.fridge.lv} · Cupboard ${srt.cupboard.lv}`, color: '#ff9a3c' },
    { id: 'stack', name: 'Squish Stack', item: 'Tower puzzles', best: `Level ${stk.lv} / ${STACK_LEVELS}${stars(stackStars(stk))}`, color: '#9b6bff' },
    { id: 'hop', name: 'Squish Hop', item: 'Cushion hopping', best: `Level ${hop.lv} / ${HOP_LEVELS}${stars(hopStars(hop))}`, color: '#2fc6a8' },
  ];
}

// level: the player's level (XP), hidden: the roster's not-out list (config/roster: groups switched off, retired)
export function gamePlayer(profile, { level, hidden }) {
  const p = profile || {};
  const visible = (c) => isOut(c, hidden);
  const mine = ROSTER.filter((c) => owns(p, c.id) && visible(c));
  const col = {};
  for (const c of mine) {
    const e = p.col && p.col[c.id];
    if (e) col[c.key] = { f: e.f || { n: 1 }, eq: e.eq || 'n', st: e.st || 0 };
  }
  const sel = BY_ID[selectedId(p)];
  return {
    level,
    coins: p.coins ?? 0,
    gems: wallet(p).gems,
    owned: mine.map((c) => c.key),
    col,
    sel: sel && visible(sel) ? sel.key : mine[0] ? mine[0].key : null,
    hiddenKeys: ROSTER.filter((c) => !visible(c)).map((c) => c.key),
    games: menuGames(p),
    gamesNote: 'every game pays coins and XP',
  };
}

export const idOfKey = (key) => (ROSTER.find((c) => c.key === key) || {}).id || null;
