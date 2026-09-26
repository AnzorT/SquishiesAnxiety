import storage from '@react-native-firebase/storage';
import auth from '@react-native-firebase/auth';

// Cloud Storage helpers for the creature-creator flow. The source photo is
// uploaded here; the generated .glb is written back by the
// `generateCustomModel` Cloud Function (see functions/index.js) and reached
// through the `modelUrl` it puts on the Firestore doc.

const sleep = (ms) => new Promise((resolve) => setTimeout(resolve, ms));

// Uploads a local image file and returns { path, url }. `url` is a tokenised
// Firebase download URL — the Cloud Function hands it straight to Tripo as
// the image_to_model source, so it must be publicly fetchable (it is: the
// token grants read without auth).
//
// A brand-new account (just signed up, then straight into "create a 3D
// creature") can hit `storage/unauthorized` on the very first attempt even
// though the security rule and the local ID token are both actually valid —
// a documented Firebase quirk where a freshly minted token takes a few
// seconds to fully propagate to the Storage rules-evaluation backend. Forcing
// a fresh token plus a couple of short-delay retries rides out that window
// instead of surfacing a false "check your connection" to a first-time user.
export async function uploadSourceImage(uid, localUri, id) {
  const path = `customUploads/${uid}/${id}.jpg`;
  const ref = storage().ref(path);
  const attempts = [0, 1500, 4000];
  for (let i = 0; i < attempts.length; i++) {
    if (attempts[i]) await sleep(attempts[i]);
    try {
      // true = force a fresh token rather than the SDK's locally cached one.
      await auth().currentUser?.getIdToken(true);
      await ref.putFile(localUri, { contentType: 'image/jpeg' });
      const url = await ref.getDownloadURL();
      return { path, url };
    } catch (e) {
      if (e?.code !== 'storage/unauthorized' || i === attempts.length - 1) throw e;
    }
  }
}

// Best-effort cleanup when a custom creature is deleted.
export async function deleteCustomAssets({ sourceImagePath, modelPath }) {
  const jobs = [];
  if (sourceImagePath) jobs.push(storage().ref(sourceImagePath).delete().catch(() => {}));
  if (modelPath) jobs.push(storage().ref(modelPath).delete().catch(() => {}));
  await Promise.all(jobs);
}
