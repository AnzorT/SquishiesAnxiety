// Freeze's switch into asleep (Freeze.js). On the phone it's the `freeze` prop as it is: React Native (the old
// architecture) renders in legacy mode, where a Suspense boundary hides its content in the same commit. The web has
// its own version (freezeSync.web.js).
export function useFrozen(freeze) {
  return freeze;
}
