using System.Collections.Generic;
using System;
using SkiaSharp;
using SkiaSharp.HarfBuzz;

namespace SkiaLiteUI;

// adapted from: https://gist.github.com/tottaka/702c5103b9574bcf773cfd53b669b888
public class SkiaTest : IDisposable, Renderer
{
    // todo: make nullable
    GRGlInterface grgInterface;
    GRContext grContext;
    SKSurface surface;
    GRBackendRenderTarget renderTarget;

    Vector clientSize;
    List<Widget> widgets = new();

    public void Init(int ClientSizeX, int ClientSizeY)
    {
        clientSize = new (ClientSizeX, ClientSizeY);
        grgInterface = GRGlInterface.Create();
        grContext = GRContext.CreateGl(grgInterface);
        // Thana: at this point, Skia is linked to current GLContext
        // see: Skia doc. GrDirectContext::MakeGl()

        uint rgba8 = 32856; // (uint)SizedInternalFormat.Rgba8
        renderTarget = new GRBackendRenderTarget(ClientSizeX, ClientSizeY, 0, 8, 
                                        new GRGlFramebufferInfo(0, rgba8));
        surface = SKSurface.Create(grContext, renderTarget, GRSurfaceOrigin.BottomLeft, SKColorType.Rgba8888);

        Random rand = new Random();
        //for (int i = 0; i < 100; ++i)
           // widgets.Add(RectWidget.CreateRandom(rand, clientSize, new (256, 256)));
        AddText();
    }

    public void Dispose()
    {
        surface.Dispose();
        renderTarget.Dispose();
        grContext.Dispose();
        grgInterface.Dispose();
    }

    public void Render(float deltaTime)
    {
        SKCanvas canvas = surface.Canvas;
        canvas.Clear(SKColors.CornflowerBlue);

        for (int i = 0; i < widgets.Count; i++)
        {
            var widget = widgets[i];
            widget.Act(deltaTime);
            widget.Draw(canvas);
        }

        canvas.Flush();
    }
        
    void AddText()
    {
        var font = Fonts.GetFromFile(@"Resources\Trirong-Regular.ttf", 40);
        var position = new Vector(100, 300);
        var text = "A รู้กตัญญูกล้ำกลืนนี้นั้นโน้น abc";

        var step = new Vector(0, 40);
        widgets.Add(new TextWidget(font, position, text, SKColors.Red));
        position += step;
        widgets.Add(new TextWidget(font, position, text, SKColors.Green));
        position += step;

        widgets.Add(new TextWidget(font, position, text, SKColors.Blue));
        position += step;

        BuildText(font);
        CloneText(font);
    }

    // Builder design pattern
 private void BuildText(SKFont font)
    {
        var step = new Vector(0, 40);
        var builder = new TextBuilder(font, new(50, 50), SKColors.Blue)
                                        { Step = new (40, 40) };


        for (int i = 0; i < 5; i++)
        {
            builder.Color = GlobalRandom.Obj.NextColor();
            widgets.Add(builder.Create("142 ธนัท" + i));
        }
    }

    // Prototype design pattern
    private void CloneText(SKFont font)
    {
        string text = "ทดสอบข้อความ prototype ";
        var prototype = new TextWidget(font, new(50, 50), text, SKColors.Blue);
        for (int i = 0; i < 5; i++)
        {
            var widget = new TextWidget(prototype)
            {
                Color = GlobalRandom.Obj.NextColor(),
                Text = text + i
            };
            widgets.Add(widget);
            prototype.Position += new Vector(0, 40);
        }
    }
}