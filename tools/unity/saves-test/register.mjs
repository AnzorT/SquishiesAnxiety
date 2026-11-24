// node --import ./register.mjs app.mjs …: runs the app's own src/ (firestore.js, the games' levels.js, squad/api.js)
// in Node. hooks.mjs swaps the React Native Firebase modules for shims/ (the Firebase JS SDK on the emulators) and
// resolves the app's extensionless imports as Metro does.
import { register } from 'node:module';

register('./hooks.mjs', import.meta.url);
