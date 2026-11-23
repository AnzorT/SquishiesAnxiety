// @react-native-firebase/firestore as src/firebase/firestore.js uses it (firestore().collection().doc().update(),
// firestore.FieldValue.*), on the Firebase JS SDK. The same update objects go to the same documents; RN Firebase
// serializes numbers as the JS SDK does (a safe integer is an integerValue). One difference: RN Firebase's native
// FieldValue.increment always sends a double operand (Android/iOS increment(double)), the JS SDK an integer one for a
// whole number, like the Unity client.
import {
  addDoc,
  arrayRemove,
  arrayUnion,
  collection,
  deleteField,
  doc,
  getDoc,
  increment,
  serverTimestamp,
  setDoc,
  updateDoc,
} from 'firebase/firestore';
import { db, track } from './emulator.mjs';

function docApi(ref) {
  return {
    id: ref.id,
    update: (data) => track(updateDoc(ref, data)),
    set: (data, options) => track(setDoc(ref, data, options || {})),
    get: async () => {
      const s = await getDoc(ref);
      return { id: s.id, exists: s.exists(), data: () => s.data() };
    },
    collection: (name) => collectionApi(collection(ref, name)),
  };
}

function collectionApi(ref) {
  return {
    doc: (id) => docApi(id ? doc(ref, id) : doc(ref)),
    add: (data) => track(addDoc(ref, data)),
  };
}

export default function firestore() {
  return { collection: (name) => collectionApi(collection(db, name)) };
}

firestore.FieldValue = { increment, arrayUnion, arrayRemove, serverTimestamp, delete: deleteField };
