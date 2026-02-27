using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiaLiteUI;

public static class Fonts
{
    record TypefaceSize (SKTypeface typeface, float size);

    static Dictionary<TypefaceSize, SKFont> dict = new();

    public static SKFont Get(SKTypeface typeface, float size)
    {
        var key = new TypefaceSize(typeface, size);
        if (dict.ContainsKey(key))
            return dict[key];

        SKFont font = new SKFont(typeface, size);
        dict[key] = font;
        return font;
    }
    public static SKFont GetFromFile(string file, float size)
    {
        var typeface = Typefaces.GetFromFile(file);
        return Get (typeface, size);
    }
}
