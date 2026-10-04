import OneShotSound from './OneShotSound';

// Played when the user lifts their finger off a one-finger squish — a
// bubble pop to punctuate the release.
export class PopSound extends OneShotSound {
  constructor() {
    super(require('../../assets/audio/pop.mp3'), 1);
  }
}

export default PopSound;
