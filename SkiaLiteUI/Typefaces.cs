using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;

namespace SkiaLiteUI;

public static class Typefaces
{
    static Dictionary<string, SKTypeface> dict = new();

    public static SKTypeface GetFromFile(string file)
    {
        dict.TryGetValue(file, out var typeface);
        if(typeface != null)
            return typeface;

        typeface = SKTypeface.FromFile(file);
        dict.Add(file, typeface);
        return typeface;
    }
}
