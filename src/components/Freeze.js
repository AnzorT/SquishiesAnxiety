import React, { Suspense, useRef } from 'react';

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
