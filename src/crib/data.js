// What's left of the old Squad Crib's data (the Crib itself was retired with the old UI, 2026-11-20): the foods, which
// CreatureThumbnail and src/plush/care.js still draw, and the times of day the mini-games' rooms are lit for (PH).

import FOODS_DATA from './foods.js';

export const FOODS = FOODS_DATA;
export const foodOf = (k) => FOODS.find((f) => f.k === k) || null;

// the time of day: a phase for the room art, the tint over the whole scene and the darkness the lamps light up
export const PH = {
  morning: { label: 'MORNING', sun: '#ffe38a', tint: 'rgba(255,170,140,0.05)' },
  day: { label: 'DAYTIME', sun: '#fff3a0' },
  evening: { label: 'EVENING', sun: '#ffb36b', tint: 'rgba(90,20,120,0.1)', dark: [40, 20, 70, 0.22], glow: 0.18 },
  night: { label: 'NIGHT', sun: '#fff6d8', tint: 'rgba(20,24,70,0.22)', dark: [16, 12, 48, 0.52], glow: 0.34 },
};
