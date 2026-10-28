import React, { Suspense, memo, useRef } from 'react';

// Keeps a mounted subtree alive but asleep: while `freeze` is on, it isn't
// drawn (Suspense hides it with display: none) and doesn't re-render, but
// keeps all its state, so showing it again costs one render instead of a
// fresh mount. The same trick as the react-freeze package (which
// react-navigation uses for screens under the top one), in a few lines.
//
// It works by suspending: a frozen render throws a promise that only
// resolves when `freeze` goes off again. Freeze something only after it has
// mounted; a subtree frozen from its very first render is never built.

function Suspender({ freeze, children }) {
  const pending = useRef(null);
  if (freeze) {
    if (!pending.current) {
      let resolve;
      const promise = new Promise((r) => (resolve = r));
      pending.current = { promise, resolve };
    }
    throw pending.current.promise;
  }
  if (pending.current) {
    pending.current.resolve();
    pending.current = null;
  }
  return children;
}

export default function Freeze({ freeze, children }) {
  return (
    <Suspense fallback={null}>
      <Suspender freeze={freeze}>{children}</Suspender>
    </Suspense>
  );
}

// The lighter sleep: while `hold` is on, the subtree stays as it is, laid
// out and drawn, but deaf to its parent (new props from above don't
// re-render it; its own state still does). Waking it is only catching up on
// what changed. For something kept off screen (a page beside the one shown)
// rather than covered: Freeze's display: none made waking the Shop's three
// pages a 0.3-0.7 s re-layout on the UI thread, right in the middle of the
// slide to it (Galaxy A15 release build, 2026-10-28).
const Held = memo(
  ({ children }) => children,
  (prev, next) => next.hold,
);
export function Hold({ hold, children }) {
  return <Held hold={hold}>{children}</Held>;
}
