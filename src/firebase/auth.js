import auth from '@react-native-firebase/auth';

// Thin wrapper around @react-native-firebase/auth — the native SDK already
// auto-initializes from android/app/google-services.json, so there's no
// config object to build here.

export function subscribeToAuthUser(onChange) {
  return auth().onAuthStateChanged(onChange);
}

export async function registerWithEmail(email, password) {
  const credential = await auth().createUserWithEmailAndPassword(email, password);
  return credential.user;
}

export async function loginWithEmail(email, password) {
  const credential = await auth().signInWithEmailAndPassword(email, password);
  return credential.user;
}

export async function logout() {
  await auth().signOut();
}
