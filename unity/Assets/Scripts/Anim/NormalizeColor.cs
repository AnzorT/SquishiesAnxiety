// Port of @react-native/normalize-colors 0.74 (what AnimatedInterpolation's colorToRgba uses): CSS color
// string to 0xRRGGBBAA, or null when the string isn't a color. Same regexes, same parse/round rules.
using System.Text.RegularExpressions;

namespace SquishSquad.Anim
{
    public static class NormalizeColor
    {
        const string NUMBER = @"[-+]?\d*\.?\d+";
        const string PERCENTAGE = NUMBER + "%";
        const RegexOptions Opt = RegexOptions.ECMAScript | RegexOptions.CultureInvariant;

        static string Call(params string[] args) { return @"\(\s*(" + string.Join(@")\s*,?\s*(", args) + @")\s*\)"; }
        static string CallWithSlashSeparator(params string[] args)
        {
            var head = new string[args.Length - 1];
            System.Array.Copy(args, head, head.Length);
            return @"\(\s*(" + string.Join(@")\s*,?\s*(", head) + @")\s*/\s*(" + args[args.Length - 1] + @")\s*\)";
        }
        static string CommaSeparatedCall(params string[] args) { return @"\(\s*(" + string.Join(@")\s*,\s*(", args) + @")\s*\)"; }

        static readonly Regex rgb = new Regex("rgb" + Call(NUMBER, NUMBER, NUMBER), Opt);
        static readonly Regex rgba = new Regex("rgba(" + CommaSeparatedCall(NUMBER, NUMBER, NUMBER, NUMBER) + "|" + CallWithSlashSeparator(NUMBER, NUMBER, NUMBER, NUMBER) + ")", Opt);
        static readonly Regex hsl = new Regex("hsl" + Call(NUMBER, PERCENTAGE, PERCENTAGE), Opt);
        static readonly Regex hsla = new Regex("hsla(" + CommaSeparatedCall(NUMBER, PERCENTAGE, PERCENTAGE, NUMBER) + "|" + CallWithSlashSeparator(NUMBER, PERCENTAGE, PERCENTAGE, NUMBER) + ")", Opt);
        static readonly Regex hwb = new Regex("hwb" + Call(NUMBER, PERCENTAGE, PERCENTAGE), Opt);
        static readonly Regex hex3 = new Regex("^#([0-9a-fA-F]{1})([0-9a-fA-F]{1})([0-9a-fA-F]{1})$", Opt);
        static readonly Regex hex4 = new Regex("^#([0-9a-fA-F]{1})([0-9a-fA-F]{1})([0-9a-fA-F]{1})([0-9a-fA-F]{1})$", Opt);
        static readonly Regex hex6 = new Regex("^#([0-9a-fA-F]{6})$", Opt);
        static readonly Regex hex8 = new Regex("^#([0-9a-fA-F]{8})$", Opt);

        static uint Hex(string s) { return System.Convert.ToUInt32(s, 16); }
        static int I(double v) { return JsMath.ToInt32(v); }

        public static uint? Normalize(string color)
        {
            if (color == null) return null;
            Match m;
            if ((m = hex6.Match(color)).Success) return Hex(m.Groups[1].Value + "ff");

            uint? kw = Keyword(color);
            if (kw.HasValue) return kw;

            if ((m = rgb.Match(color)).Success)
                return (uint)((I(Parse255(m.Groups[1].Value)) << 24) | (I(Parse255(m.Groups[2].Value)) << 16) | (I(Parse255(m.Groups[3].Value)) << 8) | 0x000000ff);

            if ((m = rgba.Match(color)).Success)
            {
                if (m.Groups[6].Success)
                    return (uint)((I(Parse255(m.Groups[6].Value)) << 24) | (I(Parse255(m.Groups[7].Value)) << 16) | (I(Parse255(m.Groups[8].Value)) << 8) | I(Parse1(m.Groups[9].Value)));
                return (uint)((I(Parse255(m.Groups[2].Value)) << 24) | (I(Parse255(m.Groups[3].Value)) << 16) | (I(Parse255(m.Groups[4].Value)) << 8) | I(Parse1(m.Groups[5].Value)));
            }

            if ((m = hex3.Match(color)).Success)
            {
                string r = m.Groups[1].Value, g = m.Groups[2].Value, b = m.Groups[3].Value;
                return Hex(r + r + g + g + b + b + "ff");
            }

            if ((m = hex8.Match(color)).Success) return Hex(m.Groups[1].Value);

            if ((m = hex4.Match(color)).Success)
            {
                string r = m.Groups[1].Value, g = m.Groups[2].Value, b = m.Groups[3].Value, a = m.Groups[4].Value;
                return Hex(r + r + g + g + b + b + a + a);
            }

            if ((m = hsl.Match(color)).Success)
                return (uint)(HslToRgb(Parse360(m.Groups[1].Value), ParsePercentage(m.Groups[2].Value), ParsePercentage(m.Groups[3].Value)) | 0x000000ff);

            if ((m = hsla.Match(color)).Success)
            {
                if (m.Groups[6].Success)
                    return (uint)(HslToRgb(Parse360(m.Groups[6].Value), ParsePercentage(m.Groups[7].Value), ParsePercentage(m.Groups[8].Value)) | I(Parse1(m.Groups[9].Value)));
                return (uint)(HslToRgb(Parse360(m.Groups[2].Value), ParsePercentage(m.Groups[3].Value), ParsePercentage(m.Groups[4].Value)) | I(Parse1(m.Groups[5].Value)));
            }

            if ((m = hwb.Match(color)).Success)
                return (uint)(HwbToRgb(Parse360(m.Groups[1].Value), ParsePercentage(m.Groups[2].Value), ParsePercentage(m.Groups[3].Value)) | 0x000000ff);

            return null;
        }

        static double Hue2Rgb(double p, double q, double t)
        {
            if (t < 0) t += 1;
            if (t > 1) t -= 1;
            if (t < 1.0 / 6) return p + (q - p) * 6 * t;
            if (t < 1.0 / 2) return q;
            if (t < 2.0 / 3) return p + (q - p) * (2.0 / 3 - t) * 6;
            return p;
        }

        static int HslToRgb(double h, double s, double l)
        {
            double q = l < 0.5 ? l * (1 + s) : l + s - l * s;
            double p = 2 * l - q;
            double r = Hue2Rgb(p, q, h + 1.0 / 3);
            double g = Hue2Rgb(p, q, h);
            double b = Hue2Rgb(p, q, h - 1.0 / 3);
            return (I(JsMath.Round(r * 255)) << 24) | (I(JsMath.Round(g * 255)) << 16) | (I(JsMath.Round(b * 255)) << 8);
        }

        static int HwbToRgb(double h, double w, double b)
        {
            if (w + b >= 1)
            {
                int gray = I(JsMath.Round((w * 255) / (w + b)));
                return (gray << 24) | (gray << 16) | (gray << 8);
            }
            double red = Hue2Rgb(0, 1, h + 1.0 / 3) * (1 - w - b) + w;
            double green = Hue2Rgb(0, 1, h) * (1 - w - b) + w;
            double blue = Hue2Rgb(0, 1, h - 1.0 / 3) * (1 - w - b) + w;
            return (I(JsMath.Round(red * 255)) << 24) | (I(JsMath.Round(green * 255)) << 16) | (I(JsMath.Round(blue * 255)) << 8);
        }

        static double Parse255(string str)
        {
            double v = JsNumber.ParseInt(str);
            if (v < 0) return 0;
            if (v > 255) return 255;
            return v;
        }

        static double Parse360(string str)
        {
            double v = JsNumber.ParseFloat(str);
            return (((v % 360) + 360) % 360) / 360;
        }

        static double Parse1(string str)
        {
            double num = JsNumber.ParseFloat(str);
            if (num < 0) return 0;
            if (num > 1) return 255;
            return JsMath.Round(num * 255);
        }

        static double ParsePercentage(string str)
        {
            double v = JsNumber.ParseFloat(str);
            if (v < 0) return 0;
            if (v > 100) return 1;
            return v / 100;
        }

        static uint? Keyword(string name)
        {
            switch (name)
            {
                case "transparent": return 0x00000000;
                case "aliceblue": return 0xf0f8ffff;
                case "antiquewhite": return 0xfaebd7ff;
                case "aqua": return 0x00ffffff;
                case "aquamarine": return 0x7fffd4ff;
                case "azure": return 0xf0ffffff;
                case "beige": return 0xf5f5dcff;
                case "bisque": return 0xffe4c4ff;
                case "black": return 0x000000ff;
                case "blanchedalmond": return 0xffebcdff;
                case "blue": return 0x0000ffff;
                case "blueviolet": return 0x8a2be2ff;
                case "brown": return 0xa52a2aff;
                case "burlywood": return 0xdeb887ff;
                case "burntsienna": return 0xea7e5dff;
                case "cadetblue": return 0x5f9ea0ff;
                case "chartreuse": return 0x7fff00ff;
                case "chocolate": return 0xd2691eff;
                case "coral": return 0xff7f50ff;
                case "cornflowerblue": return 0x6495edff;
                case "cornsilk": return 0xfff8dcff;
                case "crimson": return 0xdc143cff;
                case "cyan": return 0x00ffffff;
                case "darkblue": return 0x00008bff;
                case "darkcyan": return 0x008b8bff;
                case "darkgoldenrod": return 0xb8860bff;
                case "darkgray": return 0xa9a9a9ff;
                case "darkgreen": return 0x006400ff;
                case "darkgrey": return 0xa9a9a9ff;
                case "darkkhaki": return 0xbdb76bff;
                case "darkmagenta": return 0x8b008bff;
                case "darkolivegreen": return 0x556b2fff;
                case "darkorange": return 0xff8c00ff;
                case "darkorchid": return 0x9932ccff;
                case "darkred": return 0x8b0000ff;
                case "darksalmon": return 0xe9967aff;
                case "darkseagreen": return 0x8fbc8fff;
                case "darkslateblue": return 0x483d8bff;
                case "darkslategray": return 0x2f4f4fff;
                case "darkslategrey": return 0x2f4f4fff;
                case "darkturquoise": return 0x00ced1ff;
                case "darkviolet": return 0x9400d3ff;
                case "deeppink": return 0xff1493ff;
                case "deepskyblue": return 0x00bfffff;
                case "dimgray": return 0x696969ff;
                case "dimgrey": return 0x696969ff;
                case "dodgerblue": return 0x1e90ffff;
                case "firebrick": return 0xb22222ff;
                case "floralwhite": return 0xfffaf0ff;
                case "forestgreen": return 0x228b22ff;
                case "fuchsia": return 0xff00ffff;
                case "gainsboro": return 0xdcdcdcff;
                case "ghostwhite": return 0xf8f8ffff;
                case "gold": return 0xffd700ff;
                case "goldenrod": return 0xdaa520ff;
                case "gray": return 0x808080ff;
                case "green": return 0x008000ff;
                case "greenyellow": return 0xadff2fff;
                case "grey": return 0x808080ff;
                case "honeydew": return 0xf0fff0ff;
                case "hotpink": return 0xff69b4ff;
                case "indianred": return 0xcd5c5cff;
                case "indigo": return 0x4b0082ff;
                case "ivory": return 0xfffff0ff;
                case "khaki": return 0xf0e68cff;
                case "lavender": return 0xe6e6faff;
                case "lavenderblush": return 0xfff0f5ff;
                case "lawngreen": return 0x7cfc00ff;
                case "lemonchiffon": return 0xfffacdff;
                case "lightblue": return 0xadd8e6ff;
                case "lightcoral": return 0xf08080ff;
                case "lightcyan": return 0xe0ffffff;
                case "lightgoldenrodyellow": return 0xfafad2ff;
                case "lightgray": return 0xd3d3d3ff;
                case "lightgreen": return 0x90ee90ff;
                case "lightgrey": return 0xd3d3d3ff;
                case "lightpink": return 0xffb6c1ff;
                case "lightsalmon": return 0xffa07aff;
                case "lightseagreen": return 0x20b2aaff;
                case "lightskyblue": return 0x87cefaff;
                case "lightslategray": return 0x778899ff;
                case "lightslategrey": return 0x778899ff;
                case "lightsteelblue": return 0xb0c4deff;
                case "lightyellow": return 0xffffe0ff;
                case "lime": return 0x00ff00ff;
                case "limegreen": return 0x32cd32ff;
                case "linen": return 0xfaf0e6ff;
                case "magenta": return 0xff00ffff;
                case "maroon": return 0x800000ff;
                case "mediumaquamarine": return 0x66cdaaff;
                case "mediumblue": return 0x0000cdff;
                case "mediumorchid": return 0xba55d3ff;
                case "mediumpurple": return 0x9370dbff;
                case "mediumseagreen": return 0x3cb371ff;
                case "mediumslateblue": return 0x7b68eeff;
                case "mediumspringgreen": return 0x00fa9aff;
                case "mediumturquoise": return 0x48d1ccff;
                case "mediumvioletred": return 0xc71585ff;
                case "midnightblue": return 0x191970ff;
                case "mintcream": return 0xf5fffaff;
                case "mistyrose": return 0xffe4e1ff;
                case "moccasin": return 0xffe4b5ff;
                case "navajowhite": return 0xffdeadff;
                case "navy": return 0x000080ff;
                case "oldlace": return 0xfdf5e6ff;
                case "olive": return 0x808000ff;
                case "olivedrab": return 0x6b8e23ff;
                case "orange": return 0xffa500ff;
                case "orangered": return 0xff4500ff;
                case "orchid": return 0xda70d6ff;
                case "palegoldenrod": return 0xeee8aaff;
                case "palegreen": return 0x98fb98ff;
                case "paleturquoise": return 0xafeeeeff;
                case "palevioletred": return 0xdb7093ff;
                case "papayawhip": return 0xffefd5ff;
                case "peachpuff": return 0xffdab9ff;
                case "peru": return 0xcd853fff;
                case "pink": return 0xffc0cbff;
                case "plum": return 0xdda0ddff;
                case "powderblue": return 0xb0e0e6ff;
                case "purple": return 0x800080ff;
                case "rebeccapurple": return 0x663399ff;
                case "red": return 0xff0000ff;
                case "rosybrown": return 0xbc8f8fff;
                case "royalblue": return 0x4169e1ff;
                case "saddlebrown": return 0x8b4513ff;
                case "salmon": return 0xfa8072ff;
                case "sandybrown": return 0xf4a460ff;
                case "seagreen": return 0x2e8b57ff;
                case "seashell": return 0xfff5eeff;
                case "sienna": return 0xa0522dff;
                case "silver": return 0xc0c0c0ff;
                case "skyblue": return 0x87ceebff;
                case "slateblue": return 0x6a5acdff;
                case "slategray": return 0x708090ff;
                case "slategrey": return 0x708090ff;
                case "snow": return 0xfffafaff;
                case "springgreen": return 0x00ff7fff;
                case "steelblue": return 0x4682b4ff;
                case "tan": return 0xd2b48cff;
                case "teal": return 0x008080ff;
                case "thistle": return 0xd8bfd8ff;
                case "tomato": return 0xff6347ff;
                case "turquoise": return 0x40e0d0ff;
                case "violet": return 0xee82eeff;
                case "wheat": return 0xf5deb3ff;
                case "white": return 0xffffffff;
                case "whitesmoke": return 0xf5f5f5ff;
                case "yellow": return 0xffff00ff;
                case "yellowgreen": return 0x9acd32ff;            }
            return null;
        }
    }
}
