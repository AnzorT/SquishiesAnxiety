// Web only: @react-native-firebase/auth → Firebase's web auth (see app.js).
import 'firebase/compat/auth';
import { firebase } from './app';

const auth = () => firebase.auth();
auth.EmailAuthProvider = firebase.auth.EmailAuthProvider;
auth.GoogleAuthProvider = firebase.auth.GoogleAuthProvider;

export { firebase };
export default auth;
