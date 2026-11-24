// Shows cards in Unity: each CardLayer of each card on screen as a UiPiece (its texture drawn again only when its
// markup changes), placed and faded every frame, stacked in the cards' paint order from `order` up.
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

        public CardPieces(Transform parent, int order)
        {
            _parent = parent;
            _order = order;
            Card.LoadXml ??= name => Resources.Load<TextAsset>("Cards/" + name)?.text
                ?? throw new System.InvalidOperationException("Resources/Cards/" + name + ".xml is missing: run node tools/unity/export-cards.mjs");
        }

        /// <summary>Places every layer of `cards` (bottom first); pieces of layers no longer shown go.</summary>
        public void Sync(IEnumerable<Card> cards)
        {
            _seen.Clear();
            int i = 0;
            foreach (var c in cards)
            {
                c.Update();
                foreach (var l in c.Layers())
                {
                    _seen.Add(l);
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
        }

        public void Clear() => Sync(new Card[0]);

        static void Kill(Object o) { if (Application.isPlaying) Object.Destroy(o); else Object.DestroyImmediate(o); }
    }
}
