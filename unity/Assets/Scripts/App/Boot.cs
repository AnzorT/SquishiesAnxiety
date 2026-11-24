// Starts the app in any scene: frame rate, the fonts, then the app's start-up flow (AppFlow: splash, sign-in, the menu).
using SquishSquad.Menu;
using SquishSquad.Ui;
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
#if UNITY_EDITOR
            // keep playing while another window has focus (else the Game view freezes on the last frame)
            Application.runInBackground = true;
#endif
            // the app's fonts for text drawn in Unity (Resources/Fonts, tools/unity/ui/fonts.py)
            UiFont.ReadJson = name => Resources.Load<TextAsset>("Fonts/" + name)?.text;
            UiFont.ParseJson = json => JsonUtility.FromJson<UiFontData>(json);
            SvgText.Install();   // SVG <text> in the exported art (the park's sign, …) drawn in those fonts
            // the ears: without an AudioListener nothing is heard (the cameras the screens make don't carry one)
            if (Object.FindAnyObjectByType<AudioListener>() == null)
            {
                var ears = new GameObject("AudioListener");
                ears.AddComponent<AudioListener>();
                Object.DontDestroyOnLoad(ears);
            }
            if (Object.FindAnyObjectByType<MenuScreen>() == null && Object.FindAnyObjectByType<AppFlow>() == null) new GameObject("App").AddComponent<AppFlow>();
        }
    }
}
