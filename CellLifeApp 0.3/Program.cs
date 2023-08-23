using System;
using System.Windows;
using System.IO;
using System.Runtime.Serialization;
using OpenTK;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Common.Input;

namespace CellLifeApp_0._3
{
    class Program
    {
        static void Main(string[] args)
        {
            var windowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(800, 600),
                WindowBorder = WindowBorder.Resizable,
                WindowState = WindowState.Normal,
                StartFocused = true,

                APIVersion = new Version(4, 6),
                Flags = ContextFlags.Default,
                Profile = ContextProfile.Compatability,
                API = ContextAPI.OpenGL,
            };
            var screen = new AppWindow(windowSettings);
            screen.Run();
        }
    }
}
