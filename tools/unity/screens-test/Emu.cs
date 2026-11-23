// The screens' writes against the Firebase Local Emulator Suite (tools/unity/backend/start-emulators.sh: auth 9099,
// firestore 8080, functions 5001, project demo-squish), through the Unity Backend client. Every request goes through
// LocalOnly, which refuses anything but 127.0.0.1 / localhost: this can never reach the live project.
//   the daily challenges: each claim (coins, totalEarned, XP, the claimed list), a second claim refused, the chest (its
//   coins, XP, the streak, chests, bestStreak, the streak day's gems from squad dailyGift), the streak marked seen;
//   the Daily Spin: spinWheel's prize paid, the wheel (SpinView) landing on the slice the server picked, a second spin
//   refused, the bonus spin once; Settings: the nickname saved, feedback sent, the Test wallet refused without the
//   tester claim and setting coins with it.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SquishSquad.Anim;
using SquishSquad.Backend;
using SquishSquad.Screens;

static class Emu
{
    sealed class LocalOnly : IHttp
    {
        readonly IHttp inner = new HttpClientHttp(TimeSpan.FromSeconds(60));
        public Task<HttpResult> Send(HttpRequest r, CancellationToken cancel = default)
        {
            var u = new Uri(r.Url);
            if (!(u.Host == "127.0.0.1" || u.Host == "localhost") || u.Scheme != "http") throw new InvalidOperationException("refusing a non-emulator request: " + r.Url);
            return inner.Send(r, cancel);
        }
    }

    static int pass, fail;
    static void Check(bool ok, string what)
    {
        if (ok) pass++; else fail++;
        Console.WriteLine($"  {(ok ? "ok  " : "FAIL")} {what}");
    }

    static double N(IDictionary<string, object> p, string path) => Prof.Num(Prof.At(p, path));

    public static async Task<int> Run()
    {
        SynchronizationContext.SetSynchronizationContext(null);
        var http = new LocalOnly();
        var fb = new FirebaseClient(FirebaseConfig.Emulator("demo-squish", "127.0.0.1"), new MemoryAuthStore(), http);
        await fb.Auth.Start();
        string run = DateTime.UtcNow.Ticks.ToString("x");
        string email = $"unity-screens-{run}@example.com", pwd = "secret12";
        var user = await fb.Auth.RegisterWithEmail(email, pwd);
        string uid = user.Uid;
        await fb.Data.CreateUserProfile(uid, email, 14, "Mia");
        var data = fb.Data;
        var now = DateTime.Now;
        string today = Prof.DayKey(now), yesterday = Prof.DayBefore(today);

        // ---- the daily challenges ---------------------------------------------------------------------------------
        Console.WriteLine("daily challenges and the chest:");
        var ch = Progression.ChallengesFor(today);
        var prog = ch.ToDictionary(c => c.Ev, c => (object)(double)c.Goal);
        await data.UpdateProfile(uid, new Dictionary<string, object>
        {
            ["pxp"] = 1000.0, ["coins"] = 100.0, ["totalEarned"] = 100.0, ["streak"] = 2.0, ["bestStreak"] = 2.0, ["lastFull"] = yesterday,
            ["daily"] = new Dictionary<string, object> { ["date"] = today, ["prog"] = prog, ["claimed"] = new Dictionary<string, object>(), ["chest"] = false },
        });
        var p = await data.GetProfile(uid);
        Check(Progression.View(p, now).Claimable == 6, "six challenges done, none claimed: " + Progression.View(p, now).Claimable + " to claim");
        double coins = N(p, "coins"), pxp = N(p, "pxp");
        foreach (var c in ch)
        {
            var row = Progression.DailyRows(p, today).First(r => r.Id == c.Id);
            var toast = await ScreenWrites.ClaimDailyChallenge(data, uid, p, c.Id, now);
            var q = await data.GetProfile(uid);
            Check(toast == $"+{row.Reward} coins · +25 XP!" && Prof.Truthy(Prof.At(q, "daily.claimed." + c.Id)) && N(q, "coins") == coins + row.Reward && N(q, "pxp") == pxp + 25,
                $"claim {c.Id}: \"{toast}\", coins {N(q, "coins")}, pxp {N(q, "pxp")}");
            coins = N(q, "coins"); pxp = N(q, "pxp");
            p = q;
        }
        Check(await ScreenWrites.ClaimDailyChallenge(data, uid, p, ch[0].Id, now) == null, "a claimed challenge can't be claimed again");
        var view = Progression.View(p, now);
        Check(view.ChestReady && view.ClaimedN == 6, "the chest is ready (OPEN)");
        var day = Progression.StreakRewardOf(3);
        // (no gems yet: the squad's starting 600, as squad/data.js wallet and the server's withStart)
        double gems = Prof.IsNum(Prof.Get(p, "gems")) ? N(p, "gems") : 600;
        var chestToast = await ScreenWrites.ClaimDailyChest(data, fb.Functions, uid, p, now);
        p = await data.GetProfile(uid);
        Check(N(p, "streak") == 3 && Prof.Str(Prof.Get(p, "lastFull")) == today && N(p, "bestStreak") == 3 && N(p, "chests") == 1 && Prof.Truthy(Prof.At(p, "daily.chest")),
            $"the chest: streak {N(p, "streak")}, lastFull {Prof.Get(p, "lastFull")}, chests {N(p, "chests")}");
        Check(N(p, "coins") == coins + 250 && N(p, "pxp") == pxp + 100, $"its coins and XP: coins {N(p, "coins")}, pxp {N(p, "pxp")}");
        Check(day.Kind == "gems" && N(p, "gems") == gems + day.Amount && Prof.Str(Prof.Get(p, "giftDay")) == today, $"day 3's +{day.Amount} gems from squad dailyGift: gems {gems} → {N(p, "gems")}");
        Check(chestToast == "Daily chest: +250 coins · +100 XP + 10 gems!", "toast: " + chestToast);
        Check(await ScreenWrites.ClaimDailyChest(data, fb.Functions, uid, p, now) == null, "the chest can't be opened twice");
        var after = Progression.View(p, now);
        Check(after.ChestDone && after.Streak == 3 && after.Track.First(d => d.Today).N == 3 && after.Track.First(d => d.Today).Done, "the streak screen: day 3 done today");
        Check(!ScreenWrites.StreakIntroDue(p, now), "no streak intro once today's chest is open");
        await data.MarkStreakSeen(uid, today);
        await Task.Delay(300);
        p = await data.GetProfile(uid);
        Check(Prof.Str(Prof.Get(p, "streakSeen")) == today, "markStreakSeen: " + Prof.Get(p, "streakSeen"));

        // ---- the Daily Spin ----------------------------------------------------------------------------------------
        Console.WriteLine("the Daily Spin:");
        Check(ScreenWrites.SpinDue(p, now), "the spin is due (not spun today)");
        coins = N(p, "coins"); gems = N(p, "gems");
        var res = await ScreenWrites.Spin(fb.Functions, false, now);
        var w = res.Error || res.Already ? default : SpinView.WHEEL[res.Index];
        Check(!res.Error && !res.Already && res.Kind == w.kind && res.Amount == w.amount, $"spinWheel: slice {res.Index}, {res.Amount} {res.Kind}");
        p = await data.GetProfile(uid);
        Check(N(p, "spins") == 1 && Prof.Str(Prof.Get(p, "lastSpinDay")) == today && (res.Kind == "coins" ? N(p, "coins") == coins + res.Amount : N(p, "gems") == gems + res.Amount),
            $"paid: spins {N(p, "spins")}, lastSpinDay {Prof.Get(p, "lastSpinDay")}, coins {N(p, "coins")}, gems {N(p, "gems")}");
        Check(!ScreenWrites.SpinDue(p, now), "not due again today");
        // the wheel lands on the server's slice
        var t = new Ticker(0);
        Ticker.Default = t;
        var spin = new SpinView("Mia", ScreenWrites.AdSpinsLeft(p, now), true, 832, 384, t) { OnSpin = _ => Task.FromResult(res) };
        for (double ms = 16; ms <= 1000; ms += 16) t.Tick(ms);
        spin.Hub();
        for (double ms = 1008; ms <= 7000 && spin.Phase != "prize"; ms += 16) t.Tick(ms);
        double stop = (360 - (res.Index * SpinView.SLICE + SpinView.SLICE / 2)) % 360;
        Check(spin.Phase == "prize" && Math.Abs(((spin.Angle % 360) + 360) % 360 - stop) < 1e-6, $"SpinView landed at {spin.Angle % 360:0.###}° (slice {res.Index} under the pointer: {stop}°), the card up");
        var again = await ScreenWrites.Spin(fb.Functions, false, now);
        Check(again.Already && !again.Bonus, "a second free spin: already");
        Check(ScreenWrites.AdSpinsLeft(p, now) == 1, "one bonus spin left");
        var bonus = await ScreenWrites.Spin(fb.Functions, true, now);
        Check(!bonus.Error && !bonus.Already, $"the bonus spin: {bonus.Amount} {bonus.Kind}");
        var bonus2 = await ScreenWrites.Spin(fb.Functions, true, now);
        Check(bonus2.Already && bonus2.Bonus, "a second bonus spin: already (bonus)");
        p = await data.GetProfile(uid);
        Check(N(p, "spins") == 2 && ScreenWrites.AdSpinsLeft(p, now) == 0, $"spins {N(p, "spins")}, bonus spins left {ScreenWrites.AdSpinsLeft(p, now)}");

        // ---- Settings ----------------------------------------------------------------------------------------------
        Console.WriteLine("Settings:");
        var st = new SettingsView("Mia", true, 832, 384, t)
        {
            OnSaveNickname = n => _ = data.UpdateNickname(uid, n),
            OnSubmitFeedback = text => data.SubmitFeedback(uid, text),
        };
        st.SetText("nick", "Captain Squishy");
        Check(st.Nick == "Captain Sq", "the field keeps 10 letters: " + st.Nick);
        st.Save();
        await Task.Delay(800);
        p = await data.GetProfile(uid);
        Check(Prof.Str(Prof.Get(p, "nickname")) == "Captain Sq" && st.Toast == "Nickname updated!", $"nickname saved: {Prof.Get(p, "nickname")}, toast \"{st.Toast}\"");
        // Send feedback: the box opens, the text, SEND
        st.Down(666, 137); st.Up(666, 137);
        Check(st.Feedback == "", "Send feedback opens the box");
        st.SetText("feedback", "Unity port test: the wheel feels great!");
        string sendErr = null;
        try { await data.SubmitFeedback(uid, st.Feedback); } catch (Exception e) { sendErr = e.Message; }
        Check(sendErr == null, "feedback written (users may create feedback docs)" + (sendErr != null ? ": " + sendErr : ""));
        // the Test wallet: refused without the tester claim, then with it
        var wallet = new TestWalletView(t, N(p, "coins"), N(p, "gems"), Progression.Level(p)) { OnSet = wd => ScreenWrites.TestWallet(fb.Functions, wd, now) };
        wallet.Tap("q-c0");
        for (int i = 0; i < 50 && wallet.Msg == "…"; i++) await Task.Delay(100);
        Check(wallet.Msg == "Not a tester account", "testWallet without the claim: " + wallet.Msg);
        var set = await http.Send(new HttpRequest
        {
            Method = "POST",
            Url = "http://127.0.0.1:9099/identitytoolkit.googleapis.com/v1/projects/demo-squish/accounts:update",
            Headers = { ["Authorization"] = "Bearer owner" },
            Body = Json.Write(new Dictionary<string, object> { ["localId"] = uid, ["customAttributes"] = "{\"tester\":true}" }),
        });
        await fb.Auth.GetIdToken(true);
        wallet.SetText("wcoins", "12345");
        wallet.Tap("set");
        for (int i = 0; i < 80 && wallet.Msg == "…"; i++) await Task.Delay(100);
        p = await data.GetProfile(uid);
        Check(set.Ok && wallet.Msg == "Done!" && N(p, "coins") == 12345, $"testWallet with the claim: \"{wallet.Msg}\", coins {N(p, "coins")}");

        Console.WriteLine($"{pass} passed, {fail} failed");
        return fail == 0 ? 0 : 1;
    }
}
