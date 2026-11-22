// Starts the app in any scene: frame rate, then the Main Menu (the only screen ported so far).
using SquishSquad.Menu;
using UnityEngine;

namespace SquishSquad.App
{
    public static class Boot
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void Start()
        {
            // Unity runs phones at 30 fps unless told otherwise; ask for as fast as the screen refreshes (the A15: 90 Hz)
            Application.targetFrameRate = 120;
            QualitySettings.vSyncCount = 0;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            if (Object.FindAnyObjectByType<MenuScreen>() == null) new GameObject("MainMenu").AddComponent<MenuScreen>();
        }
    }
}
