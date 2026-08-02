import OneShotSound from './OneShotSound';

// A short one-shot "ding" played each time a coin is earned. Built on
// OneShotSound so rapid squishing/dragging plays each ding independently
// instead of the newest grant cutting off the previous one.
export class CoinSound extends OneShotSound {
  constructor() {
    super(require('../../assets/audio/coin.mp3'), 0.8);
  }
}

export default CoinSound;
