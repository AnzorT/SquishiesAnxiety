// The 30-creature plush roster of the 2026-10-03 design drop ("ASMR Creature
// Squash v3.dc.html" → CREATURES, in the design's own order; `key` is the
// design's file name, GAME_ORDER in creatures-v2.js). The id doubles as the
// Firestore doc id (`creatures/{id}`) and the roster position the economy
// prices from (src/economy.js) and the rarity comes from (tierOf in
// src/theme/candyTheme.js). The design's coin `price` is not used: coins buy
// Mystery Boxes, not creatures.
//
// render.mjs renders each creature's art from
// design/export/tripo/{key}/{key}-front.svg (the same drawing as
// export/creatures-v2/NN-{key}.svg without its ground shadow — the plush
// component's own source) and publish.mjs writes these names/descriptions
// onto the catalog docs.

export const ROSTER = [
  { id: 0, key: 'nimbo', name: 'Nimbo', description: 'A sleepy little cloud that drizzles when squeezed.' },
  { id: 1, key: 'mittens', name: 'Mittens', description: 'A ginger kitten who purrs on every squish.' },
  { id: 2, key: 'mallow', name: 'Mallow', description: 'Pillowy marshmallow, the softest squish around.' },
  { id: 3, key: 'bao', name: 'Bao', description: 'A warm steamed bun, fresh out of the basket.' },
  { id: 4, key: 'dunkie', name: 'Dunkie', description: 'Sprinkle-covered donut with one bite missing.' },
  { id: 5, key: 'frybo', name: 'Frybo', description: 'Crispy, salty and always up for a snack.' },
  { id: 6, key: 'pip', name: 'Pip', description: 'A tiny penguin with a big waddle.' },
  { id: 7, key: 'bunbun', name: 'Bunbun', description: 'A stacked burger buddy with extra cheese.' },
  { id: 8, key: 'jelli', name: 'Jelli', description: 'Wobbly jellyfish with world-class ASMR sounds.' },
  { id: 9, key: 'pina', name: 'Pina', description: 'Sweet pineapple with a spiky crown.' },
  { id: 10, key: 'finn', name: 'Finn', description: 'A baby dolphin who loves to splash.' },
  { id: 11, key: 'sealy', name: 'Sealy', description: 'Round, fluffy baby seal. Pure squish.' },
  { id: 12, key: 'biscuit', name: 'Biscuit', description: 'A floppy-eared puppy with a waggy tail.' },
  { id: 13, key: 'hana', name: 'Hana', description: 'A shy kid in a cosy bunny suit.' },
  { id: 14, key: 'choco', name: 'Choco', description: 'A chocolate bar that melts your heart.' },
  { id: 15, key: 'prickle', name: 'Prickle', description: 'Spiky on the outside, squish on the inside.' },
  { id: 16, key: 'lumi', name: 'Lumi', description: 'A moon bunny who carries her own little lantern.' },
  { id: 17, key: 'kiko', name: 'Kiko', description: 'Petal-maned and proud of it.' },
  { id: 18, key: 'bubbly', name: 'Bubbly', description: 'An iridescent bubble that never pops.' },
  { id: 19, key: 'twinkle', name: 'Twinkle', description: 'A sleepy star in a little nightcap.' },
  { id: 20, key: 'zappi', name: 'Zappi', description: 'Crackles with static on every squash.' },
  { id: 21, key: 'scoop', name: 'Scoop', description: 'A strawberry ice cream that never melts.' },
  { id: 22, key: 'teddy', name: 'Teddy', description: 'A huggable bear who gives the best cuddles.' },
  { id: 23, key: 'hoot', name: 'Hoot', description: 'A wise little owl who stays up late.' },
  { id: 24, key: 'leo', name: 'Leo', description: 'A brave little lion with a fluffy mane.' },
  { id: 25, key: 'nibbles', name: 'Nibbles', description: 'A chubby hamster who stuffs her cheeks.' },
  { id: 26, key: 'quill', name: 'Quill', description: 'A shy brown hedgehog with soft spikes.' },
  { id: 27, key: 'panko', name: 'Panko', description: 'A baby panda who loves bamboo naps.' },
  { id: 28, key: 'boba', name: 'Boba', description: 'A milky bubble tea full of chewy pearls.' },
  { id: 29, key: 'avo', name: 'Avo', description: 'A baby avocado with a big round pit belly.' },
];
