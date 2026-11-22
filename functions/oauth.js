// Social sign-in (REDESIGN_V6 step 8, ruling 4): Google, Facebook and TikTok,
// all through one web flow, so the app needs no native SDK per provider:
//
//   app → browser: GET /oauth/start?provider=google
//   function → the provider's consent page (redirect_uri = /oauth/callback)
//   provider → GET /oauth/callback?code&state
//   function: code → token → the provider's user id (and email, name) →
//     the Firebase user `<provider>:<id>` (made the first time, with a
//     profile) → a custom token → com.plushcrush.app://auth?token=…
//   app: signInWithCustomToken
//
// The providers' client ids and secrets live in Firestore `secrets/oauth`
// (admin-only: firestore.rules denies every client), written by
// tools/admin/oauth.mjs. A provider without them shows a "not set up yet"
// page instead. This file is the pure part (tested by oauth.test.js); the
// HTTP handler is in index.js.

const crypto = require('crypto');

const APP_RETURN = 'com.plushcrush.app://auth';
const STATE_TTL_MS = 10 * 60 * 1000;

const PROVIDERS = {
  google: {
    name: 'Google',
    authorize: 'https://accounts.google.com/o/oauth2/v2/auth',
    token: 'https://oauth2.googleapis.com/token',
    scope: 'openid email profile',
    idKey: 'clientId',
  },
  facebook: {
    name: 'Facebook',
    authorize: 'https://www.facebook.com/v19.0/dialog/oauth',
    token: 'https://graph.facebook.com/v19.0/oauth/access_token',
    scope: 'public_profile,email',
    idKey: 'clientId',
  },
  tiktok: {
    name: 'TikTok',
    authorize: 'https://www.tiktok.com/v2/auth/authorize/',
    token: 'https://open.tiktokapis.com/v2/oauth/token/',
    scope: 'user.info.basic',
    idKey: 'clientKey',
  },
};

const b64u = (buf) => Buffer.from(buf).toString('base64url');

// A signed, short-lived state: which provider, when, and a nonce.
function makeState(provider, key, now = Date.now()) {
  const body = b64u(JSON.stringify({ p: provider, t: now, n: b64u(crypto.randomBytes(9)) }));
  const sig = b64u(crypto.createHmac('sha256', key).update(body).digest());
  return `${body}.${sig}`;
}

function readState(state, key, now = Date.now()) {
  const [body, sig] = String(state || '').split('.');
  if (!body || !sig) return null;
  const want = b64u(crypto.createHmac('sha256', key).update(body).digest());
  if (want.length !== sig.length || !crypto.timingSafeEqual(Buffer.from(want), Buffer.from(sig))) return null;
  let s;
  try {
    s = JSON.parse(Buffer.from(body, 'base64url').toString('utf8'));
  } catch (e) {
    return null;
  }
  if (!PROVIDERS[s.p] || !(now - s.t >= 0 && now - s.t < STATE_TTL_MS)) return null;
  return s;
}

// The provider's consent page.
function authorizeUrl(provider, cfg, redirectUri, state) {
  const P = PROVIDERS[provider];
  const q = new URLSearchParams({ response_type: 'code', redirect_uri: redirectUri, state, scope: P.scope });
  q.set(P.idKey === 'clientKey' ? 'client_key' : 'client_id', cfg[P.idKey]);
  if (provider === 'google') q.set('prompt', 'select_account');
  return `${P.authorize}?${q}`;
}

// What to POST (or GET) to swap the code for a token.
function tokenRequest(provider, cfg, code, redirectUri) {
  const P = PROVIDERS[provider];
  if (provider === 'facebook') {
    const q = new URLSearchParams({ client_id: cfg.clientId, client_secret: cfg.secret, redirect_uri: redirectUri, code });
    return { method: 'GET', url: `${P.token}?${q}` };
  }
  const body = new URLSearchParams({ code, grant_type: 'authorization_code', redirect_uri: redirectUri });
  if (provider === 'tiktok') {
    body.set('client_key', cfg.clientKey);
    body.set('client_secret', cfg.secret);
  } else {
    body.set('client_id', cfg.clientId);
    body.set('client_secret', cfg.secret);
  }
  return { method: 'POST', url: P.token, body: body.toString(), headers: { 'Content-Type': 'application/x-www-form-urlencoded' } };
}

// The provider's user from its token answer (and, for Facebook and TikTok,
// a profile call): { id, email, emailVerified, name }.
function decodeJwtPayload(jwt) {
  try {
    return JSON.parse(Buffer.from(String(jwt).split('.')[1], 'base64url').toString('utf8'));
  } catch (e) {
    return null;
  }
}
function profileRequest(provider, tokenAnswer) {
  if (provider === 'facebook') return { method: 'GET', url: `https://graph.facebook.com/me?fields=id,name,email&access_token=${encodeURIComponent(tokenAnswer.access_token)}` };
  if (provider === 'tiktok') return { method: 'GET', url: 'https://open.tiktokapis.com/v2/user/info/?fields=open_id,union_id,display_name', headers: { Authorization: `Bearer ${tokenAnswer.access_token}` } };
  return null; // Google: the id_token holds it
}
function userOf(provider, tokenAnswer, profile) {
  if (provider === 'google') {
    // the id_token came straight from Google's token endpoint over TLS, in
    // answer to our own code: its claims are trusted as they are
    const c = decodeJwtPayload(tokenAnswer.id_token);
    if (!c || !c.sub) return null;
    return { id: String(c.sub), email: c.email || null, emailVerified: !!c.email_verified, name: c.given_name || c.name || null };
  }
  if (provider === 'facebook') {
    if (!profile || !profile.id) return null;
    // Facebook only shares confirmed emails
    return { id: String(profile.id), email: profile.email || null, emailVerified: !!profile.email, name: profile.name || null };
  }
  if (provider === 'tiktok') {
    const u = profile && profile.data && profile.data.user;
    const id = (u && (u.union_id || u.open_id)) || tokenAnswer.open_id;
    if (!id) return null;
    return { id: String(id), email: null, emailVerified: false, name: (u && u.display_name) || null };
  }
  return null;
}

const uidOf = (provider, id) => `${provider}:${id}`.slice(0, 128);
// a squad name from the provider's name (2-10 letters, as Register allows)
function nicknameOf(name) {
  const n = String(name || '').trim().split(/\s+/)[0].slice(0, 10);
  return n.length >= 2 ? n : 'Squisher';
}

// The page the browser ends on: back to the app with the token.
function returnPage(token) {
  const to = `${APP_RETURN}?token=${encodeURIComponent(token)}`;
  return `<!doctype html><html><head><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1"><title>Squish Squad</title></head>
<body style="margin:0;font-family:sans-serif;background:#b9e2ff;color:#45107a;display:flex;align-items:center;justify-content:center;height:100vh;text-align:center">
<div><h2>You're in!</h2><p><a href="${to}" style="color:#c02bd9;font-weight:bold">Back to Squish Squad</a></p></div>
<script>location.replace(${JSON.stringify(to)});</script></body></html>`;
}
function messagePage(title, text) {
  const esc = (s) => String(s).replace(/[&<>"]/g, (c) => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;' })[c]);
  return `<!doctype html><html><head><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1"><title>Squish Squad</title></head>
<body style="margin:0;font-family:sans-serif;background:#b9e2ff;color:#45107a;display:flex;align-items:center;justify-content:center;height:100vh;text-align:center;padding:24px;box-sizing:border-box">
<div><h2>${esc(title)}</h2><p>${esc(text)}</p><p><a href="${APP_RETURN}?error=1" style="color:#c02bd9;font-weight:bold">Back to Squish Squad</a></p></div></body></html>`;
}

module.exports = { PROVIDERS, APP_RETURN, STATE_TTL_MS, makeState, readState, authorizeUrl, tokenRequest, profileRequest, userOf, uidOf, nicknameOf, returnPage, messagePage };
