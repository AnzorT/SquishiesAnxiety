import CREATURE_SQUISH_FILES from './creatureSquishFiles';

// The loop the squish stage plays while a creature is held. Every premade
// creature has its own recording from the design ("ASMR Creature Squash
// Game (1).zip" → tools/audio/encodeCreatureSounds.py → assets/audio/
// creatures/<id>.ogg); a custom creature can carry its own `audio` URL;
// anything else gets the generic slime loop.
const DEFAULT_SQUISH_SOUND = require('../../assets/audio/slime.wav');

export function squishSoundFor(toy) {
  if (toy && toy.audio) return { uri: toy.audio };
  const own = toy && CREATURE_SQUISH_FILES[String(toy.id)];
  return own || DEFAULT_SQUISH_SOUND;
}

export default squishSoundFor;
