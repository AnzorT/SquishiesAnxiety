// Real-money purchases on Google Play, as src/billing/index.android.js and economy.js do them: the products and their
// price levels (config/pricing, config/offers), the store's prices, Play's purchase sheet (the PlayBilling plugin,
// Assets/Plugins/Android/PlayBilling.androidlib), and each purchase handed to the verifyPurchase Cloud Function, the
// only place anything is granted (it checks the token with Google Play, writes the grant, then acknowledges or
// consumes it). Off Android (the editor) billing is "unavailable".
//
//   await Billing.Init(fb)                 once signed in: the pricing config, the store's prices, SyncPurchases
//   Billing.PriceLabel("gems950")          the store's "$9.99" (or the set price until it has loaded)
//   var grant = await Billing.Buy(fb, uid, "removeAds")    { granted: 'adsFree' | 'gems' | 'bundle' | ... }, or
//                                          { pending: true } (Play hasn't cleared the payment: SyncPurchases grants it)
//   throws BillingException (Code: cancelled, unavailable, network, busy, failed, verify; Message: words for the player)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;

namespace SquishSquad.Backend
{
    public sealed class BillingException : Exception
    {
        public readonly string Code;
        public BillingException(string code, string message = null) : base(message ?? Words(code)) { Code = code; }

        static string Words(string code) => code switch
        {
            "cancelled" => "Purchase cancelled",
            "unavailable" => "Google Play purchases aren't available here",
            "network" => "No connection to Google Play",
            "busy" => "Another purchase is still going",
            "verify" => "Paid! It'll be added as soon as the server confirms it",
            _ => "The purchase didn't go through",
        };
    }

    /// <summary>economy.js PRODUCTS, the price levels and the Deals tab's offer products.</summary>
    public static class Products
    {
        sealed class P { public string Base; public double? Usd; public bool Consumable; }

        static readonly Dictionary<string, P> Base = new Dictionary<string, P>
        {
            ["removeAds"] = new P { Base = "remove_ads", Usd = 0.99 },
            ["creation"] = new P { Base = "creature_creation", Usd = 4.99, Consumable = true },
            ["creationDiscount"] = new P { Base = "creature_creation_15off", Usd = 4.24, Consumable = true },
            ["creationHalf"] = new P { Base = "creature_creation_half", Usd = 2.49, Consumable = true },
            ["gems80"] = new P { Base = "gems_80", Usd = 0.99, Consumable = true },
            ["gems450"] = new P { Base = "gems_450", Usd = 4.99, Consumable = true },
            ["gems950"] = new P { Base = "gems_950", Usd = 9.99, Consumable = true },
            ["gems2000"] = new P { Base = "gems_2000", Usd = 19.99, Consumable = true },
            ["gems5500"] = new P { Base = "gems_5500", Usd = 49.99, Consumable = true },
            ["gems12000"] = new P { Base = "gems_12000", Usd = 99.99, Consumable = true },
        };
        static Dictionary<string, P> _offers = new Dictionary<string, P>();
        static Dictionary<string, int> _pricing = new Dictionary<string, int>();   // key → USD cents

        static P Of(string key) => key == null ? null : Base.TryGetValue(key, out var p) ? p : _offers.TryGetValue(key, out var o) ? o : null;

        static int? Cents(object usd) => usd is double d && !double.IsNaN(d) && !double.IsInfinity(d) && d > 0 && d < 10000 ? (int)Math.Round(d * 100) : (int?)null;

        /// <summary>economy.js setPricing (the config/pricing document, or null).</summary>
        public static void SetPricing(IDictionary<string, object> doc)
        {
            var next = new Dictionary<string, int>();
            object V(string k) => doc != null && doc.TryGetValue(k, out var v) ? v : null;
            foreach (var k in new[] { "removeAds", "creation" }) { var c = Cents(V(k)); if (c.HasValue) next[k] = c.Value; }
            var discount = Cents(V("creationDiscount")) ?? (next.TryGetValue("creation", out var cr) ? (int)Math.Floor(cr * 0.85) : (int?)null);
            if (discount.HasValue) next["creationDiscount"] = discount.Value;
            var half = Cents(V("creationHalf")) ?? (next.TryGetValue("creation", out var cr2) ? (int)Math.Floor(cr2 * 0.5) : (int?)null);
            if (half.HasValue) next["creationHalf"] = half.Value;
            _pricing = next;
        }

        /// <summary>economy.js setOfferProducts (the config/offers document, or null).</summary>
        public static void SetOffers(IDictionary<string, object> cfg)
        {
            var next = new Dictionary<string, P>();
            if (cfg != null && cfg.TryGetValue("offers", out var list) && list is IList<object> offers)
                foreach (var e in offers.OfType<IDictionary<string, object>>())
                {
                    if (!e.TryGetValue("id", out var id) || id == null) continue;
                    if (!(e.TryGetValue("product", out var pr) && pr is string product && Regex.IsMatch(product, "^offer_[a-z0-9_]+$"))) continue;
                    next["offer:" + id] = new P
                    {
                        Base = product,
                        Usd = e.TryGetValue("usd", out var u) && u is double d ? d : (double?)null,
                        Consumable = e.TryGetValue("consumable", out var c) && c is bool b && b,
                    };
                }
            _offers = next;
        }

        /// <summary>The store product to sell for `key` right now (its price level), or null.</summary>
        public static string ProductId(string key)
        {
            var p = Of(key);
            if (p == null) return null;
            return _pricing.TryGetValue(key, out var c) ? p.Base + "_" + c : p.Base;
        }

        public static IEnumerable<string> ProductIds() => Base.Keys.Concat(_offers.Keys).Select(ProductId);

        /// <summary>"$1.49": the price set in Firebase (or the default), until the store's own has loaded.</summary>
        public static string FallbackPriceLabel(string key)
        {
            var p = Of(key);
            if (p?.Usd == null) return "";
            int cents = _pricing.TryGetValue(key, out var c) ? c : (int)Math.Round(p.Usd.Value * 100);
            return "$" + (cents / 100.0).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
        }

        static readonly Regex BaseId = new Regex(@"^(gems_(?:80|450|950|2000|5500|12000)|remove_ads|creature_creation_15off|creature_creation_half|creature_creation)(?:_[1-9]\d{0,5})?$");

        /// <summary>A product id (a base product or a price level of it) → its key.</summary>
        public static string KeyOf(string id)
        {
            var m = BaseId.Match(id ?? "");
            if (m.Success) return Base.FirstOrDefault(kv => kv.Value.Base == m.Groups[1].Value).Key;
            return _offers.FirstOrDefault(kv => kv.Value.Base == (id ?? "")).Key;
        }

        public static bool IsConsumable(string id) => Of(KeyOf(id))?.Consumable ?? false;
    }

    public static class Billing
    {
        static readonly Dictionary<string, string> Prices = new Dictionary<string, string>();   // product id → "$9.99"
        public static event Action PricesChanged;
        static FirebaseClient _fb;

#if UNITY_ANDROID && !UNITY_EDITOR
        static AndroidJavaObject _plugin;

        sealed class Callback : AndroidJavaProxy
        {
            readonly TaskCompletionSource<string> _tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
            public Callback() : base("com.plushcrush.unity.billing.PlayBilling$Callback") { }
            public Task<string> Task => _tcs.Task;
            // (called on a Java thread; the awaiting code goes on on Unity's main thread)
            public void done(string json, string error, string message)
            {
                if (error != null) _tcs.TrySetException(new NativeError(error, message));
                else _tcs.TrySetResult(json);
            }
        }

        sealed class Listener : AndroidJavaProxy
        {
            public Listener() : base("com.plushcrush.unity.billing.PlayBilling$Listener") { }
            public void purchases(string json) => MainThread.Run(() => DeliverAll(json));
        }

        sealed class NativeError : Exception
        {
            public readonly string Code;
            public NativeError(string code, string message) : base(message ?? code) { Code = code; }
        }

        static AndroidJavaObject Activity()
        {
            using var player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            return player.GetStatic<AndroidJavaObject>("currentActivity");
        }

        static AndroidJavaObject Plugin()
        {
            if (_plugin != null) return _plugin;
            try { _plugin = new AndroidJavaObject("com.plushcrush.unity.billing.PlayBilling", Activity(), new Listener()); }
            catch (Exception e) { Debug.LogWarning("[Billing] " + e.Message); }
            return _plugin;
        }

        static Task<string> Native(string method, params object[] args)
        {
            var cb = new Callback();
            var all = new object[args.Length + 1];
            Array.Copy(args, all, args.Length);
            all[args.Length] = cb;
            Plugin().Call(method, all);
            return cb.Task;
        }

        static async Task<bool> Connect()
        {
            if (Plugin() == null) return false;
            try { return await Native("connect") == "true"; }
            catch (Exception) { return false; }
        }

        static Task<string> NativePurchase(string id, string uid, string creatureId)
        {
            var cb = new Callback();
            Plugin().Call("purchase", Activity(), id, uid, creatureId ?? "", cb);
            return cb.Task;
        }

        static string CodeOf(Exception e) => e is NativeError n ? n.Code : "failed";
#else
        static Task<bool> Connect() => Task.FromResult(false);
        static Task<string> Native(string method, params object[] args) => Task.FromException<string>(new InvalidOperationException("no billing here"));
        static Task<string> NativePurchase(string id, string uid, string creatureId) => Native("purchase");
        static string CodeOf(Exception e) => "failed";
#endif

        /// <summary>Once signed in: the pricing config, the store's prices, then the purchases Play still holds.</summary>
        public static async Task Init(FirebaseClient fb)
        {
            _fb = fb;
            try
            {
                Products.SetPricing(await fb.Data.ReadConfig("pricing"));
                Products.SetOffers(await fb.Data.ReadConfig("offers"));
            }
            catch (Exception e) { Debug.LogWarning("[Billing] config: " + e.Message); }
            await LoadProducts();
            await SyncPurchases();
        }

        /// <summary>The store's prices; false when billing isn't there or none of the products are.</summary>
        public static async Task<bool> LoadProducts()
        {
            if (!await Connect()) return false;
            try
            {
                var ids = Products.ProductIds().Where(x => x != null).ToList();
                var list = Json.Parse(await Native("getProducts", Json.Write(ids.Cast<object>().ToList()))) as IList<object> ?? new List<object>();
                foreach (var p in list.OfType<IDictionary<string, object>>())
                    if (p.TryGetValue("id", out var id) && p.TryGetValue("price", out var price) && price is string label && label.Length > 0) Prices[(string)id] = label;
                PricesChanged?.Invoke();
                var missing = ids.Where(id => !list.OfType<IDictionary<string, object>>().Any(p => (p.TryGetValue("id", out var x) ? x as string : null) == id)).ToList();
                if (missing.Count > 0) Debug.LogWarning("[Billing] Not in Google Play (create them, or fix config/pricing): " + string.Join(", ", missing));
                return list.Count > 0;
            }
            catch (Exception) { return false; }
        }

        /// <summary>The store's price for the product sold for `key` right now, or the set price until it has loaded.</summary>
        public static string PriceLabel(string key)
        {
            var id = Products.ProductId(key);
            return id != null && Prices.TryGetValue(id, out var p) ? p : Products.FallbackPriceLabel(key);
        }

        static async Task<IDictionary<string, object>> Deliver(IDictionary<string, object> purchase)
        {
            if (_fb == null) throw new InvalidOperationException("not signed in");
            string product = purchase.TryGetValue("products", out var ps) && ps is IList<object> l && l.Count > 0 ? l[0] as string : null;
            var r = await _fb.Functions.Call("verifyPurchase", new Dictionary<string, object>
            {
                ["platform"] = "android",
                ["productId"] = product,
                ["purchaseToken"] = purchase.TryGetValue("purchaseToken", out var t) ? t : null,
            });
            return r as IDictionary<string, object> ?? new Dictionary<string, object>();
        }

        static void DeliverAll(string json)
        {
            foreach (var p in (Json.Parse(json) as IList<object> ?? new List<object>()).OfType<IDictionary<string, object>>())
                if (p.TryGetValue("state", out var s) && (s as string) == "purchased")
                    _ = Deliver(p).ContinueWith(t => { if (t.IsFaulted) Debug.LogWarning("[Billing] purchase sync failed: " + t.Exception?.GetBaseException().Message); });
        }

        /// <summary>Buys `key` (a PRODUCTS key, or 'offer:&lt;id&gt;') for the signed-in player: the server's grant, or
        /// { pending: true }. Throws BillingException.</summary>
        public static async Task<IDictionary<string, object>> Buy(FirebaseClient fb, string uid, string key, string creatureId = "", bool retried = false)
        {
            _fb = fb ?? _fb;
            var id = Products.ProductId(key);
            if (id == null) throw new BillingException("failed", "Unknown product " + key);
            if (!await Connect()) throw new BillingException("unavailable");
            if (!Prices.ContainsKey(id)) await LoadProducts();
            if (!Prices.ContainsKey(id)) throw new BillingException("unavailable");
            string json;
            try { json = await NativePurchase(id, uid, creatureId); }
            catch (Exception e)
            {
                var code = CodeOf(e);
                if (code == "already_owned")
                {
                    await SyncPurchases();
                    // a creation or a key Play still held: the sync granted and consumed it, so the sheet opens now, once
                    if (Products.IsConsumable(id) && !retried) return await Buy(fb, uid, key, creatureId, true);
                    return new Dictionary<string, object> { ["granted"] = "restored" };   // Remove Ads bought before
                }
                throw new BillingException(code == "cancelled" || code == "busy" || code == "network" ? code : "unavailable", null);
            }
            var list = (Json.Parse(json) as IList<object> ?? new List<object>()).OfType<IDictionary<string, object>>().ToList();
            var p = list.FirstOrDefault(x => x.TryGetValue("products", out var ps) && ps is IList<object> l && l.Contains(id)) ?? list.FirstOrDefault();
            if (p == null) throw new BillingException("failed", "No purchase came back");
            if (p.TryGetValue("state", out var st) && (st as string) == "pending") return new Dictionary<string, object> { ["pending"] = true };
            try { return await Deliver(p); }
            catch (Exception) { throw new BillingException("verify"); }   // paid; SyncPurchases tries again
        }

        /// <summary>Every purchase Play reports for this account, to the server (it skips what it has granted). Quiet when
        /// Google Play isn't there.</summary>
        public static async Task SyncPurchases()
        {
            if (!await Connect()) return;
            string json;
            try { json = await Native("getPurchases"); }
            catch (Exception) { return; }
            DeliverAll(json);
        }
    }
}
