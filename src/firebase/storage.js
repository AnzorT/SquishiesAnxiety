import storage from '@react-native-firebase/storage';

// Cloud Storage helpers for the creature-creator flow. The source photo is
// uploaded here; the generated .glb is written back by the
// `generateCustomModel` Cloud Function (see functions/index.js) and reached
// through the `modelUrl` it puts on the Firestore doc.

// Uploads a local image file and returns { path, url }. `url` is a tokenised
// Firebase download URL — the Cloud Function hands it straight to Tripo as
// the image_to_model source, so it must be publicly fetchable (it is: the
// token grants read without auth).
export async function uploadSourceImage(uid, localUri, id) {
  const path = `customUploads/${uid}/${id}.jpg`;
  const ref = storage().ref(path);
  await ref.putFile(localUri, { contentType: 'image/jpeg' });
  const url = await ref.getDownloadURL();
  return { path, url };
}

// Best-effort cleanup when a custom creature is deleted.
export async function deleteCustomAssets({ sourceImagePath, modelPath }) {
  const jobs = [];
  if (sourceImagePath) jobs.push(storage().ref(sourceImagePath).delete().catch(() => {}));
  if (modelPath) jobs.push(storage().ref(modelPath).delete().catch(() => {}));
  await Promise.all(jobs);
}
