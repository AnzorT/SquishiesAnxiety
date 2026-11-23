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
            // the app's fonts for text drawn in Unity (Resources/Fonts, tools/unity/ui/fonts.py)
            UiFont.ReadJson = name => Resources.Load<TextAsset>("Fonts/" + name)?.text;
            UiFont.ParseJson = json => JsonUtility.FromJson<UiFontData>(json);
            if (Object.FindAnyObjectByType<MenuScreen>() == null && Object.FindAnyObjectByType<AppFlow>() == null) new GameObject("App").AddComponent<AppFlow>();
        }
    }
}
