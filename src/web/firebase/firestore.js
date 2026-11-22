// Web only: @react-native-firebase/firestore → Firebase's web Firestore (see app.js). Same calls: firestore()
// .collection().doc().get()/set()/update()/onSnapshot(), runTransaction, snap.exists (a property in both),
// firestore.FieldValue.increment / arrayUnion / serverTimestamp / delete, firestore.Timestamp.
import 'firebase/compat/firestore';
import { firebase } from './app';

const firestore = () => firebase.firestore();
firestore.FieldValue = firebase.firestore.FieldValue;
firestore.Timestamp = firebase.firestore.Timestamp;
firestore.FieldPath = firebase.firestore.FieldPath;
firestore.GeoPoint = firebase.firestore.GeoPoint;

export { firebase };
export default firestore;
