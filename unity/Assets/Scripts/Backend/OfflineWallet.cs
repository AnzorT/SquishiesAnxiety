// The dev menu's offline wallet ("Dev: menu offline", editor and development builds: no account). The app has no
// offline mode; without this the offline menu showed the exported numbers whatever happened, so coins won in a game
// or in Squish Time never added up and the house's Catalog had 0 coins to spend (every BUY: "Not enough coins").
// Offline, the games pay their coins here (Games/*/…Save.cs Send, where a signed-in game writes to the account), Squish
// Time its earnings, the Catalog spends from it, and the menu's coin pill shows it. It starts at the exported menu's
// number and is kept on the device (Load / Store: PlayerPrefs, set by the menu). No UnityEngine here.
using System;
using System.Globalization;

namespace SquishSquad.Backend
{
    public static class OfflineWallet
    {
        /// <summary>Where it's kept (the menu sets these to PlayerPrefs); null: in memory only.</summary>
        public static Func<string> Load;
        public static Action<string> Store;
        /// <summary>The coins changed (the menu redraws its pill).</summary>
        public static event Action Changed;

        static double _coins = double.NaN;

        /// <summary>The wallet's coins (`start` the first time: the exported menu's number).</summary>
        public static double Coins(double start)
        {
            if (double.IsNaN(_coins))
                _coins = double.TryParse(Load?.Invoke(), NumberStyles.Float, CultureInfo.InvariantCulture, out var v) ? v : start;
            return _coins;
        }

        public static void Add(double n, double start)
        {
            if (!(n > 0)) return;
            _coins = Coins(start) + n;
            Save();
        }

        /// <summary>Takes `n` coins if there are that many.</summary>
        public static bool Spend(double n, double start)
        {
            if (Coins(start) < n) return false;
            _coins -= n;
            Save();
            return true;
        }

        static void Save()
        {
            Store?.Invoke(_coins.ToString("R", CultureInfo.InvariantCulture));
            Changed?.Invoke();
        }

        /// <summary>What the offline menu starts from (HudValues.Baked's coins).</summary>
        public static double Start = 100;
        /// <summary>A game's pay with no account to write it to.</summary>
        public static void Paid(double coins) => Add(coins, Start);
    }
}
