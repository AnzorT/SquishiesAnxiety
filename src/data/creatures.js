// Single source of truth for the 10-creature roster, matching "ASMR
// Creature Squash Game.html" (the design spec this app is built from)
// exactly — names, prices, descriptions, per-creature 3D visuals (used by
// SquishyToy's procedural sphere builder), and the soft-body physics
// constants. Firestore seeding (seedCreatures.js), the 3D engine
// (SquishyToy.js) and every thumbnail/card all read from this file so the
// roster can't drift between them.

export const CREATURES = [
  { id: '0', name: 'Glorp', description: 'A drippy jelly pal who loves gentle squeezes.', price: 0, order: 0 },
  { id: '1', name: 'Puffle', description: 'Fluffiest ball of static-charged joy.', price: 0, order: 1 },
  { id: '2', name: 'Nubbin', description: 'Small horns, big giggles when squashed.', price: 0, order: 2 },
  { id: '3', name: 'Dotty', description: 'Polka-dotted egg with a bubbly laugh.', price: 600, order: 3 },
  { id: '4', name: 'Spike', description: 'Spiky on the outside, squish on the inside.', price: 750, order: 4 },
  { id: '5', name: 'Stellie', description: 'A little star that sparkles when pressed.', price: 900, order: 5 },
  { id: '6', name: 'Puffington', description: 'A cloud creature with a sleepy squeak.', price: 1100, order: 6 },
  { id: '7', name: 'Noodle', description: 'Wobbly tentacles, world-class ASMR sounds.', price: 1300, order: 7 },
  { id: '8', name: 'Glimmer', description: 'Crystal-faceted and impossibly shiny.', price: 1600, order: 8 },
  { id: '9', name: 'Ember', description: 'Warm, glowing, and secretly ticklish.', price: 2000, order: 9 },
];

// Starter creatures every new account already owns (unlocked, no key/coins
// required) — the rest are bought as a key in the Store, then redeemed with
// a hold-to-unlock gesture on their Home card.
export const STARTER_CREATURE_IDS = ['0', '1', '2'];

// color/accent drive the body + accessory material; accessory picks which
// geometry buildCreature() attaches; eye is 'round' (soft, blinking, with a
// glint) or 'slit' (a flat box, no blink).
export const CREATURE_VISUALS = {
  0: { color: '#2dd4bf', accent: '#0d9488', accessory: 'antenna', eye: 'round' },
  1: { color: '#c084fc', accent: '#e9d5ff', accessory: 'ears', eye: 'round' },
  2: { color: '#f97316', accent: '#fb923c', accessory: 'horns', eye: 'slit' },
  3: { color: '#facc15', accent: '#fef9c3', accessory: 'spots', eye: 'round' },
  4: { color: '#4ade80', accent: '#22c55e', accessory: 'leaves', eye: 'round' },
  5: { color: '#ec4899', accent: '#fbcfe8', accessory: 'sparkle', eye: 'round' },
  6: { color: '#7dd3fc', accent: '#f0f9ff', accessory: 'clouds', eye: 'slit' },
  7: { color: '#a78bfa', accent: '#7c3aed', accessory: 'tentacles', eye: 'round' },
  8: { color: '#22d3ee', accent: '#a5f3fc', accessory: 'shine', eye: 'round' },
  9: { color: '#f87171', accent: '#fbbf24', accessory: 'flame', eye: 'round' },
};

// Soft-body dent physics constants — identical for every creature (the old
// per-species "fill" strength/stiff/damp picker is gone; this spec uses one
// fixed feel for the whole roster).
export const PHYS = { strength: 2.2, stiff: 0.55, damp: 0.68, wobbleKick: 0.4 };

export function creatureById(id) {
  return CREATURES.find((c) => c.id === String(id));
}
