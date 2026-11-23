// What Ui/Screens/FlexNode doesn't say yet (max / min sizes, margin auto, wrapping), and text leaves measured as Chrome
// lays them out (UiSvg / TextFlow), for the StyleSheets here.
using System;
using Facebook.Yoga;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using static Facebook.Yoga.YGNodeStyleAPI;

namespace SquishSquad.Screens
{
    public static class FlexX
    {
        public static FlexNode MaxW(this FlexNode n, float v) { YGNodeStyleSetMaxWidth(n.Node, v); return n; }
        public static FlexNode MinW(this FlexNode n, float v) { YGNodeStyleSetMinWidth(n.Node, v); return n; }
        public static FlexNode MinH(this FlexNode n, float v) { YGNodeStyleSetMinHeight(n.Node, v); return n; }
        public static FlexNode MarginAuto(this FlexNode n, YGEdge e) { YGNodeStyleSetMarginAuto(n.Node, e); return n; }
        public static FlexNode Wrap(this FlexNode n) { YGNodeStyleSetFlexWrap(n.Node, YGWrap.Wrap); return n; }
        public static FlexNode RowGap(this FlexNode n, float v) { YGNodeStyleSetGap(n.Node, YGGutter.Row, v); return n; }
        public static FlexNode ColGap(this FlexNode n, float v) { YGNodeStyleSetGap(n.Node, YGGutter.Column, v); return n; }

        /// <summary>A one-line Text (its box: the run's width, the line's height).</summary>
        public static FlexNode Txt(string name, string text, TextStyle t) => FlexNode.Leaf(name, _ => (Kit.W(text, t), Kit.LH(t)));
        /// <summary>A paragraph that wraps (TextFlow).</summary>
        public static FlexNode Para(string name, TextFlow f) => FlexNode.Leaf(name, f.Measure);
        /// <summary>A box of a fixed size (a picture, a drawing).</summary>
        public static FlexNode Box(string name, float w, float h) => new FlexNode(name).Size(w, h);
    }
}
