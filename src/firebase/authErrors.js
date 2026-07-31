const MESSAGES = {
  'auth/email-already-in-use': 'That email is already registered — try logging in instead.',
  'auth/invalid-email': "That email address doesn't look right.",
  'auth/weak-password': 'Password needs at least 6 characters.',
  'auth/user-not-found': 'No account found with that email.',
  'auth/wrong-password': 'Incorrect password.',
  'auth/invalid-credential': 'Incorrect email or password.',
  'auth/network-request-failed': 'Network error — check your connection.',
  'auth/too-many-requests': 'Too many attempts — wait a bit and try again.',
};

export function authErrorMessage(error) {
  return MESSAGES[error?.code] || 'Something went wrong. Please try again.';
}
