// @react-native-firebase/app as src/firebase/callFunction.js uses it (the project id).
import { PROJECT } from './emulator.mjs';

export const firebase = { app: () => ({ options: { projectId: PROJECT } }) };
export default firebase;
