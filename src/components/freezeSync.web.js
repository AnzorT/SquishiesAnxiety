// Web only: Freeze's switch into asleep (Freeze.js) as a synchronous update.
//
// The web renders with createRoot (concurrent React). There, a Suspense boundary whose content is already on screen
// and that suspends in an ordinary update isn't hidden at once: React holds the whole commit back for a short while
// ("just noticeable difference") in case the promise resolves, and every new update in the meantime starts that wait
// again. Freeze's promise never resolves, and on the web every frame of an Animated animation is a React update
// (react-native-web has no native driver), so with any animation running outside the frozen part nothing was ever
// committed again: the whole app stood still. Seen 2026-11-16 as "To the treasure vault" stuck part way along its
// trail, over the Shop frozen under the chest smash.
//
// A synchronous render (flushSync) is always committed, suspended or not, so going to sleep happens in one; waking
// up needs nothing special (nothing suspends then). flushSync can't run inside React's own effects, hence the timer.
import { useEffect, useState } from 'react';
import { flushSync } from 'react-dom';

export function useFrozen(freeze) {
  // (frozen from the very first render: a new boundary, which React hides at once, so as on the phone)
  const [frozen, setFrozen] = useState(freeze);
  useEffect(() => {
    if (!freeze) {
      if (frozen) setFrozen(false);
      return undefined;
    }
    if (frozen) return undefined;
    const t = setTimeout(() => flushSync(() => setFrozen(true)), 0);
    return () => clearTimeout(t);
  }, [freeze, frozen]);
  return freeze && frozen;
}
