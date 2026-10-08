import auth from '@react-native-firebase/auth';
import * as FileSystem from 'expo-file-system';

// Thin wrapper around @react-native-firebase/auth — the native SDK already
// auto-initializes from android/app/google-services.json, so there's no
// config object to build here.

// The login screen's "Keep me signed in" box. Firebase always keeps the
// session, so when the box was left unticked, the first auth state of the
// next app run signs the person out instead of letting them in. A missing
// file means keep (every account from before the box existed).
const KEEP_PATH = `${FileSystem.documentDirectory}keepSignedIn.txt`;

export async function setKeepSignedIn(keep) {
  try {
    await FileSystem.writeAsStringAsync(KEEP_PATH, keep ? '1' : '0');
  } catch {
    // not fatal: they just stay signed in
  }
}

async function keepSignedIn() {
  try {
    const info = await FileSystem.getInfoAsync(KEEP_PATH);
    return !info.exists || (await FileSystem.readAsStringAsync(KEEP_PATH)) !== '0';
  } catch {
    return true;
  }
}

export function subscribeToAuthUser(onChange) {
  let first = true;
  let live = true;
  const unsub = auth().onAuthStateChanged(async (user) => {
    if (first) {
      first = false;
      if (user && !(await keepSignedIn())) {
        try {
          await auth().signOut();
          return; // the sign-out fires this listener again, with null
        } catch {
          // couldn't: let them in rather than hang on the loading screen
        }
      }
    }
    if (live) onChange(user);
  });
  return () => {
    live = false;
    unsub();
  };
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
