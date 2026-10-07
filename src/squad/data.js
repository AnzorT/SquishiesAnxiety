// The squad economy, app side. The tables and rules are the server's own
// (functions/squad.js — Metro bundles that file as is), so the two can't
// drift; the server is still the one that rolls chests and spends gems and
// Stars (src/squad/api.js). This adds what only the app needs: how chests
// look and open, and reads of the profile for the screens.
import squad from '../../functions/squad.js';

export const { RARITY, SETS, SEASON, ROSTER, BY_ID, SET_OF, STAR_PRICE, COIN_PRICE, DUPE, SET_BONUS, FIN, STAGES, CHESTS, PITY_MAX, EPIC_MAX, DEAL, VIDEO_CHESTS, SWAPS, GEM_PACKS, START, owns, picks, creaturePrice, finishPrice } = squad;

// Shop order and how each chest opens (the design's TIERS: TAP, HOLD,
// SWIPE, MIX); the season chest opens like a Basic one.
export const CHEST_ORDER = ['basic', 'silver', 'gold', 'crystal', 'rainbow'];
export const CHEST_LOOK = {
  basic: { name: 'Basic', mech: 'TAP' },
  silver: { name: 'Silver', mech: 'TAP' },
  gold: { name: 'Gold', mech: 'HOLD' },
  crystal: { name: 'Crystal', mech: 'SWIPE' },
  rainbow: { name: 'Rainbow', mech: 'MIX' },
  season: { name: 'Spooky Squish', mech: 'TAP' },
  welcome: { name: 'Welcome', mech: 'TAP' },
};
// the art a chest is drawn with (the season chest is a gold one, the
// welcome chest a basic one)
export const chestArtOf = (tier) => (tier === 'season' ? 'gold' : tier === 'welcome' ? 'basic' : tier);
export const chestPrice = (tier) => {
  const T = CHESTS[tier];
  return T.gems ? { cur: 'gems', n: T.gems } : { cur: 'coins', n: T.coins };
};

// Rarity colours (squad-store.js RAR); finishes have their own.
export const RAR_LOOK = [
  { label: 'COMMON', bg: '#d7f0ff', dot: '#9fd8ff', ink: '#2f7fd6', card: '#e6f5ff', lip: '#a9d2f2' },
  { label: 'RARE', bg: '#c9f7e1', dot: '#7ee8b4', ink: '#16a86a', card: '#e2fbef', lip: '#98dcbc' },
  { label: 'EPIC', bg: '#ead6ff', dot: '#c89bff', ink: '#8f3cf2', card: '#f1e6ff', lip: '#cdb0f2' },
  { label: 'LEGENDARY', bg: '#ffdcb0', dot: '#ffa94d', ink: '#d9772f', card: '#fff0dc', lip: '#f2c98f' },
  { label: 'SET REWARD', bg: '#ffe0f3', dot: '#ff8fd3', ink: '#d3179a', card: '#ffe9f6', lip: '#f0a8d8' },
];
export const FIN_LOOK = {
  n: { name: 'Normal' },
  s: { name: 'Shiny', glow: '#fff6a8' },
  r: { name: 'Rainbow', bg: ['#ffb3c7', '#ffe38a', '#b3f5c8', '#b3e0ff', '#dcc2ff'], glow: '#ff9fd6' },
  g: { name: 'Golden', bg: ['#fff3b0', '#ffc233', '#f0a000'], glow: '#ffd24d' },
};
export const STAGE_NAMES = ['Baby', 'Grown', 'Best Friend'];
// how each growth stage looks: Baby smaller and rounder, Best Friend crowned
export const STAGE_FX = [{ sx: 0.8, sy: 0.72, crown: false }, { sx: 1, sy: 1, crown: false }, { sx: 1.04, sy: 1.04, crown: true }];

export const rarityOf = (id) => (BY_ID[String(id)] ? BY_ID[String(id)].rar : null);

// --- reading the profile -------------------------------------------------------

const num = (n) => (typeof n === 'number' && Number.isFinite(n) ? n : 0);

// Gems and Stars before the first squad move are the starting ones.
export function wallet(profile) {
  const fresh = profile?.gems == null;
  return { coins: num(profile?.coins), gems: fresh ? START.gems : num(profile.gems), stars: num(profile?.stars) + (fresh ? START.stars : 0) };
}

export function entry(profile, id) {
  const e = profile?.col?.[id];
  if (e) return e;
  return owns(profile || {}, String(id)) ? { f: { n: 1 }, eq: 'n', st: 0 } : null;
}
export const finishOf = (profile, id) => entry(profile, id)?.eq || 'n';
export const stageOf = (profile, id) => entry(profile, id)?.st || 0;
export const myChests = (profile) => profile?.chestBag || {};
export const chestVideosLeft = (profile, day) => VIDEO_CHESTS - (profile?.chestVideos?.day === day ? num(profile.chestVideos.n) : 0);
export const dealBought = (profile, day) => profile?.dealDay === day;

export function growInfo(profile, id) {
  const e = entry(profile, id);
  if (!e) return null;
  const st = e.st || 0;
  const next = STAGES[st + 1];
  const xp = num(profile?.xp?.[id]);
  if (!next) return { stage: st, max: true, xp };
  const stars = wallet(profile).stars;
  return { stage: st, max: false, xp, needXp: next.xp, needStars: next.stars, xpOk: xp >= next.xp, starsOk: stars >= next.stars, next: STAGE_NAMES[st + 1] };
}

export function setInfo(profile, key) {
  const s = SET_OF[key];
  const have = s.ids.filter((id) => owns(profile || {}, id)).length;
  return { have, total: s.ids.length, done: have === s.ids.length, reward: s.reward, rewardOwned: owns(profile || {}, s.reward) };
}
