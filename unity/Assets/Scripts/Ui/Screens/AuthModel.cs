// src/screens/AuthScreen.js's state and what its buttons do (log in, register with age and squad name, "Keep me
// signed in", the validation and the error lines word for word), with no drawing: AuthArt draws it, the Unity screen
// (App/AuthScreen.cs) feeds it taps and typing, and tools/unity/auth-test runs it against the Firebase emulators.
// App.js's auth listener moves past the screen once a sign-in lands (here: FirebaseAuth.AuthStateChanged).
using System;
using System.Threading.Tasks;
using SquishSquad.Backend;

namespace SquishSquad.Ui.Screens
{
    /// <summary>What the screen needs from Firebase (FirebaseClient, or a stand-in in tests).</summary>
    public interface IAuthBackend
    {
        void SetKeepSignedIn(bool keep);
        Task<string> Register(string email, string password);     // the new user's uid
        Task Login(string email, string password);
        Task CreateUserProfile(string uid, string email, double age, string nickname);
        Task SendVerification();
    }

    public sealed class FirebaseAuthBackend : IAuthBackend
    {
        readonly FirebaseClient _fb;
        public FirebaseAuthBackend(FirebaseClient fb) { _fb = fb; }
        public void SetKeepSignedIn(bool keep) => _fb.Auth.SetKeepSignedIn(keep);
        public async Task<string> Register(string email, string password) => (await _fb.Auth.RegisterWithEmail(email, password)).Uid;
        public Task Login(string email, string password) => _fb.Auth.LoginWithEmail(email, password);
        public Task CreateUserProfile(string uid, string email, double age, string nickname) => _fb.Data.CreateUserProfile(uid, email, age, nickname);
        public Task SendVerification() => _fb.Auth.SendVerification();
    }

    public sealed class AuthModel
    {
        // AuthScreen.js MIN_SIGNUP_AGE: under 13, registration stops on the device, before anything is sent
        public const int MinSignupAge = 13;
        public const int NicknameMax = 10, AgeMax = 3;   // the fields' maxLength
        /// <summary>Developer mode (develop's src/webDebug.js SKIP_EMAIL_VERIFY, 2026-11-21, the user: "when we run developer
        /// mode, ignore the 2-step authentication we do to new registers"): a new email account plays at once, no email
        /// sent, no verify screen. Set by the app (AppFlow: the editor and development builds); off in a release.</summary>
        public static bool SkipEmailVerify;

        public bool Register;          // mode === 'register'
        public string Age = "", Nickname = "", Email = "", Password = "";
        public bool ShowPass, Keep = true, Blocked, Submitting;
        public string Error = "";
        /// <summary>Bumped when the button's label changes (useFadeUp plays).</summary>
        public int LabelChanges;

        public string ButtonLabel => Register ? "CREATE MY SQUAD" : "LOG IN";   // (develop: the menu's lettering, capitals)

        /// <summary>switchMode: the register row opens or closes, the error goes, the age is asked again.</summary>
        public bool SwitchMode(bool register)
        {
            if (register == Register) return false;
            Register = register;
            Error = "";
            Age = "";
            Blocked = false;
            LabelChanges++;
            return true;
        }

        static string Trim(string s) => (s ?? "").Trim();

        /// <summary>submit(): checks the fields as the app does, then signs in or registers. Errors land in Error
        /// (FirebaseAuthException.Message is authErrors.js's text). Returns when the server has answered.</summary>
        public async Task Submit(IAuthBackend fb)
        {
            if (Submitting) return;
            string email = Trim(Email);
            if (Register)
            {
                // age first: nothing else is looked at, let alone sent, before it (parseInt, as the JS)
                int age = ParseIntJs(Age, out bool ok);
                if (Age.Length == 0 || !ok || age < 1 || age > 120) { Error = "Enter your age."; return; }
                if (age < MinSignupAge) { Error = ""; Blocked = true; return; }
                if (Trim(Nickname).Length < 2) { Error = "Pick a squad name of at least 2 letters."; return; }
                if (email.Length == 0 || Password.Length == 0) { Error = "Enter your email and password."; return; }
                if (Password.Length < 6) { Error = "Password needs at least 6 characters."; return; }
                Error = "";
                Submitting = true;
                try
                {
                    fb.SetKeepSignedIn(Keep);
                    string uid = await fb.Register(email, Password);
                    await fb.CreateUserProfile(uid, email, age, Nickname);
                    // the link that proves the address is real (the verify screen waits for it); a failed send can be
                    // retried there
                    if (!SkipEmailVerify) { try { await fb.SendVerification(); } catch (Exception) { } }   // (developer mode: no email)
                }
                catch (Exception e)
                {
                    Error = AuthErrors.MessageFor(e);
                    Submitting = false;
                }
                return;
            }
            if (email.Length == 0 || Password.Length == 0) { Error = "Enter your email and password."; return; }
            Error = "";
            Submitting = true;
            try
            {
                fb.SetKeepSignedIn(Keep);
                await fb.Login(email, Password);
            }
            catch (Exception e)
            {
                Error = AuthErrors.MessageFor(e);
                Submitting = false;
            }
        }

        // parseInt(s, 10): leading spaces, a sign, then digits up to the first non-digit; NaN when there are none
        public static int ParseIntJs(string s, out bool ok)
        {
            ok = false;
            int i = 0, sign = 1;
            s ??= "";
            while (i < s.Length && char.IsWhiteSpace(s[i])) i++;
            if (i < s.Length && (s[i] == '+' || s[i] == '-')) { if (s[i] == '-') sign = -1; i++; }
            long v = 0;
            int start = i;
            while (i < s.Length && s[i] >= '0' && s[i] <= '9' && v < int.MaxValue) { v = v * 10 + (s[i] - '0'); i++; }
            if (i == start) return 0;
            ok = true;
            return (int)Math.Min(int.MaxValue, v) * sign;
        }
    }
}
