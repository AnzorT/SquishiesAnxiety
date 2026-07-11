// startingColorIndex maps into SquishyToy's COLOR_DEFS: 0 Lilac, 1 Blush,
// 2 Sky, 3 Mint, 4 Peach.
export const TOY_CATALOG = [
  {
    id: 'peach',
    name: 'Peach',
    colorHex: '#FFC7A8',
    scent: 'peach scent',
    rarity: 'common',
    price: 0,
    startingColorIndex: 4,
  },
  {
    id: 'strawberry',
    name: 'Strawberry',
    colorHex: '#FF9DB0',
    scent: 'strawberry scent',
    rarity: 'common',
    price: 0,
    startingColorIndex: 1,
  },
  {
    id: 'matcha',
    name: 'Matcha',
    colorHex: '#B6E3B0',
    scent: 'matcha scent',
    rarity: 'rare',
    price: 350,
    startingColorIndex: 3,
  },
  {
    id: 'blueberry',
    name: 'Blueberry',
    colorHex: '#A6C4FF',
    scent: 'blueberry scent',
    rarity: 'rare',
    price: 500,
    startingColorIndex: 2,
  },
  {
    id: 'lemon-star',
    name: 'Lemon Star',
    colorHex: '#FFE79A',
    scent: 'lemon scent',
    rarity: 'epic',
    price: 900,
    startingColorIndex: 0,
  },
];

export default TOY_CATALOG;
