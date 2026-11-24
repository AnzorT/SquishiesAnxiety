// The start-up screens' logic against the Firebase Local Emulator Suite (tools/unity/backend/start-emulators.sh:
// auth 9099, firestore 8080, functions 5001, project demo-squish). Every request goes through LocalOnly, which refuses
// anything but 127.0.0.1 / localhost: this can never reach the live project.
//
//   AuthModel: the form's checks (no request is made for any of them), register (profile, verification mail, "Keep me
//   signed in"), the server's errors in the app's words, log in; VerifyModel: not yet, send again, verified after the
//   link; AppStage: which screen each account gets; HudValues: the new profile as the menu shows it.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SquishSquad.Backend;
using SquishSquad.Menu;
using SquishSquad.Ui.Screens;

static class Emu
{
    sealed class LocalOnly : IHttp
    {
        readonly IHttp inner = new HttpClientHttp(TimeSpan.FromSeconds(30));
        public int Requests;
        public Task<HttpResult> Send(HttpRequest r, CancellationToken cancel = default)
        {
            var u = new Uri(r.Url);
            if (!(u.Host == "127.0.0.1" || u.Host == "localhost") || u.Scheme != "http") throw new InvalidOperationException("refusing a non-emulator request: " + r.Url);
            Interlocked.Increment(ref Requests);
            return inner.Send(r, cancel);
        }
    }

    static int pass, fail;
    static readonly List<string> Failures = new List<string>();
    static void Check(bool ok, string what)
    {
        if (ok) pass++; else { fail++; Failures.Add(what); }
        Console.WriteLine($"  {(ok ? "ok  " : "FAIL")} {what}");
    }

    static string Host => Environment.GetEnvironmentVariable("EMULATOR_HOST") ?? "127.0.0.1";

    public static async Task<int> Run()
    {
        SynchronizationContext.SetSynchronizationContext(null);
        var http = new LocalOnly();
        var cfg = FirebaseConfig.Emulator("demo-squish", Host);
        var store = new MemoryAuthStore();
        var fb = new FirebaseClient(cfg, store, http);
        var states = new List<AuthUser>();
        fb.Auth.AuthStateChanged += u => states.Add(u);
        await fb.Auth.Start();
        string run = DateTime.UtcNow.Ticks.ToString("x");
        string email = $"unity-auth-{run}@example.com", pwd = "secret12";
        var backend = new FirebaseAuthBackend(fb);

        Console.WriteLine("the form's checks (nothing sent):");
        int before = http.Requests;
        var m = new AuthModel();
        await m.Submit(backend);
        Check(m.Error == "Enter your email and password." && !m.Submitting, "log in, empty: " + m.Error);
        m.SwitchMode(true);
        await m.Submit(backend);
        Check(m.Error == "Enter your age.", "register, no age: " + m.Error);
        foreach (var bad in new[] { "abc", "0", "121", "-5" }) { m.Age = bad; await m.Submit(backend); Check(m.Error == "Enter your age." && !m.Blocked, $"register, age \"{bad}\": {m.Error}"); }
        m.Age = "9"; m.Nickname = "Mia"; m.Email = email; m.Password = pwd;
        await m.Submit(backend);
        Check(m.Blocked && m.Error == "", "register, age 9: blocked (the parent line), nothing else looked at");
        m.SwitchMode(false); m.SwitchMode(true);
        Check(!m.Blocked && m.Age == "", "switching back to Register asks the age again");
        m.Age = "13"; m.Nickname = " M ";
        await m.Submit(backend);
        Check(m.Error == "Pick a squad name of at least 2 letters.", "register, squad name \" M \": " + m.Error);
        m.Nickname = " Mia "; m.Email = "  "; m.Password = pwd;
        await m.Submit(backend);
        Check(m.Error == "Enter your email and password.", "register, no email: " + m.Error);
        m.Email = email; m.Password = "12345";
        await m.Submit(backend);
        Check(m.Error == "Password needs at least 6 characters.", "register, 5-letter password: " + m.Error);
        m.Age = "13abc"; m.Password = pwd;   // parseInt reads 13, as the app's
        Check(AuthModel.ParseIntJs("13abc", out var okp) == 13 && okp, "parseInt(\"13abc\") = 13, as the JS");
        Check(http.Requests == before, $"no request for any of them ({http.Requests - before})");

        Console.WriteLine("register:");
        var bad1 = new AuthModel { Register = true, Age = "14", Nickname = "Mia", Email = "not-an-email", Password = pwd };
        await bad1.Submit(backend);
        Check(bad1.Error == "That email address doesn't look right." && !bad1.Submitting, "a malformed email: " + bad1.Error);
        m.Age = "14"; m.Keep = false;
        await m.Submit(backend);
        var user = fb.Auth.CurrentUser;
        Check(m.Error == "" && m.Submitting && user != null && user.Email == email, "signed up and in (the button stays on its dots until the screen goes)");
        Check(states.Count >= 2 && states.Last()?.Uid == user?.Uid, "AuthStateChanged told the app");
        Check(user != null && user.NeedsVerification, "a new email account needs verifying");
        Check(store.Read("squish.auth.keepSignedIn") == "0", "\"Keep me signed in\" unticked was saved");
        var profile = await fb.Data.GetProfile(user.Uid);
        Check(profile != null && (string)profile["nickname"] == "Mia" && (double)profile["age"] == 14 && (string)profile["email"] == email && (double)profile["coins"] == 250 && (string)profile["tut"] == "start",
            "createUserProfile: nickname \"Mia\" (trimmed), age 14, 250 coins, the tutorial's start");
        var codes = await OobCodes(http);
        Check(codes.Any(c => (string)c["email"] == email && (string)c["requestType"] == "VERIFY_EMAIL"), "the verification mail was sent");
        Check(AppStage.Of(true, true, user, false) == AppStage.Verify, "AppStage: the verify screen");
        Check(!AppStage.SplashReady(true, user, false) && AppStage.SplashReady(true, user, true) && AppStage.SplashReady(true, null, false), "AppStage: the splash waits for the profile when signed in");
        var hud = HudValues.FromProfile(profile);
        Check(hud.Coins == 250 && hud.Gems == 600 && hud.Level == 1 && hud.Into == 0 && hud.Need == 200 && hud.HasXp,
            $"the menu shows {HudValues.Fmt(hud.Coins)} coins, {HudValues.Fmt(hud.Gems)} gems (no gems yet: 600), level {hud.Level}, {hud.Into}/{hud.Need} XP");

        Console.WriteLine("the same email again:");
        var dup = new AuthModel { Register = true, Age = "20", Nickname = "Again", Email = email, Password = pwd };
        var other = new FirebaseClient(cfg, new MemoryAuthStore(), http);
        await dup.Submit(new FirebaseAuthBackend(other));
        Check(dup.Error == "That email is already registered — try logging in instead." && !dup.Submitting, dup.Error);

        Console.WriteLine("verify:");
        var vb = new FirebaseVerifyBackend(fb);
        var v = new VerifyModel { Email = email };
        Check(!await v.Check(vb) && v.Note == "Not yet — tap the link in the email first. Check your spam folder too." && !v.Busy, "I've verified, too early: " + v.Note);
        await v.Resend(vb);
        Check(v.Note == $"Sent again to {email}.", "Send it again: " + v.Note);
        codes = await OobCodes(http);
        var code = codes.Last(c => (string)c["email"] == email && (string)c["requestType"] == "VERIFY_EMAIL");
        var apply = await http.Send(new HttpRequest
        {
            Method = "POST",
            Url = $"http://{Host}:9099/identitytoolkit.googleapis.com/v1/accounts:update?key=fake-api-key",
            Body = Json.Write(new Dictionary<string, object> { { "oobCode", code["oobCode"] } }),
        });
        Check(apply.Ok, "the link tapped (the emulator's oobCode applied)");
        Check(await v.Check(vb) && !fb.Auth.CurrentUser.NeedsVerification, "I've verified: verified");
        Check(AppStage.Of(true, true, fb.Auth.CurrentUser, false) == AppStage.Menu, "AppStage: the menu");

        Console.WriteLine("keep me signed in, sign out, log in:");
        Check(await new FirebaseAuth(cfg, http, store).Start() == null, "unticked: the next start begins signed out");
        await fb.Auth.SignOut();
        Check(fb.Auth.CurrentUser == null && states.Last() == null && AppStage.Of(true, true, null, false) == AppStage.Auth, "signed out: the log in screen");
        var wrong = new AuthModel { Email = email, Password = "nope-nope" };
        await wrong.Submit(backend);
        Check((wrong.Error == "Incorrect email or password." || wrong.Error == "Incorrect password.") && !wrong.Submitting, "a wrong password: " + wrong.Error);
        var nobody = new AuthModel { Email = $"nobody-{run}@example.com", Password = pwd };
        await nobody.Submit(backend);
        Check((nobody.Error == "No account found with that email." || nobody.Error == "Incorrect email or password.") && !nobody.Submitting, "no such account: " + nobody.Error);
        var login = new AuthModel { Email = "  " + email + " ", Password = pwd, Keep = true };
        await login.Submit(backend);
        Check(login.Error == "" && fb.Auth.CurrentUser?.Email == email && !fb.Auth.CurrentUser.NeedsVerification, "logged in (the email trimmed), verified");
        Check(store.Read("squish.auth.keepSignedIn") == "1" && (await new FirebaseAuth(cfg, http, store).Start())?.Email == email, "ticked: the next start is still signed in");
        Check(AppStage.Of(true, true, fb.Auth.CurrentUser, false) == AppStage.Menu, "AppStage: straight to the menu");

        Console.WriteLine($"\n{pass} passed, {fail} failed; {http.Requests} requests, all to {Host}");
        foreach (var f in Failures) Console.WriteLine("  failed: " + f);
        return fail == 0 ? 0 : 1;
    }

    static async Task<List<IDictionary<string, object>>> OobCodes(IHttp http)
    {
        var res = await http.Send(new HttpRequest { Url = $"http://{Host}:9099/emulator/v1/projects/demo-squish/oobCodes" });
        return ((List<object>)Json.Get(Json.Parse(res.Body), "oobCodes")).Cast<IDictionary<string, object>>().ToList();
    }
}
