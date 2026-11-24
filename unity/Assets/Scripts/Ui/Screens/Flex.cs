// A small builder over Yoga (ThirdParty/Yoga, React Native's layout engine) for screens ported from React Native: one
// FlexNode per RN <View> / <Text>, styled with the component's StyleSheet values, laid out with RN's defaults
// (column, shrink 0, errata All), and read back as absolute frames in dp (y down, the screen's top-left at 0, 0).
//
//   var root = new FlexNode("root").Size(832, 384).Row();
//   var hero = root.Add(new FlexNode("hero").WidthPct(34).AlignItems(YGAlign.Center));
//   var title = hero.Add(FlexNode.Text("title", w => (w, 44)));     // a leaf Yoga measures (a line of text)
//   root.Layout(832, 384);  title.Frame -> (x, y, w, h)
using System;
using System.Collections.Generic;
using Facebook.Yoga;
using static Facebook.Yoga.YGConfigAPI;
using static Facebook.Yoga.YGNodeAPI;
using static Facebook.Yoga.YGNodeLayoutAPI;
using static Facebook.Yoga.YGNodeStyleAPI;

namespace SquishSquad.Ui.Screens
{
    public struct Frame
    {
        public float X, Y, W, H;
        public Frame(float x, float y, float w, float h) { X = x; Y = y; W = w; H = h; }
        public float Right => X + W;
        public float Bottom => Y + H;
        public bool Contains(float x, float y) => x >= X && x < X + W && y >= Y && y < Y + H;
        public Frame Inset(float d) => new Frame(X - d, Y - d, W + 2 * d, H + 2 * d);
        public static Frame Lerp(Frame a, Frame b, float t) => new Frame(a.X + (b.X - a.X) * t, a.Y + (b.Y - a.Y) * t, a.W + (b.W - a.W) * t, a.H + (b.H - a.H) * t);
        public override string ToString() => $"({X:0.###}, {Y:0.###}, {W:0.###}, {H:0.###})";
    }

    public sealed class FlexNode
    {
        /// <summary>Device pixels per dp that Yoga rounds layout to. RN Android rounds to PixelRatio.get() (2.8125 on the
        /// A15); 0 (the default) keeps fractions, as Chrome's flexbox does (1/64 px), since the port's reference pictures
        /// are Chrome's (tools/unity/auth-test checks both: 0 matches Chrome best).</summary>
        public static float PointScale = 0;

        /// <summary>Border widths as Chrome draws react-native-web's (whole px: 2.5 -> 2), as every other piece of the
        /// port's UI is cut from Chrome's page; false: React Native Android's own (2.5 dp).</summary>
        public static bool WebBorders = true;
        public static float Bw(float w) => WebBorders && w >= 1 ? (float)Math.Floor(w) : w;

        static Config _config;
        static float _configScale = -1;
        static Config Cfg
        {
            get
            {
                if (_config == null || _configScale != PointScale)
                {
                    _config = YGConfigNew();
                    YGConfigSetPointScaleFactor(_config, PointScale);
                    YGConfigSetErrata(_config, YGErrata.All);
                    _configScale = PointScale;
                }
                return _config;
            }
        }

        public readonly string Name;
        public readonly Node Node;
        public readonly List<FlexNode> Children = new List<FlexNode>();
        public FlexNode Parent { get; private set; }
        /// <summary>The node's box on screen after Layout (dp; border box).</summary>
        public Frame Frame;

        public FlexNode(string name)
        {
            Name = name;
            Node = YGNodeNewWithConfig(Cfg);
        }

        /// <summary>A leaf whose size comes from `measure(availableWidth)` (NaN: unconstrained) -> (width, height).</summary>
        public static FlexNode Leaf(string name, Func<float, (float w, float h)> measure)
        {
            var n = new FlexNode(name);
            YGNodeSetMeasureFunc(n.Node, (node, w, wMode, h, hMode) =>
            {
                float avail = wMode == MeasureMode.Undefined ? float.NaN : w;
                var (mw, mh) = measure(avail);
                if (wMode == MeasureMode.Exactly) mw = w;
                else if (wMode == MeasureMode.AtMost) mw = Math.Min(mw, w);
                if (hMode == MeasureMode.Exactly) mh = h;
                else if (hMode == MeasureMode.AtMost) mh = Math.Min(mh, h);
                return new YGSize { Width = mw, Height = mh };
            });
            return n;
        }

        public FlexNode Add(FlexNode child)
        {
            child.Parent = this;
            YGNodeInsertChild(Node, child.Node, (nuint)Children.Count);
            Children.Add(child);
            return child;
        }

        public FlexNode With(params FlexNode[] kids) { foreach (var k in kids) if (k != null) Add(k); return this; }

        // ---- style (RN names) -----------------------------------------------------------------------------------
        public FlexNode Row() { YGNodeStyleSetFlexDirection(Node, YGFlexDirection.Row); return this; }
        public FlexNode Grow(float g = 1) { YGNodeStyleSetFlexGrow(Node, g); return this; }
        /// <summary>RN's `flex: n` (n > 0): grow n, shrink 1, basis 0.</summary>
        public FlexNode Flex(float n = 1) { YGNodeStyleSetFlex(Node, n); return this; }
        public FlexNode Shrink(float s) { YGNodeStyleSetFlexShrink(Node, s); return this; }
        public FlexNode Width(float w) { YGNodeStyleSetWidth(Node, w); return this; }
        public FlexNode WidthPct(float p) { YGNodeStyleSetWidthPercent(Node, p); return this; }
        public FlexNode Height(float h) { YGNodeStyleSetHeight(Node, h); return this; }
        public FlexNode HeightPct(float p) { YGNodeStyleSetHeightPercent(Node, p); return this; }
        public FlexNode Size(float w, float h) => Width(w).Height(h);
        public FlexNode Justify(YGJustify j) { YGNodeStyleSetJustifyContent(Node, j); return this; }
        public FlexNode AlignItems(YGAlign a) { YGNodeStyleSetAlignItems(Node, a); return this; }
        public FlexNode AlignSelf(YGAlign a) { YGNodeStyleSetAlignSelf(Node, a); return this; }
        public FlexNode Gap(float g) { YGNodeStyleSetGap(Node, YGGutter.All, g); return this; }
        public FlexNode Padding(float all) { YGNodeStyleSetPadding(Node, YGEdge.All, all); return this; }
        public FlexNode Padding(YGEdge e, float v) { YGNodeStyleSetPadding(Node, e, v); return this; }
        public FlexNode PadH(float v) => Padding(YGEdge.Horizontal, v);
        public FlexNode PadV(float v) => Padding(YGEdge.Vertical, v);
        public FlexNode Margin(YGEdge e, float v) { YGNodeStyleSetMargin(Node, e, v); return this; }
        public FlexNode Border(float all) { YGNodeStyleSetBorder(Node, YGEdge.All, Bw(all)); return this; }
        public FlexNode Border(YGEdge e, float v) { YGNodeStyleSetBorder(Node, e, Bw(v)); return this; }
        public FlexNode Absolute() { YGNodeStyleSetPositionType(Node, YGPositionType.Absolute); return this; }
        public FlexNode Pos(YGEdge e, float v) { YGNodeStyleSetPosition(Node, e, v); return this; }
        public FlexNode PosPct(YGEdge e, float v) { YGNodeStyleSetPositionPercent(Node, e, v); return this; }
        public FlexNode Hidden(bool hide) { YGNodeStyleSetDisplay(Node, hide ? YGDisplay.None : YGDisplay.Flex); return this; }
        public FlexNode Dirty() { if (YGNodeHasMeasureFunc(Node)) YGNodeMarkDirty(Node); return this; }

        // ---- layout -----------------------------------------------------------------------------------------------
        public void Layout(float width, float height)
        {
            YGNodeCalculateLayout(Node, width, height, YGDirection.LTR);
            Place(0, 0);
        }

        void Place(float ox, float oy)
        {
            Frame = new Frame(ox + YGNodeLayoutGetLeft(Node), oy + YGNodeLayoutGetTop(Node), YGNodeLayoutGetWidth(Node), YGNodeLayoutGetHeight(Node));
            foreach (var c in Children) c.Place(Frame.X, Frame.Y);
        }

        /// <summary>Moves this node and everything in it (a ScrollView's content scrolled by dy).</summary>
        public void Offset(float dx, float dy)
        {
            Frame.X += dx; Frame.Y += dy;
            foreach (var c in Children) c.Offset(dx, dy);
        }

        public bool Shown => YGNodeStyleGetDisplay(Node) != YGDisplay.None && (Parent == null || Parent.Shown);

        public FlexNode Find(string name)
        {
            if (Name == name) return this;
            foreach (var c in Children) { var f = c.Find(name); if (f != null) return f; }
            return null;
        }

        public void Walk(Action<FlexNode> fn) { fn(this); foreach (var c in Children) c.Walk(fn); }

        public float PaddingOf(YGEdge e) => YGNodeLayoutGetPadding(Node, e);
    }
}
