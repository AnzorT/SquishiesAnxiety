// The chest unlock's creature after the BAM (Screens/Chests/ChestSmashView.cs "heroRig" slot, tools/chest/host.html
// rigReady / rigLive / popAt): the creature's native rig, its body's box at rest measured once (rigReady: idle at its
// first instant, getBBox), then it grows out of the middle of the burst (its middle kept on it, stretched tall, arms up,
// turning round once), hops, lands on its place (dust at its feet, sparkles over its head), squashes, wobbles and
// cheers ('happy'), then stands in its idle with its fidgets. Its feet stand at the slot's Fx, Fy, its body as big as
// fits W x H (rigPlace): the motion is HeroPop.cs (Unity-free, shared with the tests). Drawn by a CreatureView placed
// like the result cards' (CardCreatureView.Place).
using System;
using System.Collections.Generic;
using SquishSquad.Creatures.Js;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;
using UnityEngine;

namespace SquishSquad.Creatures
{
    public sealed class HeroCreature : IHeroRig
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Wire() => SquishSquad.Screens.ChestSmashView.LiveHero = _ => NativeRig.Ready();

        readonly Transform _parent;
        readonly string _key;
        NativeRig _rig;
        GameObject _holder;
        CreatureView _view;
        HeroPop _pop;
        int _size;

        public HeroCreature(Transform parent, string key) { _parent = parent; _key = key; _rig = NativeRig.Create(key); }
        public string Key => _key;
        public bool Failed => _rig == null;

        // IHeroRig: what popAt asks of the rig
        void IHeroRig.Play(string move) => _rig.Play(move);
        void IHeroRig.Ext(IDictionary<string, double> e) => _rig.Ext(e);
        void IHeroRig.Emit(string kind, double x, double y) => _rig.Emit(kind, null, x, y, 0);

        public void Sync(LiveCreature lc, Affine shake, float opacity, int order)
        {
            if (_rig == null) return;
            if (_pop == null)
            {
                _rig.FrameAt(0);
                var b = RigHost.RestBox(_rig.Id);
                if (b == null) return;
                _pop = new HeroPop(b) { Landed = () => Audio.Snd.Synth(Audio.ChestSounds.Land) };
                _size = Mathf.Clamp(Mathf.RoundToInt(100 * (float)_pop.Fit(lc) * 1.12f * UiPiece.PxPerDp), 32, 1024);
                _holder = new GameObject("hero creature " + _key);
                _holder.transform.SetParent(_parent, false);
                _view = CreatureView.Create(_holder.transform, _rig, new Rect(0, 0, _size, _size), order);
            }
            var m = shake * _pop.Step(lc, this);
            _view.Order = order;
            _view.SetOpacity(opacity);
            CardCreatureView.Place(_holder.transform, m, _size);
            if (!_holder.activeSelf) _holder.SetActive(true);
        }

        public void Hide() { if (_holder != null) _holder.SetActive(false); }

        public void Destroy()
        {
            _rig?.Dispose(); _rig = null;
            if (_holder != null) { if (Application.isPlaying) UnityEngine.Object.Destroy(_holder); else UnityEngine.Object.DestroyImmediate(_holder); }
        }
    }
}
