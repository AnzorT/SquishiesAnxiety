// @react-native-firebase/auth as src/firebase/callFunction.js uses it (the signed-in user's ID token).
import { auth as emulatorAuth } from './emulator.mjs';

export default function auth() {
  return {
    get currentUser() {
      return emulatorAuth.currentUser;
    },
  };
}
