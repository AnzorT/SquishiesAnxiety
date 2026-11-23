// Just enough of UnityEngine (and UiPiece, the one piece of Ui that needs it) for StackGame to run outside Unity: the
// game objects are a plain tree, Resources reads the project's files, and UiPiece only remembers what it was told to
// show (its SVG or picture, transform, opacity, order), so Blitz.cs can draw every piece with the reference rasteriser.
using System;
using System.Collections.Generic;
using System.Text.Json;
using SquishSquad.Vector;

namespace UnityEngine
{
    public enum HideFlags { None, HideAndDontSave }

    public class Object
    {
        public string name;
        public HideFlags hideFlags;
        public bool Destroyed { get; private set; }
        public static void Destroy(Object o) { if (o == null || o.Destroyed) return; o.Destroyed = true; o.OnDestroyed(); }
        public static void DestroyImmediate(Object o) => Destroy(o);
        protected virtual void OnDestroyed() { }
    }

    public sealed class Transform
    {
        public GameObject gameObject;
        public Transform parent;
        public readonly List<Transform> children = new List<Transform>();
        public void SetParent(Transform p, bool worldPositionStays) { parent?.children.Remove(this); parent = p; p?.children.Add(this); }
    }

    public sealed class GameObject : Object
    {
        public readonly Transform transform;
        public readonly List<Component> components = new List<Component>();
        public GameObject(string n) { name = n; transform = new Transform { gameObject = this }; }
        public T AddComponent<T>() where T : Component, new() { var c = new T { gameObject = this }; c.name = name; components.Add(c); return c; }
        protected override void OnDestroyed()
        {
            foreach (var c in components) Destroy(c);
            foreach (var t in transform.children.ToArray()) Destroy(t.gameObject);
            transform.parent?.children.Remove(transform);
        }
    }

    public class Component : Object
    {
        public GameObject gameObject;
        public Transform transform => gameObject.transform;
        public T[] GetComponentsInChildren<T>(bool includeInactive) where T : Component
        {
            var o = new List<T>();
            void Walk(Transform t) { foreach (var c in t.gameObject.components) if (c is T x && !x.Destroyed) o.Add(x); foreach (var k in t.children) Walk(k); }
            Walk(transform);
            return o.ToArray();
        }
    }

    public class Behaviour : Component { }
    public class MonoBehaviour : Behaviour { }
    public class TextAsset : Object { public string text; }
    public class Texture : Object { }
    public class Texture2D : Texture { }

    public static class Resources
    {
        /// <summary>(path without extension, type) → the asset, or null.</summary>
        public static Func<string, Type, Object> Loader = (p, t) => null;
        public static T Load<T>(string path) where T : Object => path == null ? null : Loader(path, typeof(T)) as T;
    }

    public static class Mathf
    {
        public static int Clamp(int v, int lo, int hi) => Math.Max(lo, Math.Min(hi, v));
        public static int Max(int a, int b) => Math.Max(a, b);
        public static int CeilToInt(float v) => (int)Math.Ceiling(v);
    }

    public static class Screen { public static int width = 2340, height = 1080; }
    public static class Time { public static double unscaledTimeAsDouble; }
    public static class Application { public static bool isPlaying = true; }
    public struct Vector2 { public float x, y; public Vector2(float x, float y) { this.x = x; this.y = y; } public static Vector2 one => new Vector2(1, 1); }
    public enum TouchPhase { Began, Moved, Stationary, Ended, Canceled }
    public struct Touch { public Vector2 position; public TouchPhase phase; }
    public enum KeyCode { Escape }

    public static class Input
    {
        public static int touchCount => 0;
        public static Touch GetTouch(int i) => default;
        public static Vector2 mousePosition => default;
        public static bool GetMouseButtonDown(int b) => false;
        public static bool GetMouseButtonUp(int b) => false;
        public static bool GetMouseButton(int b) => false;
        public static bool GetKeyDown(KeyCode k) => false;
    }

    public static class JsonUtility
    {
        public static T FromJson<T>(string json) => JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { IncludeFields = true });
    }
}

namespace SquishSquad.Menu
{
    public static class MenuState { public static int StackLevel = 1; }
}

namespace SquishSquad.Ui
{
    using UnityEngine;

    /// <summary>A stand-in for UiPiece: what it shows and where.</summary>
    public sealed class UiPiece : MonoBehaviour
    {
        public static float PxPerDp = 2.8125f;
        public static readonly List<UiPiece> All = new List<UiPiece>();
        static int _seq;
        public int Seq;
        public Affine Transform = Affine.Identity;
        public float Opacity = 1;
        public bool Visible = true;
        public int Order;
        public string Markup, Picture;
        public float W, H, Margin;
        public float Width => W;
        public float Height => H;

        public static UiPiece Create(UnityEngine.Transform parent, string name, int order)
        {
            var go = new GameObject(name);
            go.transform.SetParent(parent, false);
            var p = go.AddComponent<UiPiece>();
            p.Order = order;
            p.Seq = _seq++;
            All.Add(p);
            return p;
        }

        public void SetSvg(string markup, float w, float h, float margin = 6) { Markup = markup; Picture = null; W = w; H = h; Margin = margin; }
        public void SetPicture(Texture tex, float w, float h) { Markup = null; Picture = tex?.name; W = w; H = h; Margin = 0; }
        public void Apply() { }
    }
}
