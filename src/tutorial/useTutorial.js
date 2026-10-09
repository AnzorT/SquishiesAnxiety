import { useCallback, useEffect, useRef } from 'react';
import { getState, report, useTutorialSelect, useTutorialVersion } from './store';
import { HOLD_MS, ROTATE_PX, stepView, tutorialActive } from './steps';

// Runs the tutorial for App.js: feeds the step machine (steps.js) with the
// store and the profile, puts what to show in the store (`ui`, drawn by
// Guide.js) and moves the step on. The step is kept here too (`stepRef`),
// ahead of the profile's own `tut` field, so a step doesn't wait on the
// Firestore round trip — `setStep` writes it.
//
// The timed step (hold 5 s) banks holdMs on a 150 ms tick while the finger
// is down.
export default function useTutorial({ profile, creatures, setStep, setLevel, signedIn }) {
  // the tutorial starts once the player is signed in (never on the splash
  // or sign-in screens) and picks up from the profile's step after a restart
  const active = signedIn && tutorialActive(profile);
  // App follows the store only while the tutorial runs: subscribed for
  // good, every report() anywhere re-rendered the whole app
  const version = useTutorialVersion(active);
  // the hold / twist progress ticks don't reach App (store.js VOLATILE);
  // reaching their goals does
  const holdDone = useTutorialSelect((st) => st.holdMs >= HOLD_MS);
  const rotateDone = useTutorialSelect((st) => st.rotateAcc >= ROTATE_PX);
  const s = getState();
  const stepRef = useRef(null);
  const levelledRef = useRef(null);
  const tut = signedIn ? profile?.tut : null;

  // the profile is the source of truth; a step set here is kept until the
  // profile catches up (or changes to something else, e.g. a replay)
  const lastProfileStep = useRef(tut);
  if (lastProfileStep.current !== tut) {
    lastProfileStep.current = tut;
    stepRef.current = tut;
  }
  if (stepRef.current == null) stepRef.current = tut;

  // the hold step's clock: time banked from earlier presses, and when the
  // current press began — kept here so re-renders can't lose any of it
  const holdRef = useRef({ banked: 0, since: null });
  const go = useCallback(
    (next) => {
      if (!next || stepRef.current === next) return;
      stepRef.current = next;
      holdRef.current = { banked: 0, since: null };
      report({ holdMs: 0, rotateAcc: 0 });
      setStep(next);
    },
    [setStep]
  );

  const holding = active && stepRef.current === 'hold' && s.holdActive;
  useEffect(() => {
    const h = holdRef.current;
    if (!holding) {
      if (h.since != null) {
        h.banked += Date.now() - h.since;
        h.since = null;
        report({ holdMs: h.banked });
      }
      return undefined;
    }
    h.since = Date.now();
    const iv = setInterval(() => report({ holdMs: h.banked + (Date.now() - h.since) }), 150);
    return () => clearInterval(iv);
  }, [holding]);

  // the Guide's buttons: a step to move to
  const onAction = useCallback((next) => go(next), [go]);

  useEffect(() => {
    if (!active) {
      if (s.ui) report({ ui: null });
      return undefined;
    }
    const mittens = creatures.find((c) => c.id === '1');
    const run = () => {
      const view = stepView({ tut: stepRef.current, s, profile, creatures, mittens });
      if (view.level && setLevel && levelledRef.current !== view.level && (profile?.level ?? 1) < view.level) {
        levelledRef.current = view.level;
        setLevel(view.level);
      }
      if (view.next) {
        go(view.next);
        return;
      }
      const ui = view.hide ? null : view.ui;
      if (JSON.stringify(ui) !== JSON.stringify(s.ui)) report({ ui });
    };
    run();
    return undefined;
    // `version` stands for the store's contents
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [version, holdDone, rotateDone, profile, creatures, active, go, setLevel]);

  return { onAction, step: active ? stepRef.current : 'done' };
}
