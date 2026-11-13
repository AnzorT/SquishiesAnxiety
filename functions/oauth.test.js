// node oauth.test.js
const assert = require('assert');
const O = require('./oauth');

const KEY = 'k3y';
const st = O.makeState('google', KEY, 1000);
assert.strictEqual(O.readState(st, KEY, 2000).p, 'google');
assert.strictEqual(O.readState(st, 'other', 2000), null);
assert.strictEqual(O.readState(st, KEY, 1000 + O.STATE_TTL_MS + 1), null);
assert.strictEqual(O.readState(`${st.slice(0, -1)}${st.endsWith('A') ? 'B' : 'A'}`, KEY, 2000), null);
assert.strictEqual(O.readState('junk', KEY), null);

const u = new URL(O.authorizeUrl('google', { clientId: 'cid' }, 'https://x/cb', 's'));
assert.strictEqual(u.searchParams.get('client_id'), 'cid');
assert.strictEqual(u.searchParams.get('redirect_uri'), 'https://x/cb');
assert.strictEqual(new URL(O.authorizeUrl('tiktok', { clientKey: 'ck' }, 'r', 's')).searchParams.get('client_key'), 'ck');

const t = O.tokenRequest('google', { clientId: 'a', secret: 'b' }, 'c', 'r');
assert.strictEqual(t.method, 'POST');
assert.ok(t.body.includes('client_secret=b'));
assert.ok(O.tokenRequest('facebook', { clientId: 'a', secret: 'b' }, 'c', 'r').url.includes('client_secret=b'));

const jwt = `x.${Buffer.from(JSON.stringify({ sub: '42', email: 'e@x.com', email_verified: true, given_name: 'Ana' })).toString('base64url')}.y`;
assert.deepStrictEqual(O.userOf('google', { id_token: jwt }), { id: '42', email: 'e@x.com', emailVerified: true, name: 'Ana' });
assert.deepStrictEqual(O.userOf('facebook', {}, { id: '7', name: 'Bo Li' }), { id: '7', email: null, emailVerified: false, name: 'Bo Li' });
assert.strictEqual(O.userOf('tiktok', {}, { data: { user: { open_id: 'o1', display_name: 'Tik' } } }).id, 'o1');
assert.strictEqual(O.userOf('google', { id_token: 'bad' }), null);
assert.strictEqual(O.uidOf('google', '42'), 'google:42');
assert.strictEqual(O.nicknameOf('Anastasia Long'), 'Anastasia');
assert.strictEqual(O.nicknameOf(''), 'Squisher');
assert.ok(O.returnPage('t0k').includes('com.plushcrush.app://auth?token=t0k'));
assert.ok(!O.messagePage('<b>', 'x').includes('<b>'));
console.log('oauth.test.js: all passed');
