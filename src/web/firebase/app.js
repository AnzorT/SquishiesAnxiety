// Web only (metro.config.js swaps @react-native-firebase/app for this): Firebase's own web SDK, in its "compat" form,
// whose calls are the same as @react-native-firebase's (firestore().collection(...).doc(...), auth().currentUser...),
// so src/firebase/*.js runs unchanged. The project is the Android app's: its values come from google-services.json
// (its key works from a browser; checked 2026-11-14). Signing in keeps the session in the browser (IndexedDB).
import firebase from 'firebase/compat/app';

const g = require('../../../google-services.json');

if (!firebase.apps.length) {
  const id = g.project_info.project_id;
  firebase.initializeApp({
    apiKey: g.client[0].api_key[0].current_key,
    authDomain: `${id}.firebaseapp.com`,
    projectId: id,
    storageBucket: g.project_info.storage_bucket,
    messagingSenderId: g.project_info.project_number,
  });
}

export { firebase };
export default firebase;
