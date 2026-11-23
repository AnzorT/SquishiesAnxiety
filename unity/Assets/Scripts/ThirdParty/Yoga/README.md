# Yoga (vendored)

Meta's Yoga flexbox layout engine (the one React Native lays out with), as the pure C# port
**Yoga.Net**, converted to C# 9 / netstandard2.1 so Unity 6 compiles it.

- Source: https://github.com/chenrensong/Yoga.Net (`src/Yoga.Net`)
- Commit: `baf14fcd6cbf21d8930a297e32ef3b76674c37bd` (2026-04-05, package version 3.2.3)
- License: MIT (see `LICENSE`, Meta's license, which upstream ships). Keep the file.
- Namespace: `Facebook.Yoga`, unchanged. The code compiles into `SquishSquad.Runtime`, with no asmdef of its own.
- Contents: layout math only. It does no I/O, networking, reflection-emit, P/Invoke, or process/environment access.
  The one side effect is the default logger, which writes Yoga warnings to `Console`. To route them
  to `Debug.Log`, call `YGConfigSetLogger`.

## What changed from upstream

These are mechanical changes only. The algorithm is unchanged.

- `#nullable enable` at the top of every file. Upstream sets `<Nullable>enable</Nullable>` in its csproj, which Unity has no equivalent for.
- Added `using System;` where upstream relied on `ImplicitUsings` (`Enums/Wrap.cs`, `Enums/Gutter.cs`, `Node/CachedMeasurement.cs`, `Numeric/FloatOptional.cs`).
- File-scoped namespaces became block namespaces (`YogaConstants.cs`, `Enums/Wrap.cs`, `Enums/PhysicalEdge.cs`, `Numeric/FloatOptional.cs`).
- C# 9 has no parameterless struct constructors:
  - `CachedMeasurement()` became `CachedMeasurement.Create()`, with the same -1 / MaxContent initial values. Its two call sites in `Node/LayoutResults.cs` now call `Create()`.
  - `LayoutData()` became `LayoutData.Create()`, called from `Algorithm/CalculateLayout.cs`.
- `Enums/YogaEnums.cs` (was `enums/YogaEnums.cs`): the folder was merged into `Enums/` so the two names don't collide on case-insensitive file systems.
  - `System.Runtime.CompilerServices.Unsafe` and `System.Numerics.BitOperations` are not in netstandard2.1. They were replaced as follows:
    - `ToUnderlying` gained non-generic overloads (`Edge`, `Gutter`, `Dimension`, which is every engine call site). These are a plain cast with no allocation. The generic fallback now uses `Convert.ToInt32`.
    - `Ordinals<T>` uses `Enum.ToObject`.
    - `BitCount` uses a small local leading-zero count.

## Tests

The upstream test suite (`tests/Yoga.Net.Tests`, xunit v3) is copied unmodified into
`tools/unity/yoga/tests`. It runs against this folder compiled as Unity sees it
(`tools/unity/yoga/engine`: netstandard2.1, C# 9, no implicit usings, warnings as errors). From the repo root:

```
dotnet run --project tools/unity/yoga/tests
```

The expected result matches upstream at this commit: `Total: 833, Failed: 0, Skipped: 35`. The skips mirror the C++ suite's `GTEST_SKIP()`.

## React Native defaults

A fresh `YGConfigNew()` already behaves like React Native, because `UseWebDefaults` is off by default.
With it off, the defaults are:

- `flexDirection: column`
- `alignContent: flex-start`
- `flexShrink: 0`
- `position: relative`
- `boxSizing: border-box`
- `flex: n > 0` means grow n with flexBasis 0

Don't call `YGConfigSetUseWebDefaults(cfg, true)`. That switches to CSS defaults: row, stretch, shrink 1.

Two other config settings to match React Native:

- **Pixel rounding:** call `YGConfigSetPointScaleFactor(cfg, scale)`, where `scale` is RN's `PixelRatio.get()`, i.e. device pixels per layout point. Layout results are then rounded to that pixel grid, as RN does. A value of `0` disables rounding.
- **Errata:** RN's default ("classic", non-strict layout conformance) sets `YGConfigSetErrata(cfg, YGErrata.All)`. Use `YGErrata.None` for spec-conformant layout. Check this against the RN version being ported.

Create all nodes from the same config.

## Usage

```csharp
using Facebook.Yoga;
using static Facebook.Yoga.YGConfigAPI; using static Facebook.Yoga.YGNodeAPI;
using static Facebook.Yoga.YGNodeStyleAPI; using static Facebook.Yoga.YGNodeLayoutAPI;

var cfg = YGConfigNew(); YGConfigSetPointScaleFactor(cfg, 3f); YGConfigSetErrata(cfg, YGErrata.All);
var root = YGNodeNewWithConfig(cfg); YGNodeStyleSetWidth(root, 360); YGNodeStyleSetPadding(root, YGEdge.All, 16);
YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row); YGNodeStyleSetFlexWrap(root, YGWrap.Wrap); YGNodeStyleSetGap(root, YGGutter.All, 8);
YGNodeStyleSetJustifyContent(root, YGJustify.SpaceBetween); YGNodeStyleSetAlignItems(root, YGAlign.Center);
var card = YGNodeNewWithConfig(cfg); YGNodeStyleSetFlexGrow(card, 1); YGNodeStyleSetHeight(card, 100);
YGNodeStyleSetMargin(card, YGEdge.Horizontal, 4); YGNodeStyleSetBorder(card, YGEdge.All, 2); YGNodeInsertChild(root, card, 0);
var label = YGNodeNewWithConfig(cfg); YGNodeInsertChild(card, label, 0);  // text leaf: Yoga asks it for its size
YGNodeSetMeasureFunc(label, (node, w, wMode, h, hMode) => { float natural = 104f; /* e.g. TMP GetPreferredValues(text).x */
    float width = wMode == MeasureMode.Undefined ? natural : System.Math.Min(natural, w);
    return new YGSize { Width = width, Height = 18f * (float)System.Math.Ceiling(natural / System.Math.Max(width, 1f)) }; });
var badge = YGNodeNewWithConfig(cfg); YGNodeStyleSetPositionType(badge, YGPositionType.Absolute); YGNodeInsertChild(card, badge, 1);
YGNodeStyleSetPosition(badge, YGEdge.Top, -6); YGNodeStyleSetPosition(badge, YGEdge.Right, -6); YGNodeStyleSetWidth(badge, 20); YGNodeStyleSetHeight(badge, 20);
YGNodeCalculateLayout(root, 360, float.NaN, YGDirection.LTR);  // NaN = unconstrained height
float x = YGNodeLayoutGetLeft(card), y = YGNodeLayoutGetTop(card), cw = YGNodeLayoutGetWidth(card), ch = YGNodeLayoutGetHeight(card);
// root 360x132; card (20,16) 320x100; label (2,2) 316x18; badge (304,-4) 20x20
```

Results are in points, relative to the parent's border box, with y pointing down.
When converting to a Unity `RectTransform` (y up), negate the top value.
