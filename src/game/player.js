// What the new design's game (src/game/GameScreen.js, webgame/) shows of the player, from the app's profile:
// the game knows creatures by key (the design's roster numbers them its own way), the app by id (functions/squad.js).
import squad from '../../functions/squad.js';
import { BY_ID, GROUPS, ROSTER, SIZE_I, isOut, owns, shownSize, wallet } from '../squad/data';
import { CHEST_NAMES } from '../squad/groupChestArt';
import { todayKey } from '../dailySpin';
import { menuLooks } from '../squad/looks';
import { weatherToday } from '../weather';
import { levelsConfig, roadView, xpView } from '../playerXp';
import { selectedId } from '../squad/lobby';
import { LEVELS as SDK_LEVELS, record as sdkRecord } from '../squishdoku/levels';
import { LEVELS as SORT_LEVELS, record as sortRecord } from '../sort/levels';
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
    { id: 'sort', name: 'Squish Sort', item: 'Fridge memory', best: `Level ${srt.fridge.lv} / ${SORT_LEVELS}`, color: '#ff9a3c' },
    { id: 'stack', name: 'Squish Stack', item: 'Tower puzzles', best: `Level ${stk.lv} / ${STACK_LEVELS}${stars(stackStars(stk))}`, color: '#9b6bff' },
    { id: 'hop', name: 'Squish Hop', item: 'Cushion hopping', best: `Level ${hop.lv} / ${HOP_LEVELS}${stars(hopStars(hop))}`, color: '#2fc6a8' },
  ];
}

// level: the player's level (XP), hidden: the roster's not-out list (config/roster: groups switched off, retired)
export function gamePlayer(profile, { level, hidden, rosterCfg }) {
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
    // the menu's level crest (XP ring) and its Level Pass (webgame/app/menu.js)
    xp: { ...levelXp(p), per: levelsConfig().xpPerLevel },
    road: roadPrizes(p, hidden),
    // the creatures' still pictures: their border look (config/roster look / looks, src/squad/looks.js)
    looks: menuLooks(rosterCfg),
    // today's weather (config/weather, src/weather.js): the menu's world and the house show it (app/bridge.js
    // SquishWeatherNow)
    weather: weatherToday(),
  };
}

// The Level Pass's prizes. A chest says whose it is (REDESIGN_V9, the user: the chest you'll get, e.g. the Pet Shop's
// Common): g, its group (config/levels' own `g`, else today's first HOT group: functions/squad.js prizeGroup, as the
// server pays it), gn the group's name, cn the chest's own name (Mossy Stump Stash). The menu shows its picture
// (app/gchests/<g>-<t>-grow.webp, copied in by webgame/build.mjs).
function roadPrizes(p, hidden) {
  const day = todayKey(new Date());
  return roadView(p).map((n) => {
    const t = n.r.t ? shownSize(n.r.t) : null;
    const g = n.r.k === 'chest' ? squad.prizeGroup(n.r, day, hidden) : null;
    const grp = g && GROUPS.find((x) => x.key === g);
    return { lv: n.lv, k: n.r.k, n: n.r.n || 0, t, g, gn: grp ? grp.name : null, cn: g && t ? (CHEST_NAMES[g] || [])[SIZE_I[t]] || null : null, got: n.got, claimable: n.claimable };
  });
}

const levelXp = (p) => {
  const { level, into, need } = xpView(p);
  return { level, into, need };
};

export const idOfKey = (key) => (ROSTER.find((c) => c.key === key) || {}).id || null;
