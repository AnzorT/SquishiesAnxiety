import { BY_ID, HIDDEN, isOut } from '../squad/data';

// Squish Sort's container: the fridge, with the food groups' squishies (the user, 2026-10-24: "for the food squishy
// for example i want them to be a fridge"; 2026-11-17: "lets make it only with food ok ? so delete the toy
// cupboard"). The fridges themselves are models.js and Container.js.

export const THEMES = {
  fridge: {
    key: 'fridge',
    name: 'Snack Fridge',
    blurb: 'Snacks, fruit and bakes',
    groups: ['snack', 'fruit', 'bakery'],
    ring: '#1f5f7a',
    body: ['#ffffff', '#eaf8ff', '#c6e8f7'],
    top: ['#f7fdff', '#d9f0fb'], // the freezer
    inside: ['#f4fcff', '#d3f0fd', '#b9e4f7'],
    lamp: '#ffffff',
    shelf: { top: 'rgba(255,255,255,0.95)', face: 'rgba(170,222,245,0.85)', edge: '#7cc4e2' },
    door: ['#ffffff', '#eef9ff', '#cfeaf7'],
    doorInner: ['#e2f4fc', '#c1e3f2'],
    handle: ['#ffffff', '#b8e2f4', '#7cc4e2'],
    trim: '#7cc4e2',
    feet: '#5d7f90',
    tray: { ring: '#9a5a22', colors: ['#fff8ec', '#ffe6c4', '#f7cf98'], label: 'COUNTER' },
    card: { ring: '#1f5f7a', colors: ['#f0fbff', '#bfe9fb', '#7fd0f0'] },
    slotDash: 'rgba(31,95,122,0.28)',
  },
};

// The squishies a theme draws from: its groups' creatures that are out
// (not on config/roster's hidden list), owned or not, with a rig still.
// [{ id, uri }]
export function poolOf(theme, creatures, hidden = HIDDEN) {
  const groups = THEMES[theme].groups;
  return (creatures || [])
    .filter((c) => c && c.thumb && c.thumb.url && BY_ID[String(c.id)])
    .filter((c) => groups.includes(BY_ID[String(c.id)].set) && isOut(BY_ID[String(c.id)], hidden) && !BY_ID[String(c.id)].pass)
    .map((c) => ({ id: String(c.id), uri: c.thumb.url }));
}
