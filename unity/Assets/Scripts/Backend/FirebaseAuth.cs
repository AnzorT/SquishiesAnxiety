// Firebase Auth over its REST API (Identity Toolkit v1 + Secure Token), standing in for
// @react-native-firebase/auth as src/firebase/auth.js and social.js use it:
//   registerWithEmail / loginWithEmail / logout     → RegisterWithEmail / LoginWithEmail / SignOut
//   subscribeToAuthUser (onAuthStateChanged, with the "Keep me signed in" rule) → Start + AuthStateChanged
//   setKeepSignedIn                                  → SetKeepSignedIn
//   needsVerification / sendVerification / reloadVerified → AuthUser.NeedsVerification / SendVerification / ReloadVerified
//   signInWithCustomToken (social.js, after the OAuth web flow) → SignInWithCustomToken
//   user.getIdToken(force)                           → GetIdToken(force): cached, refreshed 5 minutes before expiry
// plus SendPasswordReset (the RN app has no reset screen yet; the REST call is the same one the SDK makes).
//
// The session (refresh token and the last ID token) is kept through IAuthStore; on Unity that's PlayerPrefs
// (Backend/Unity/PlayerPrefsAuthStore.cs).
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SquishSquad.Backend
{
    public sealed class AuthUser
    {
        public string Uid;
        public string Email;
        public string DisplayName;
        public bool EmailVerified;
        public List<string> ProviderIds = new List<string>(); // "password", "google.com"… (providerData[].providerId)

        // auth.js needsVerification: an email/password account that hasn't confirmed its address
        public bool NeedsVerification => !EmailVerified && ProviderIds.Contains("password");

        internal string IdToken;
        internal string RefreshToken;
        internal DateTime ExpiresAtUtc;

        internal AuthUser Copy() => (AuthUser)MemberwiseClone();
    }

    // Where the session survives app restarts. Unity: PlayerPrefsAuthStore.
    public interface IAuthStore
    {
        string Read(string key); // null when missing
        void Write(string key, string value);
        void Remove(string key);
    }

    public sealed class MemoryAuthStore : IAuthStore
    {
        readonly Dictionary<string, string> d = new Dictionary<string, string>();
        public string Read(string key) => d.TryGetValue(key, out var v) ? v : null;
        public void Write(string key, string value) => d[key] = value;
        public void Remove(string key) => d.Remove(key);
    }

    public sealed class FirebaseAuth
    {
        const string UserKey = "squish.auth.user";
        const string KeepKey = "squish.auth.keepSignedIn";
        static readonly TimeSpan RefreshEarly = TimeSpan.FromMinutes(5);

        readonly FirebaseConfig cfg;
        readonly IHttp http;
        readonly IAuthStore store;
        readonly Dispatcher dispatcher = new Dispatcher();
        readonly SemaphoreSlim refreshLock = new SemaphoreSlim(1, 1);
        AuthUser user;

        // The clock, swappable for tests.
        public Func<DateTime> UtcNow = () => DateTime.UtcNow;

        public FirebaseAuth(FirebaseConfig config, IHttp http, IAuthStore store)
        {
            cfg = config;
            this.http = http;
            this.store = store ?? new MemoryAuthStore();
        }

        public AuthUser CurrentUser => user;

        // onAuthStateChanged: the user on every sign-in / sign-out (null when signed out). Raised on the
        // SynchronizationContext this object was made on (Unity's main thread).
        public event Action<AuthUser> AuthStateChanged;

        // --- start-up and "Keep me signed in" -------------------------------------------------------------------

        // The login screen's box. A missing value means keep (accounts from before the box existed).
        public void SetKeepSignedIn(bool keep)
        {
            try
            {
                store.Write(KeepKey, keep ? "1" : "0");
            }
            catch
            {
                // not fatal: they just stay signed in
            }
        }

        public bool KeepSignedIn
        {
            get
            {
                try
                {
                    return store.Read(KeepKey) != "0";
                }
                catch
                {
                    return true;
                }
            }
        }

        // The app's first auth state (subscribeToAuthUser's first callback): the saved session, unless the box was
        // left unticked last time, in which case it's dropped and this is null. Raises AuthStateChanged once either
        // way. Works offline: the saved user comes back at once; its token is refreshed when first needed (a
        // refresh the server refuses, say for a deleted account, then signs out).
        public Task<AuthUser> Start()
        {
            var saved = LoadSaved();
            if (saved != null && !KeepSignedIn)
            {
                Clear();
                saved = null;
            }
            user = saved;
            Raise();
            return Task.FromResult(user);
        }

        // --- sign-in / sign-out ---------------------------------------------------------------------------------

        public async Task<AuthUser> RegisterWithEmail(string email, string password)
        {
            var r = await Post("accounts:signUp", new Dictionary<string, object>
            {
                { "email", email }, { "password", password }, { "returnSecureToken", true },
            }).ConfigureAwait(false);
            return await SignedIn(r).ConfigureAwait(false);
        }

        public async Task<AuthUser> LoginWithEmail(string email, string password)
        {
            var r = await Post("accounts:signInWithPassword", new Dictionary<string, object>
            {
                { "email", email }, { "password", password }, { "returnSecureToken", true },
            }).ConfigureAwait(false);
            return await SignedIn(r).ConfigureAwait(false);
        }

        // social.js: the token the `oauth` function's web flow hands back on com.plushcrush.app://auth?token=…
        public async Task<AuthUser> SignInWithCustomToken(string token)
        {
            var r = await Post("accounts:signInWithCustomToken", new Dictionary<string, object>
            {
                { "token", token }, { "returnSecureToken", true },
            }).ConfigureAwait(false);
            return await SignedIn(r).ConfigureAwait(false);
        }

        // Local, like the SDK's: forgets the session (the refresh token isn't revoked server-side).
        public Task SignOut()
        {
            bool was = user != null;
            Clear();
            user = null;
            if (was) Raise();
            return Task.CompletedTask;
        }

        // --- tokens ---------------------------------------------------------------------------------------------

        // The current ID token (for Firestore / Functions requests), refreshed when it's within 5 minutes of expiry
        // or `forceRefresh`. Throws when signed out.
        public async Task<string> GetIdToken(bool forceRefresh = false, CancellationToken cancel = default)
        {
            var u = user;
            if (u == null) throw new FirebaseAuthException("auth/no-current-user", null, 0);
            if (!forceRefresh && u.IdToken != null && UtcNow() < u.ExpiresAtUtc - RefreshEarly) return u.IdToken;
            await refreshLock.WaitAsync(cancel).ConfigureAwait(false);
            try
            {
                u = user; // another caller may have refreshed (or signed out) meanwhile
                if (u == null) throw new FirebaseAuthException("auth/no-current-user", null, 0);
                if (!forceRefresh && u.IdToken != null && UtcNow() < u.ExpiresAtUtc - RefreshEarly) return u.IdToken;
                return await Refresh(u, cancel).ConfigureAwait(false);
            }
            finally
            {
                refreshLock.Release();
            }
        }

        // The ID token's expiry (UTC), for tests and diagnostics.
        public DateTime? TokenExpiresAtUtc => user?.ExpiresAtUtc;

        async Task<string> Refresh(AuthUser u, CancellationToken cancel)
        {
            string body = "grant_type=refresh_token&refresh_token=" + Uri.EscapeDataString(u.RefreshToken ?? "");
            var req = new HttpRequest
            {
                Method = "POST",
                Url = cfg.SecureTokenBase + "/v1/token?key=" + Uri.EscapeDataString(cfg.ApiKey),
                Body = body,
                ContentType = "application/x-www-form-urlencoded",
            };
            foreach (var h in cfg.AuthHeaders) req.Headers[h.Key] = h.Value;
            Dictionary<string, object> r;
            try
            {
                r = await Send(req, cancel).ConfigureAwait(false);
            }
            catch (FirebaseAuthException e) when (AuthErrors.EndsSession(e.Code))
            {
                // the account is gone or disabled, or the session was revoked: signed out, as the SDK does
                if (user == u) await SignOut().ConfigureAwait(false);
                throw;
            }
            if (user != u) throw new FirebaseAuthException("auth/no-current-user", null, 0); // signed out meanwhile
            u.IdToken = Json.Str(r, "id_token");
            u.RefreshToken = Json.Str(r, "refresh_token") ?? u.RefreshToken;
            u.ExpiresAtUtc = UtcNow() + TimeSpan.FromSeconds(Seconds(Json.Str(r, "expires_in")));
            ApplyClaims(u, u.IdToken);
            Save(u);
            return u.IdToken;
        }

        // --- email verification / password reset ---------------------------------------------------------------

        // auth.js sendVerification: mails the signed-in user a verification link.
        public async Task SendVerification()
        {
            if (user == null) return;
            string token = await GetIdToken().ConfigureAwait(false);
            await Post("accounts:sendOobCode", new Dictionary<string, object> { { "requestType", "VERIFY_EMAIL" }, { "idToken", token } })
                .ConfigureAwait(false);
        }

        // auth.js reloadVerified: asks Firebase again (the link was tapped in a browser); true once verified. A
        // fresh ID token is fetched too once it is, so the rules see email_verified.
        public async Task<bool> ReloadVerified()
        {
            if (user == null) return false;
            var u = await Reload().ConfigureAwait(false);
            if (u != null && u.EmailVerified) await GetIdToken(true).ConfigureAwait(false);
            return user != null && user.EmailVerified;
        }

        public Task SendPasswordReset(string email) =>
            Post("accounts:sendOobCode", new Dictionary<string, object> { { "requestType", "PASSWORD_RESET" }, { "email", email } });

        // user.reload(): the account's current details (accounts:lookup).
        public async Task<AuthUser> Reload()
        {
            var u = user;
            if (u == null) return null;
            string token = await GetIdToken().ConfigureAwait(false);
            var r = await Post("accounts:lookup", new Dictionary<string, object> { { "idToken", token } }).ConfigureAwait(false);
            if (user != u) return user;
            ApplyLookup(u, r);
            Save(u);
            return u;
        }

        // --- internals ------------------------------------------------------------------------------------------

        async Task<AuthUser> SignedIn(Dictionary<string, object> r)
        {
            var u = new AuthUser
            {
                Uid = Json.Str(r, "localId"),
                Email = Json.Str(r, "email"),
                DisplayName = Json.Str(r, "displayName"),
                IdToken = Json.Str(r, "idToken"),
                RefreshToken = Json.Str(r, "refreshToken"),
                ExpiresAtUtc = UtcNow() + TimeSpan.FromSeconds(Seconds(Json.Str(r, "expiresIn"))),
            };
            ApplyClaims(u, u.IdToken);
            // emailVerified and the providers come from a lookup (the sign-in replies don't carry them all); the ID
            // token's claims above are the fallback when it fails
            try
            {
                var look = await Post("accounts:lookup", new Dictionary<string, object> { { "idToken", u.IdToken } }).ConfigureAwait(false);
                ApplyLookup(u, look);
            }
            catch (FirebaseAuthException)
            {
                // keep the claims
            }
            user = u;
            Save(u);
            Raise();
            return u;
        }

        static void ApplyLookup(AuthUser u, Dictionary<string, object> r)
        {
            var users = Json.Get(r, "users") as List<object>;
            if (users == null || users.Count == 0) return;
            var info = users[0];
            if (string.IsNullOrEmpty(u.Uid)) u.Uid = Json.Str(info, "localId");
            u.Email = Json.Str(info, "email") ?? u.Email;
            u.DisplayName = Json.Str(info, "displayName") ?? u.DisplayName;
            u.EmailVerified = Json.Get(info, "emailVerified") is bool b && b;
            var providers = new List<string>();
            if (Json.Get(info, "providerUserInfo") is List<object> pl)
                foreach (var p in pl)
                {
                    string id = Json.Str(p, "providerId");
                    if (id != null && !providers.Contains(id)) providers.Add(id);
                }
            u.ProviderIds = providers;
        }

        // The ID token's own claims: email_verified and how it signed in ("password", "custom", "google.com"…).
        static void ApplyClaims(AuthUser u, string idToken)
        {
            var claims = DecodeJwtPayload(idToken);
            if (claims == null) return;
            // signInWithCustomToken's reply has no localId: the token's user_id is the uid
            if (string.IsNullOrEmpty(u.Uid)) u.Uid = Json.Str(claims, "user_id") ?? Json.Str(claims, "sub");
            if (Json.Get(claims, "email_verified") is bool v) u.EmailVerified = v;
            string email = Json.Str(claims, "email");
            if (email != null) u.Email = email;
            if (u.ProviderIds.Count == 0)
            {
                string how = Json.Str(Json.Get(claims, "firebase"), "sign_in_provider");
                if (how != null && how != "custom" && how != "anonymous") u.ProviderIds.Add(how);
            }
        }

        public static Dictionary<string, object> DecodeJwtPayload(string jwt)
        {
            if (string.IsNullOrEmpty(jwt)) return null;
            var parts = jwt.Split('.');
            if (parts.Length < 2) return null;
            try
            {
                string b = parts[1].Replace('-', '+').Replace('_', '/');
                b += new string('=', (4 - b.Length % 4) % 4);
                return Json.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(b))) as Dictionary<string, object>;
            }
            catch
            {
                return null;
            }
        }

        static double Seconds(string s) =>
            double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var d) ? d : 3600;

        Task<Dictionary<string, object>> Post(string method, Dictionary<string, object> body)
        {
            var req = new HttpRequest
            {
                Method = "POST",
                Url = cfg.AuthBase + "/v1/" + method + "?key=" + Uri.EscapeDataString(cfg.ApiKey),
                Body = Json.Write(body),
            };
            foreach (var h in cfg.AuthHeaders) req.Headers[h.Key] = h.Value;
            return Send(req, default);
        }

        async Task<Dictionary<string, object>> Send(HttpRequest req, CancellationToken cancel)
        {
            HttpResult res;
            try
            {
                res = await http.Send(req, cancel).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (cancel.IsCancellationRequested)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new FirebaseAuthException("auth/network-request-failed", null, 0, e.Message, e);
            }
            var json = Json.TryParse(res.Body) as Dictionary<string, object>;
            if (res.Ok && json != null) return json;
            // { "error": { "code": 400, "message": "WEAK_PASSWORD : Password should be at least 6 characters" } }
            string msg = Json.Str(Json.Get(json, "error"), "message");
            string server = msg;
            if (server != null)
            {
                int cut = server.IndexOf(" : ", StringComparison.Ordinal);
                if (cut >= 0) server = server.Substring(0, cut);
                server = server.Trim();
            }
            string code = res.Status >= 500 && server == null ? "auth/network-request-failed" : AuthErrors.CodeForServer(server);
            throw new FirebaseAuthException(code, server, res.Status, msg ?? res.Body);
        }

        void Raise()
        {
            var u = user;
            var handler = AuthStateChanged;
            if (handler != null) dispatcher.Post(() => handler(u));
        }

        // --- persistence ----------------------------------------------------------------------------------------

        void Save(AuthUser u)
        {
            if (u != user) return;
            try
            {
                store.Write(UserKey, Json.Write(new Dictionary<string, object>
                {
                    { "uid", u.Uid },
                    { "email", u.Email },
                    { "displayName", u.DisplayName },
                    { "emailVerified", u.EmailVerified },
                    { "providers", u.ProviderIds },
                    { "refreshToken", u.RefreshToken },
                    { "idToken", u.IdToken },
                    { "expiresAt", u.ExpiresAtUtc.ToString("o", CultureInfo.InvariantCulture) },
                }));
            }
            catch
            {
                // can't persist: the session lasts until the app quits
            }
        }

        AuthUser LoadSaved()
        {
            try
            {
                var d = Json.TryParse(store.Read(UserKey)) as Dictionary<string, object>;
                if (d == null || Json.Str(d, "uid") == null || Json.Str(d, "refreshToken") == null) return null;
                var u = new AuthUser
                {
                    Uid = Json.Str(d, "uid"),
                    Email = Json.Str(d, "email"),
                    DisplayName = Json.Str(d, "displayName"),
                    EmailVerified = Json.Get(d, "emailVerified") is bool b && b,
                    RefreshToken = Json.Str(d, "refreshToken"),
                    IdToken = Json.Str(d, "idToken"),
                };
                if (Json.Get(d, "providers") is List<object> pl)
                    foreach (var p in pl)
                        if (p is string s) u.ProviderIds.Add(s);
                DateTime exp;
                u.ExpiresAtUtc = DateTime.TryParse(Json.Str(d, "expiresAt"), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out exp)
                    ? exp.ToUniversalTime()
                    : DateTime.MinValue;
                return u;
            }
            catch
            {
                return null;
            }
        }

        void Clear()
        {
            try
            {
                store.Remove(UserKey);
            }
            catch
            {
                // nothing saved, or can't reach it
            }
        }
    }
}
