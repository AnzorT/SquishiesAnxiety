// Just enough PNG for the test: 8-bit, non-interlaced RGB / RGBA / grey(+alpha) in, RGBA out (System.IO.Compression).
using System;
using System.IO;
using System.IO.Compression;

static class Png
{
    public static (int w, int h, byte[] rgba) Read(string path)
    {
        var data = File.ReadAllBytes(path);
        int pos = 8, w = 0, h = 0, colorType = 0, depth = 0;
        var idat = new MemoryStream();
        while (pos + 8 <= data.Length)
        {
            int len = (data[pos] << 24) | (data[pos + 1] << 16) | (data[pos + 2] << 8) | data[pos + 3];
            string type = System.Text.Encoding.ASCII.GetString(data, pos + 4, 4);
            if (type == "IHDR")
            {
                w = (data[pos + 8] << 24) | (data[pos + 9] << 16) | (data[pos + 10] << 8) | data[pos + 11];
                h = (data[pos + 12] << 24) | (data[pos + 13] << 16) | (data[pos + 14] << 8) | data[pos + 15];
                depth = data[pos + 16]; colorType = data[pos + 17];
                if (depth != 8 || data[pos + 20] != 0) throw new NotSupportedException(path + ": only 8-bit non-interlaced PNG");
            }
            else if (type == "IDAT") idat.Write(data, pos + 8, len);
            else if (type == "IEND") break;
            pos += 12 + len;
        }
        int ch = colorType == 6 ? 4 : colorType == 2 ? 3 : colorType == 4 ? 2 : colorType == 0 ? 1 : throw new NotSupportedException("PNG colour type " + colorType);
        idat.Position = 0;
        var raw = new MemoryStream();
        using (var z = new ZLibStream(idat, CompressionMode.Decompress)) z.CopyTo(raw);
        var r = raw.ToArray();
        int stride = w * ch;
        var cur = new byte[stride]; var prev = new byte[stride];
        var outp = new byte[w * h * 4];
        for (int y = 0; y < h; y++)
        {
            int f = r[y * (stride + 1)];
            Array.Copy(r, y * (stride + 1) + 1, cur, 0, stride);
            for (int i = 0; i < stride; i++)
            {
                int a = i >= ch ? cur[i - ch] : 0, b = prev[i], c = i >= ch ? prev[i - ch] : 0;
                int add = f == 1 ? a : f == 2 ? b : f == 3 ? (a + b) / 2 : f == 4 ? Paeth(a, b, c) : 0;
                cur[i] = (byte)(cur[i] + add);
            }
            for (int x = 0; x < w; x++)
            {
                int o = (y * w + x) * 4, s = x * ch;
                if (ch >= 3) { outp[o] = cur[s]; outp[o + 1] = cur[s + 1]; outp[o + 2] = cur[s + 2]; outp[o + 3] = ch == 4 ? cur[s + 3] : (byte)255; }
                else { outp[o] = outp[o + 1] = outp[o + 2] = cur[s]; outp[o + 3] = ch == 2 ? cur[s + 1] : (byte)255; }
            }
            var t = prev; prev = cur; cur = t;
        }
        return (w, h, outp);
    }

    static int Paeth(int a, int b, int c) { int p = a + b - c, pa = Math.Abs(p - a), pb = Math.Abs(p - b), pc = Math.Abs(p - c); return pa <= pb && pa <= pc ? a : pb <= pc ? b : c; }

    public static void Write(string path, int w, int h, byte[] rgba)
    {
        var raw = new MemoryStream();
        for (int y = 0; y < h; y++) { raw.WriteByte(0); raw.Write(rgba, y * w * 4, w * 4); }
        var comp = new MemoryStream();
        using (var z = new ZLibStream(comp, CompressionLevel.Fastest, true)) { raw.Position = 0; raw.CopyTo(z); }
        using var fs = File.Create(path);
        fs.Write(new byte[] { 137, 80, 78, 71, 13, 10, 26, 10 });
        var ihdr = new byte[13];
        Be(ihdr, 0, w); Be(ihdr, 4, h); ihdr[8] = 8; ihdr[9] = 6;
        Chunk(fs, "IHDR", ihdr); Chunk(fs, "IDAT", comp.ToArray()); Chunk(fs, "IEND", Array.Empty<byte>());
    }

    static void Be(byte[] b, int o, int v) { b[o] = (byte)(v >> 24); b[o + 1] = (byte)(v >> 16); b[o + 2] = (byte)(v >> 8); b[o + 3] = (byte)v; }
    static void Chunk(Stream s, string type, byte[] data)
    {
        var len = new byte[4]; Be(len, 0, data.Length); s.Write(len);
        var td = new byte[4 + data.Length]; System.Text.Encoding.ASCII.GetBytes(type, 0, 4, td, 0); Array.Copy(data, 0, td, 4, data.Length);
        s.Write(td);
        var crc = new byte[4]; Be(crc, 0, (int)Crc(td)); s.Write(crc);
    }
    static uint[] _table;
    static uint Crc(byte[] b)
    {
        if (_table == null) { _table = new uint[256]; for (uint n = 0; n < 256; n++) { uint c = n; for (int k = 0; k < 8; k++) c = (c & 1) != 0 ? 0xedb88320u ^ (c >> 1) : c >> 1; _table[n] = c; } }
        uint crc = 0xffffffffu; foreach (var x in b) crc = _table[(crc ^ x) & 0xff] ^ (crc >> 8); return crc ^ 0xffffffffu;
    }
}
