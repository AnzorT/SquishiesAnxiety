// App.js's sound rules, for the Unity app's flow (App/AppFlow, Menu/MenuScreen and the screens it opens).
//
//   musicFor(stage, onGame) = stage === 'splash' || (onGame && stage !== 'home') ? null : 'theme'
//   useEffect: if (stage === 'crib' && !onGame) return; sfx.music(fontsLoaded ? musicFor(stage, onGame) : null)
//
// So Velvet Map Study plays from the end of the splash on, on every screen (log in, the menu and its Game Park, the
// Shop, Settings, Squish Time, the games), without restarting between them; the splash is silent and so is the new
// design's house (stage 'crib' with the Menu on: onGame), which plays its own sounds. (The old Crib, 'crib' without
// onGame, had its own music switch: it leaves the music alone. It isn't in the Unity app.)
// onGame is true only on the new design's Menu ('home' with the squish tab) and its house: pass ("home", true) for the
// Unity menu, ("crib", true) for the house, (the screen's stage, false) for a screen opened over the menu.
//
// AppSounds: the rest of App.js's sounds (a whoosh between screens, coins in / out, LEVEL UP, an achievement's toast,
// a custom creature turning 3D).
namespace SquishSquad.Audio
{
    public static class Music
    {
        public const string Theme = "theme";

        /// <summary>App.js musicFor: the track for a stage (null = silence).</summary>
        public static string For(string stage, bool onGame) => stage == "splash" || (onGame && stage != "home") ? null : Theme;

        /// <summary>Whether App.js's music effect acts on this stage at all (the old Crib keeps whatever plays).</summary>
        public static bool Applies(string stage, bool onGame) => !(stage == "crib" && !onGame);

        /// <summary>App.js's music effect, run whenever the stage (or onGame) changes. fontsLoaded: always true in Unity.</summary>
        public static void Follow(string stage, bool onGame, bool fontsLoaded = true) => Follow(stage, onGame, fontsLoaded, SfxCore.FadeInMs, 1);

        static void Follow(string stage, bool onGame, bool fontsLoaded, double fadeInMs, double fadePower)
        {
            _stage = stage; _onGame = onGame;
            if (!Applies(stage, onGame)) return;
            Sfx.Music(fontsLoaded && !Held ? For(stage, onGame) : null, fadeInMs, fadePower);
        }

        // App.js musicHeld: silent from launch (the sign-in screens too) until the game intro's SQUISH SQUAD logo starts
        // dropping in (the user, 2026-11-26; it was the third squish of Mittens), or its end (skipped, finished, or never
        // started). AppFlow holds it at launch; the menu lets it go.
        static string _stage; static bool _onGame;
        public static bool Held { get; private set; }
        public static void Hold() => Held = true;
        public static void Release() => Release(SfxCore.FadeInMs, 1);

        /// <summary>The intro's logo drop: the track comes up gradually, over 4 s, eased in (volume ~ progress^2, so the
        /// first second stays soft) rather than sfx.js's straight 1.2 s.</summary>
        public const double IntroFadeInMs = 4000, IntroFadePower = 2;
        public static void ReleaseForIntro() => Release(IntroFadeInMs, IntroFadePower);

        static void Release(double fadeInMs, double fadePower)
        {
            if (!Held) return;
            Held = false;
            if (_stage != null) Follow(_stage, _onGame, true, fadeInMs, fadePower);
        }

        /// <summary>App.js's stage name for an AppFlow stage ("menu" is App.js's "home").</summary>
        public static string AppStageOf(string unityStage) => unityStage == "menu" ? "home" : unityStage;
    }

    /// <summary>App.js's other sound effects, with the state they keep between renders (one instance, the app's).</summary>
    public sealed class AppSounds
    {
        public static readonly AppSounds Shared = new AppSounds();

        string _prevStage;
        bool _stageSeen;
        long? _prevCoins;
        bool _coinsSeen;

        /// <summary>The stage changed: the music (Music.Follow), then a whoosh unless the splash is what's leaving
        /// (App.js: "no whoosh as the splash makes way for the first screen"). The first call only remembers the stage
        /// (App.js's useRef(stage) at the first render).</summary>
        public void Stage(string stage, bool onGame)
        {
            Music.Follow(stage, onGame);
            if (WhooshOn(stage)) Sfx.Play("whoosh");
        }

        /// <summary>The whoosh rule alone (true: play "whoosh"); remembers the stage.</summary>
        public bool WhooshOn(string stage)
        {
            if (!_stageSeen) { _stageSeen = true; _prevStage = stage; return false; }
            bool w = _prevStage != stage && _prevStage != "splash";
            _prevStage = stage;
            return w;
        }

        /// <summary>The profile's coins changed: "coinShower" when they went up, "spend" when down; none on the squish
        /// stage ('toy') or the box ('box'), which play their own, and none for the first value seen.</summary>
        public void Coins(long? coinsNow, string stage)
        {
            var s = CoinsSound(coinsNow, stage);
            if (s != null) Sfx.Play(s);
        }

        public string CoinsSound(long? coinsNow, string stage)
        {
            if (!_coinsSeen) { _coinsSeen = true; _prevCoins = coinsNow; return null; }
            var prev = _prevCoins;
            _prevCoins = coinsNow;
            if (prev == null || coinsNow == null || prev == coinsNow || stage == "toy" || stage == "box") return null;
            return coinsNow > prev ? "coinShower" : "spend";
        }

        /// <summary>The LEVEL UP card came up (App.js levelUpDue).</summary>
        public static void LevelUp() => Sfx.Play("sd_levelUp");

        /// <summary>An achievement just turned done: its toast, and this 250 ms later.</summary>
        public static void Achievement() => Sfx.Play("achievement", delay: 250);

        /// <summary>A custom creature finished turning 3D.</summary>
        public static void CustomReady() => Sfx.Play("sparkle");
    }
}
