// The Unity side of IAuthStore: the session in PlayerPrefs.
//
// PlayerPrefs is plain storage (on Android an XML file in the app's private folder; readable on a rooted device or
// from a backup), and the session's refresh token signs in as the player for as long as it lives. A keystore would be
// better: Android Keystore / EncryptedSharedPreferences, or the iOS Keychain, through a small native plugin; swap
// this class for one once there is. Kept out of the console tests (they use MemoryAuthStore).
using UnityEngine;

namespace SquishSquad.Backend
{
    public sealed class PlayerPrefsAuthStore : IAuthStore
    {
        // Call from the main thread only: PlayerPrefs isn't thread-safe. FirebaseAuth writes the session after a
        // sign-in or a token refresh, which can finish on a thread-pool thread, so writes are queued to the main
        // thread when needed (MainThread below).
        public string Read(string key) => PlayerPrefs.HasKey(key) ? PlayerPrefs.GetString(key) : null;

        public void Write(string key, string value) => MainThread.Run(() =>
        {
            PlayerPrefs.SetString(key, value);
            PlayerPrefs.Save();
        });

        public void Remove(string key) => MainThread.Run(() =>
        {
            PlayerPrefs.DeleteKey(key);
            PlayerPrefs.Save();
        });
    }

    // Runs an action on Unity's main thread: now if already there, else posted to its SynchronizationContext
    // (captured at load, before the first scene).
    public static class MainThread
    {
        static System.Threading.SynchronizationContext ctx;
        static int mainId;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Capture()
        {
            ctx = System.Threading.SynchronizationContext.Current;
            mainId = System.Threading.Thread.CurrentThread.ManagedThreadId;
        }

        public static void Run(System.Action a)
        {
            if (ctx == null || System.Threading.Thread.CurrentThread.ManagedThreadId == mainId) a();
            else ctx.Post(_ => a(), null);
        }
    }
}
