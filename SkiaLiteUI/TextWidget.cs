using SkiaSharp;
using SkiaSharp.HarfBuzz;

namespace SkiaLiteUI;

public class TextWidget : Widget //, ICloneable
{
    public SKFont Font { get; set; }
    public Vector Position { get; set; }
    public string Text { get; set; }
    public SKColor Color { get; set; } = SKColors.Black;
                
    public TextWidget(SKFont font, Vector position, string text)
    {
        Font = font;
        Position = position;
        Text = text;
    }

    public TextWidget(SKFont font, Vector position, string text, SKColor color) : this(font, position, text)
    {
        Color = color;
    }

    public override void DrawSelf(SKCanvas canvas)
    {
        using SKPaint paint = Util.CreatePaint(Color);
        canvas.DrawShapedText(Text, Position.X, Position.Y,
                                SKTextAlign.Left, Font, paint);
    }
// Copy Constructor; Prototype Design Pattern
/*    public TextWidget(TextWidget sourceObj)
    {
        Font = sourceObj.Font;
        Position = sourceObj.Position;
        Text = sourceObj.Text;
        Color = sourceObj.Color;
    }

    // Clone; Prototype Design Pattern
    //object ICloneable.Clone() => Clone();
    public TextWidget Clone() // ไม่ดี เพราะใช้ initializer ต่อเลยไม่ได้
    {
        return new TextWidget(this);
    }*/
}
