import { firebase } from '@react-native-firebase/app';
import auth from '@react-native-firebase/auth';

// Calls a Firebase "callable" Cloud Function (functions/index.js) over plain
// HTTPS with the signed-in player's ID token — the same protocol the
// Functions SDK uses, without adding its native module to the app.
// Resolves the function's return value; rejects with its error message.

const REGION = 'us-central1';

export default async function callFunction(name, data = {}) {
  const user = auth().currentUser;
  if (!user) throw new Error('Not signed in');
  const token = await user.getIdToken();
  const { projectId } = firebase.app().options;
  const res = await fetch(`https://${REGION}-${projectId}.cloudfunctions.net/${name}`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json', Authorization: `Bearer ${token}` },
    body: JSON.stringify({ data }),
  });
  const body = await res.json().catch(() => ({}));
  if (!res.ok || body.error) throw new Error((body.error && body.error.message) || `HTTP ${res.status}`);
  return body.result;
}
