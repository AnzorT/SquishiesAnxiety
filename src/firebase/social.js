import { Linking } from 'react-native';
import auth from '@react-native-firebase/auth';

// Google / Facebook / TikTok sign-in (REDESIGN_V6 step 8): one web flow run
// by the `oauth` Cloud Function (functions/oauth.js). The browser opens its
// /start page; after the provider's consent it sends the player back to
// com.plushcrush.app://auth?token=… and the token signs them in. A provider
// that isn't set up yet shows a "coming soon" page instead.
const BASE = 'https://us-central1-squishy-app-61445.cloudfunctions.net/oauth';
const RETURN = 'com.plushcrush.app://auth';

export const startSocial = (provider) => Linking.openURL(`${BASE}/start?provider=${encodeURIComponent(provider)}`);

// Signs in with the token a return link carries; returns the unsubscribe.
export function listenForSocial(onError) {
  const handle = (url) => {
    if (!url || !url.startsWith(RETURN)) return;
    const m = /[?&]token=([^&]+)/.exec(url);
    if (!m) return;
    auth()
      .signInWithCustomToken(decodeURIComponent(m[1]))
      .catch((e) => onError && onError(e));
  };
  Linking.getInitialURL().then(handle).catch(() => {});
  const sub = Linking.addEventListener('url', (e) => handle(e.url));
  return () => sub.remove();
}
