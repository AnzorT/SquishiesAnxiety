// The Firebase JS SDK on the Local Emulator Suite (project demo-squish: a demo- project can't reach a real one), for
// the shims of the React Native Firebase modules. Every request goes to 127.0.0.1: fetch refuses anything else, and the
// callable URL src/firebase/callFunction.js builds is sent to the functions emulator.
import { initializeApp } from 'firebase/app';
import { connectAuthEmulator, getAuth } from 'firebase/auth';
import { connectFirestoreEmulator, getFirestore } from 'firebase/firestore';

export const PROJECT = 'demo-squish';
const HOST = '127.0.0.1';

export const app = initializeApp({ projectId: PROJECT, apiKey: 'demo-key', authDomain: `${PROJECT}.firebaseapp.com` });
export const auth = getAuth(app);
connectAuthEmulator(auth, `http://${HOST}:9099`, { disableWarnings: true });
export const db = getFirestore(app);
connectFirestoreEmulator(db, HOST, 8080);

// The app fires its writes and forgets them (`.catch(logFail(...))`); the driver waits for them here.
const pending = new Set();
export function track(p) {
  pending.add(p);
  p.then(
    () => pending.delete(p),
    () => pending.delete(p),
  );
  return p;
}
export async function idle() {
  while (pending.size) await Promise.allSettled([...pending]);
}

const realFetch = globalThis.fetch;
globalThis.fetch = (input, init) => {
  let url = String(input && input.url ? input.url : input);
  const u = new URL(url);
  if (u.hostname === `us-central1-${PROJECT}.cloudfunctions.net`) url = `http://${HOST}:5001/${PROJECT}/us-central1${u.pathname}`;
  else if (u.hostname !== HOST && u.hostname !== 'localhost') return Promise.reject(new Error(`refusing a non-emulator request: ${url}`));
  return track(realFetch(url, init));
};
