using SkiaSharp;
using System;
using System.Collections.Generic;

namespace SkiaLiteUI;

public abstract class Widget
{
    Action? action;
    public void AddAction(Action action) => this.action = action;
    public virtual void Act(float deltaTime) { action?.Act(deltaTime); }

    public List<Widget> Children { get; } = new();
    public virtual void Draw(SKCanvas canvas)
    {
        DrawSelf(canvas);
        for(int i=0; i<Children.Count; i++)
            Children[i].Draw(canvas);
    }
    public abstract void DrawSelf(SKCanvas canvas);
}

public class RectWidget : Widget
{
    public Vector Position { get; }
    public Vector Size { get; }
    public SKColor Color { get; init; } = SKColors.White;
    public float Radius { get; set; } = 0;

    public RectWidget(Vector origin, Vector size)
    {
        Position = origin;
        Size = size;
    }

    public override void DrawSelf(SKCanvas canvas)
    {
        using SKPaint paint = Util.CreatePaint(this.Color);
        canvas.DrawRoundRect(new SKRoundRect((SKRect)this, this.Radius), paint);
    }

    public static explicit operator SKRect(RectWidget r)
    {
        return new SKRect(  r.Position.X, r.Position.Y, // todo: Symmetry Format
                            r.Position.X + r.Size.X,
                            r.Position.Y + r.Size.Y);
    }

    // todo: Where this method should move into ?
    public static RectWidget CreateRandom(Random rand, Vector max, Vector size)
    {
        var widget = new RectWidget(rand.NextVector(max), size)
                            { Color = rand.NextColor() };
        if(GlobalRandom.Obj.Next(2) == 1)
            widget.AddAction(new RectAnimation(widget));

        widget.Children.Add(new RectWidget(widget.Position, widget.Size / 4));
        widget.Children.Add(new RectWidget(widget.Position + new Vector(100, 100),
                                            widget.Size / 4) { Color = SKColors.Green });
        return widget;
    }
}
