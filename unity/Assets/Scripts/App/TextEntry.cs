// Typing into a field drawn by the Unity code (no uGUI): on the phone the system keyboard (TouchScreenKeyboard, its own
// input line hidden so the field on screen shows the text), in the editor and on desktop the keyboard
// (Input.inputString; Backspace, Enter / Escape to leave the field, Tab to the next one, Ctrl / Cmd+V to paste).
// The field draws its text and caret itself (AuthArt.Input).
//
// Limits: the caret is always at the end (no moving it, no selection, no copy); on desktop an IME's composition isn't
// shown until it's committed; Android's suggestions bar follows the keyboard type (email / number pad / text), with
// autocorrect off as the app's fields have it.
using UnityEngine;

namespace SquishSquad.App
{
    public sealed class TextEntry
    {
        public enum Kind { Text, Email, Number, Password }

        public string Field { get; private set; }
        public float LastChange { get; private set; }   // Time.unscaledTime of the last edit or focus (the caret's blink restarts)
        /// <summary>Set when the player pressed Tab: the screen moves on to its next field.</summary>
        public bool TabPressed { get; private set; }
        TouchScreenKeyboard _kb;
        int _max;

        static bool UseSystemKeyboard => TouchScreenKeyboard.isSupported && Application.isMobilePlatform;

        public void Focus(string field, string text, Kind kind, int maxLength, string placeholder)
        {
            if (Field == field && (_kb == null || _kb.active)) return;
            Field = field;
            _max = maxLength;
            LastChange = Time.unscaledTime;
            if (UseSystemKeyboard)
            {
                TouchScreenKeyboard.hideInput = true;
                var type = kind == Kind.Email ? TouchScreenKeyboardType.EmailAddress : kind == Kind.Number ? TouchScreenKeyboardType.NumberPad : TouchScreenKeyboardType.Default;
                _kb = TouchScreenKeyboard.Open(text ?? "", type, false, false, kind == Kind.Password, false, placeholder, maxLength > 0 ? maxLength : 0);
            }
        }

        public void Blur()
        {
            Field = null;
            if (_kb != null) { _kb.active = false; _kb = null; }
        }

        /// <summary>The field's text after this frame's typing (the same string when nothing was typed).</summary>
        public string Poll(string text)
        {
            TabPressed = false;
            if (Field == null) return text;
            text ??= "";
            string was = text;
            if (_kb != null)
            {
                if (_kb.status != TouchScreenKeyboard.Status.Visible) { var t = _kb.text; Blur(); return Clip(t ?? text); }
                text = _kb.text ?? text;
            }
            else
            {
                foreach (char c in Input.inputString)
                {
                    if (c == '\b') { if (text.Length > 0) text = text.Substring(0, text.Length - 1); }
                    else if (c == '\n' || c == '\r') { Blur(); break; }
                    else if (c == '\t') { TabPressed = true; }
                    else if (!char.IsControl(c)) text += c;
                }
                if (Input.GetKeyDown(KeyCode.Escape)) Blur();
                if (Input.GetKeyDown(KeyCode.Tab)) TabPressed = true;
                bool cmd = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.RightCommand);
                if (cmd && Input.GetKeyDown(KeyCode.V)) text += (GUIUtility.systemCopyBuffer ?? "").Replace("\n", " ").Replace("\r", "");
            }
            text = Clip(text);
            if (text != was) LastChange = Time.unscaledTime;
            return text;
        }

        string Clip(string t) => _max > 0 && t.Length > _max ? t.Substring(0, _max) : t;

        /// <summary>The caret's blink: on for 500 ms, off for 500 ms, from the last edit.</summary>
        public bool CaretOn => Field != null && (Time.unscaledTime - LastChange) % 1f < 0.5f;
    }
}
