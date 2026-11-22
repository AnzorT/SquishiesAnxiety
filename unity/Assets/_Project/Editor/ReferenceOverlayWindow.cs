// PlushCrush > Reference Overlay: pick a reference screenshot (Assets/_Project/Reference) and lay it over the running
// game, half see-through, to check a rebuilt screen against the original. Set the Game view to 2340x1080 (the A15)
// so both line up.
using System.IO;
using System.Linq;
using PlushCrush.App;
using UnityEditor;
using UnityEngine;

namespace PlushCrush.EditorTools
{
    public sealed class ReferenceOverlayWindow : EditorWindow
    {
        const string Folder = "Assets/_Project/Reference";
        string[] _paths = new string[0];
        int _index;
        float _opacity = 0.5f;
        bool _on;
        Vector2 _scroll;

        [MenuItem("PlushCrush/Reference Overlay")]
        static void Open() => GetWindow<ReferenceOverlayWindow>("Reference Overlay");

        void OnEnable()
        {
            Refresh();
            EditorApplication.playModeStateChanged += OnPlayMode;
        }

        void OnDisable() => EditorApplication.playModeStateChanged -= OnPlayMode;

        void OnPlayMode(PlayModeStateChange change)
        {
            if (change == PlayModeStateChange.EnteredPlayMode) Apply(); // keep the overlay on across Play sessions
            Repaint();
        }

        void Refresh()
        {
            _paths = Directory.Exists(Folder)
                ? Directory.GetFiles(Folder, "*.*", SearchOption.AllDirectories)
                    .Where(p => p.EndsWith(".png") || p.EndsWith(".jpg"))
                    .Select(p => p.Replace('\\', '/')).OrderBy(p => p).ToArray()
                : new string[0];
            _index = Mathf.Clamp(_index, 0, Mathf.Max(0, _paths.Length - 1));
        }

        void OnGUI()
        {
            if (!EditorApplication.isPlaying)
                EditorGUILayout.HelpBox("Press Play, then pick a screenshot to lay over the game.", MessageType.Info);
            if (_paths.Length == 0)
            {
                EditorGUILayout.HelpBox("No screenshots in " + Folder + " yet.", MessageType.Warning);
                if (GUILayout.Button("Refresh")) Refresh();
                return;
            }

            EditorGUI.BeginChangeCheck();
            _on = EditorGUILayout.Toggle("Show overlay", _on);
            _opacity = EditorGUILayout.Slider("Opacity", _opacity, 0f, 1f);
            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("◀ Prev")) _index = (_index - 1 + _paths.Length) % _paths.Length;
                if (GUILayout.Button("Next ▶")) _index = (_index + 1) % _paths.Length;
                if (GUILayout.Button("Refresh")) Refresh();
            }
            _scroll = EditorGUILayout.BeginScrollView(_scroll);
            for (int i = 0; i < _paths.Length; i++)
            {
                var name = _paths[i].Substring(Folder.Length + 1);
                if (GUILayout.Toggle(i == _index, name, "Button")) _index = i;
            }
            EditorGUILayout.EndScrollView();
            if (EditorGUI.EndChangeCheck() || GUI.changed) Apply();
        }

        void Apply()
        {
            if (!EditorApplication.isPlaying) return;
            if (!_on || _paths.Length == 0) { ReferenceOverlay.Hide(); return; }
            var tex = AssetDatabase.LoadAssetAtPath<Texture2D>(_paths[_index]);
            ReferenceOverlay.Show(tex, _opacity);
        }
    }
}
