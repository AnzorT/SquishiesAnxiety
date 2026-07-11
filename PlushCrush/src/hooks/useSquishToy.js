import { useEffect, useMemo, useRef, useState } from 'react';
import * as Haptics from 'expo-haptics';
import { SquishState } from '../engine/SquishState';
import { AudioEngine } from '../audio/AudioEngine';

// Wires SquishState (physics) + AudioEngine (sound) + Haptics together for a
// single toy instance. Screens just call the returned handlers from
// PanResponder / gesture events.
export function useSquishToy(fillKey = 'memoryFoam') {
  const squishState = useMemo(() => new SquishState(fillKey), []);
  const audioEngine = useRef(new AudioEngine()).current;
  const [particleTrigger, setParticleTrigger] = useState(null);
  const crossedHalfway = useRef(false);

  useEffect(() => {
    audioEngine.init().then(() => audioEngine.loadProfile(squishState.profile.audioProfile));
    return () => {
      audioEngine.unloadAll();
    };
  }, []);

  useEffect(() => {
    audioEngine.loadProfile(squishState.profile.audioProfile);
  }, [squishState.fillKey]);

  const setFill = (fillKey) => {
    squishState.setFill(fillKey);
    audioEngine.loadProfile(squishState.profile.audioProfile);
  };

  const onTouchMove = (x, y, pressure) => {
    squishState.onTouchMove(x, y, pressure);
    audioEngine.onDepthChange(squishState.profile.audioProfile, squishState.depth);

    if (squishState.depth > 0.5 && !crossedHalfway.current) {
      crossedHalfway.current = true;
      setParticleTrigger({ type: 'puff', at: Date.now() });
      Haptics.impactAsync(Haptics.ImpactFeedbackStyle.Light);
    }
    if (squishState.depth < 0.5) {
      crossedHalfway.current = false;
    }
    if (squishState.burst) {
      setParticleTrigger({ type: 'burst', at: Date.now() });
      audioEngine.playBurst();
      Haptics.notificationAsync(Haptics.NotificationFeedbackType.Success);
      squishState.reset();
    }
  };

  const onTouchEnd = () => {
    squishState.onTouchEnd();
  };

  return { squishState, audioEngine, particleTrigger, setFill, onTouchMove, onTouchEnd };
}

export default useSquishToy;
