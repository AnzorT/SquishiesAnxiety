// One screen at a time, like App.js's `screen` state. Each screen builds its own visual tree from code.
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace PlushCrush.App
{
    public abstract class AppScreen
    {
        public VisualElement View { get; private set; }
        protected AppRoot App { get; private set; }

        internal VisualElement Create(AppRoot app)
        {
            App = app;
            View = Build();
            View.style.position = Position.Absolute;
            View.style.left = 0; View.style.top = 0; View.style.right = 0; View.style.bottom = 0;
            return View;
        }

        protected abstract VisualElement Build();
        public virtual void OnShown() { }
        public virtual void OnHidden() { }
        /// <summary>The phone's back button. Return true when handled here (closing a popup, say).</summary>
        public virtual bool OnBack() => false;
    }

    public sealed class ScreenRouter
    {
        readonly AppRoot _app;
        readonly VisualElement _layer;
        readonly Stack<AppScreen> _history = new Stack<AppScreen>();

        public AppScreen Current { get; private set; }

        internal ScreenRouter(AppRoot app, VisualElement layer)
        {
            _app = app;
            _layer = layer;
        }

        /// <summary>Show a screen. With remember, Back returns to the one shown before it.</summary>
        public void Show(AppScreen screen, bool remember = false)
        {
            if (Current != null)
            {
                Current.OnHidden();
                Current.View.RemoveFromHierarchy();
                if (remember) _history.Push(Current);
            }
            Current = screen;
            _layer.Add(screen.Create(_app));
            screen.OnShown();
        }

        public void Back()
        {
            if (Current != null && Current.OnBack()) return;
            if (_history.Count > 0) Show(_history.Pop());
        }
    }
}
