using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SkiaLiteUI;

public class TextBuilder
{
    public SKFont Font { get; set; }
    public Vector Position { get; set; }
    public SKColor Color { get; set; }
    public Vector Step { get; set; }

    public TextBuilder(SKFont font, Vector position, SKColor color)
    {
        Font = font;
        Position = position;
        Color = color;
    }

    public TextWidget Create(string text)
    {
        var widget = new TextWidget(Font, Position, text) { Color = Color };
        Position += Step;
        return widget;
    }
}
