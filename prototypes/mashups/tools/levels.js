const SQZ_LEVELS = [
 {
  "id": "first",
  "name": "First squeeze",
  "tip": "Find the gap at the bottom of the room. The block on the bed gets shoved off when you pop out.",
  "par": 8,
  "map": [
   "##########",
   "######...#",
   "#....##..#",
   "#....###.#",
   "#....###.#",
   "#....##..#",
   "#........#",
   "##########"],
  "plush": [
   {
    "x": 1,
    "y": 5,
    "bed": [7,1],
    "name": "Mochi"
   }],
  "blocks": [
   [7,1]]
 },
 {
  "id": "toyfirst",
  "name": "Toy first",
  "tip": "Your bed is right next to you, but the toy block has to go in its box first.",
  "par": 29,
  "map": [
   "#########",
   "#.......#",
   "####....#",
   "####..#.#",
   "#####...#",
   "##......#",
   "##o.....#",
   "##..#...#",
   "#########"],
  "plush": [
   {
    "x": 6,
    "y": 1,
    "bed": [4,1],
    "name": "Mochi"
   }],
  "blocks": [
   [4,5]]
 },
 {
  "id": "popshove",
  "name": "Pop and shove",
  "tip": "Where you pop out decides which way the block gets shoved.",
  "par": 31,
  "map": [
   "########",
   "#......#",
   "#...##.#",
   "#o..##.#",
   "#......#",
   "#......#",
   "###....#",
   "########"],
  "plush": [
   {
    "x": 4,
    "y": 5,
    "bed": [1,1],
    "name": "Mochi"
   }],
  "blocks": [
   [3,2]]
 },
 {
  "id": "sleepy",
  "name": "Sleepyhead",
  "tip": "Bean is fast asleep. Push Bean into the green bed. Pushed plushies squeeze through gaps too.",
  "par": 39,
  "map": [
   "########",
   "#.....o#",
   "#..#...#",
   "#......#",
   "#......#",
   "#......#",
   "#.....##",
   "########"],
  "plush": [
   {
    "x": 5,
    "y": 2,
    "bed": [1,2],
    "name": "Mochi"
   },
   {
    "x": 3,
    "y": 3,
    "bed": [4,5],
    "sleepy": true,
    "name": "Bean"
   }],
  "blocks": [
   [3,5]]
 },
 {
  "id": "twotoys",
  "name": "Two toys",
  "tip": "Two blocks, two boxes. A block pushed into a corner stays there for good.",
  "par": 52,
  "map": [
   "#########",
   "#.####.##",
   "#.......#",
   "#.##..o.#",
   "#.......#",
   "#......o#",
   "#....####",
   "#....####",
   "#########"],
  "plush": [
   {
    "x": 1,
    "y": 5,
    "bed": [4,3],
    "name": "Mochi"
   }],
  "blocks": [
   [2,4],
   [3,6]]
 },
 {
  "id": "rush",
  "name": "Lights out",
  "tip": "Bean, one block, not much room. Hint tells you if you are stuck.",
  "par": 48,
  "map": [
   "#########",
   "#.......#",
   "#.......#",
   "#.......#",
   "#.....o.#",
   "####....#",
   "####....#",
   "#########"],
  "plush": [
   {
    "x": 1,
    "y": 3,
    "bed": [6,5],
    "name": "Mochi"
   },
   {
    "x": 3,
    "y": 3,
    "bed": [5,1],
    "sleepy": true,
    "name": "Bean"
   }],
  "blocks": [
   [6,3]]
 }
];
