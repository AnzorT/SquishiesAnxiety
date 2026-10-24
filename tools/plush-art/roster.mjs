// The roster the catalog is rendered and published for: every creature in
// functions/squad.js (the 2026-10-19 design's 86; the id doubles as the
// Firestore doc id, `creatures/{id}`), with the one-line description the
// app shows. The first 30 keep the descriptions written for the 2026-10-03
// roster; the rest use the design's concept line (squad-store.js).
//
// render.mjs renders each creature's art from
// tools/design-v6/export/tripo/{key}/{key}-front.svg and publish.mjs writes
// these names/descriptions onto the catalog docs.
import { createRequire } from 'node:module';
import { design } from '../rig/design-roster.mjs';

const require = createRequire(import.meta.url);
const squad = require('../../functions/squad.js');

const DESCRIPTIONS = {
  nimbo: 'A sleepy little cloud that drizzles when squeezed.',
  mittens: 'A ginger kitten who purrs on every squish.',
  mallow: 'Pillowy marshmallow, the softest squish around.',
  bao: 'A warm steamed bun, fresh out of the basket.',
  dunkie: 'Sprinkle-covered donut with one bite missing.',
  frybo: 'Crispy, salty and always up for a snack.',
  pip: 'A tiny penguin with a big waddle.',
  bunbun: 'A stacked burger buddy with extra cheese.',
  jelli: 'Wobbly jellyfish with world-class ASMR sounds.',
  pina: 'Sweet pineapple with a spiky crown.',
  finn: 'A baby dolphin who loves to splash.',
  sealy: 'Round, fluffy baby seal. Pure squish.',
  biscuit: 'A floppy-eared puppy with a waggy tail.',
  hana: 'A shy kid in a cosy bunny suit.',
  choco: 'A chocolate bar that melts your heart.',
  prickle: 'Spiky on the outside, squish on the inside.',
  lumi: 'A moon bunny who carries her own little lantern.',
  kiko: 'Petal-maned and proud of it.',
  bubbly: 'An iridescent bubble that never pops.',
  twinkle: 'A sleepy star in a little nightcap.',
  zappi: 'Crackles with static on every squash.',
  scoop: 'A strawberry ice cream that never melts.',
  teddy: 'A huggable bear who gives the best cuddles.',
  hoot: 'A wise little owl who stays up late.',
  leo: 'A brave little lion with a fluffy mane.',
  nibbles: 'A chubby hamster who stuffs her cheeks.',
  quill: 'A shy brown hedgehog with soft spikes.',
  panko: 'A baby panda who loves bamboo naps.',
  boba: 'A milky bubble tea full of chewy pearls.',
  avo: 'A baby avocado with a big round pit belly.',
};

const sentence = (s) => (s ? s[0].toUpperCase() + s.slice(1) + (/[.!?]$/.test(s) ? '' : '.') : '');

export const ROSTER = squad.ROSTER.map((c) => ({
  id: Number(c.id),
  key: c.key,
  name: c.name,
  description: DESCRIPTIONS[c.key] || sentence((design.find((d) => d.key === c.key) || {}).concept),
}));
