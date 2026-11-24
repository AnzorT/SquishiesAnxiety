// Shows cards in Unity: each CardLayer of each card on screen as a UiPiece (its texture drawn again only when its
// markup changes), placed and faded every frame, stacked in the cards' paint order from `order` up. A layer that stands
// for a live character (the result card's three, TrioItem: CardLayer.Creature) is a CreatureView instead, playing what
// the card asks (Creatures/ResultRig.cs CardCreatureView, through `MakeLive` / `CanLive`, so the cards don't need the
// creature code). `LiveCharacters` is the switch: off, the result cards show their stars.
using System.Collections.Generic;
using UnityEngine;

namespace SquishSquad.Ui.Cards
{
    public sealed class CardPieces
    {
        readonly Transform _parent;
        readonly int _order;
        readonly Dictionary<CardLayer, (UiPiece piece, int version)> _pieces = new Dictionary<CardLayer, (UiPiece, int)>();
        readonly HashSet<CardLayer> _seen = new HashSet<CardLayer>();
        readonly List<CardLayer> _gone = new List<CardLayer>();

        /// <summary>The result cards' live characters on (when every one of a card's three can be drawn: ResultRig.Can).</summary>
        public static bool LiveCharacters = true;

        /// <summary>A live character on screen (Creatures/ResultRig.cs): made for a layer, then synced every frame.</summary>
        public interface ILive { void Sync(SquishSquad.Vector.Affine transform, float opacity, int order); void Destroy(); }
        /// <summary>Set by the creature code: makes a layer's live character under `parent`; whether a creature can be
        /// drawn live.</summary>
        public static System.Func<Transform, CardCreature, ILive> MakeLive;
        public static System.Func<string, bool> CanLive;
        readonly Dictionary<CardLayer, ILive> _live = new Dictionary<CardLayer, ILive>();

        public CardPieces(Transform parent, int order)
        {
            _parent = parent;
            _order = order;
            TrioItem.LiveFor ??= keys => LiveCharacters && MakeLive != null && CanLive != null && System.Array.TrueForAll(keys, k => CanLive(k));
            if (!_arsLoaded) LoadArs();
            Card.LoadXml ??= name => Resources.Load<TextAsset>("Cards/" + name)?.text
                ?? throw new System.InvalidOperationException("Resources/Cards/" + name + ".xml is missing: run node tools/unity/export-cards.mjs");
        }

        /// <summary>Places every layer of `cards` (bottom first); pieces of layers no longer shown go.</summary>
        public void Sync(IEnumerable<Card> cards) => SyncLayers(LayersOf(cards));

        /// <summary>The same for any cards (a Blitz run's broad cards among the others, bottom first).</summary>
        public void Sync(IEnumerable<SquishSquad.Ui.Blitz.ICardView> cards) => SyncLayers(LayersOf(cards));

        static IEnumerable<IEnumerable<CardLayer>> LayersOf(IEnumerable<Card> cards) { foreach (var c in cards) { c.Update(); yield return c.Layers(); } }
        static IEnumerable<IEnumerable<CardLayer>> LayersOf(IEnumerable<SquishSquad.Ui.Blitz.ICardView> cards) { foreach (var c in cards) { c.Update(); yield return c.Layers(); } }

        void SyncLayers(IEnumerable<IEnumerable<CardLayer>> cards)
        {
            _seen.Clear();
            int i = 0;
            foreach (var layers in cards)
            {
                foreach (var l in layers)
                {
                    _seen.Add(l);
                    if (l.Creature != null)
                    {
                        if (!_live.TryGetValue(l, out var live)) _live[l] = live = MakeLive?.Invoke(_parent, l.Creature);
                        if (live == null) l.Creature.Failed = true; else live.Sync(l.Transform, l.Visible ? l.Opacity : 0, _order + i);
                        i++;
                        continue;
                    }
                    if (!_pieces.TryGetValue(l, out var e)) e = (UiPiece.Create(_parent, "card " + l.Name, 0), -1);
                    if (e.version != l.Version)
                    {
                        e.piece.SetSvg(l.Markup, l.W, l.H, l.Margin);
                        e.version = l.Version;
                    }
                    _pieces[l] = e;
                    e.piece.Transform = l.Transform;
                    e.piece.Opacity = l.Opacity;
                    e.piece.Visible = l.Visible;
                    e.piece.Order = _order + i++;
                    e.piece.Apply();
                }
            }
            _gone.Clear();
            foreach (var l in _pieces.Keys) if (!_seen.Contains(l)) _gone.Add(l);
            foreach (var l in _gone)
            {
                Kill(_pieces[l].piece.gameObject);
                _pieces.Remove(l);
            }
            _gone.Clear();
            foreach (var l in _live.Keys) if (!_seen.Contains(l)) _gone.Add(l);
            foreach (var l in _gone)
            {
                _live[l]?.Destroy();
                _live.Remove(l);
            }
        }

        static bool _arsLoaded;
        [System.Serializable] sealed class ArtList { public Art[] artList; }
        [System.Serializable] sealed class Art { public string key; public float ar; }
        // the cut-outs' height / width (Resources/Stack/stack.json, stack/art.js): the result's grey shapes
        static void LoadArs()
        {
            _arsLoaded = true;
            var text = Resources.Load<TextAsset>("Stack/stack")?.text;
            if (text == null) return;
            var d = new Dictionary<string, float>();
            foreach (var a in JsonUtility.FromJson<ArtList>(text).artList) d[a.key] = a.ar;
            TrioItem.ArOf = k => d.TryGetValue(k, out var v) ? v : 1;
        }

        public void Clear() => Sync(new Card[0]);

        static void Kill(Object o) { if (Application.isPlaying) Object.Destroy(o); else Object.DestroyImmediate(o); }
    }
}
