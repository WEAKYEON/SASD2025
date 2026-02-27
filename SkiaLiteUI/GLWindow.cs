using SDL3;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiaLiteUI;

// Adapted from https://github.com/edwardgushchin/SDL3-CS/blob/master/SDL3-CS.Examples/Create%20Window/Program.cs
// good article on keyboard: https://wiki.libsdl.org/SDL3/BestKeyboardPractices

public class GLWindow
{
    string title = "SDL3 Create Window";
    int clientX = 1920;
    int clientY = 1080;
    Renderer renderer;

    public GLWindow(string title, int clientX, int clientY, Renderer renderer)
    {
        this.title = title;
        this.clientX = clientX;
        this.clientY = clientY;
        this.renderer = renderer;
    }

    public void Run()
    {
        // 1. SDL Init
        SDLx.Init(SDL.InitFlags.Video);

        // 2. Create Window
        var window = SDLx.CreateWindow(title, clientX, clientY,
                                SDL.WindowFlags.HighPixelDensity | 
                                SDL.WindowFlags.OpenGL // | 
                                //SDL.WindowFlags.Borderless
                                );

        // https://wiki.libsdl.org/SDL3/README-highdpi
        float scale = SDL.GetWindowPixelDensity(window);

        // 3. Create GL Context
        var context = SDL.GLCreateContext(window);
        SDL.GLMakeCurrent(window, context);
        SDL.GLSetSwapInterval(1); // 1 - VSync On

        renderer.Init((int)(clientX * scale), (int)(clientY * scale));

        Stopwatch timer = Stopwatch.StartNew();
        //int loopCount = 0;
        bool isLoop = true;
        while (isLoop)
        {
            while (SDL.PollEvent(out var e))
            {
                if (e.Type == (uint)SDL.EventType.Quit)
                    isLoop = false;

                else if (e.Type == (uint)SDL.EventType.KeyDown
                        && e.Key.Key == SDL.Keycode.Escape)
                    isLoop = false;
            }

            var dt = timer.Elapsed.TotalSeconds;
            timer.Restart();
            renderer.Render((float)dt);

            //if(loopCount % 2 == 0 )
            SDLx.GLSwapWindow(window);
            //loopCount++;
        }

        renderer.Dispose();
        SDL.GLDestroyContext(context);
        SDL.DestroyWindow(window);
        SDL.Quit();
    }
}
