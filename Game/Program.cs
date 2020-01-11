using System;
using SFML.Window;
using SFML.Graphics;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderWindow window = WindowOptions.Window;
            WindowOptions.AddGlobalEvents(window);

            while (window.IsOpen) 
            {
                window.DispatchEvents();
            }
        }
    }

    interface VisibleEntity {
        void Render();
        Visual Visual { get; set; }
        bool Visible { get; set; } 
    }

    interface Visual {
        Color Color { get; set; }
        Shape Shape { get; set; }
        int X { get; set; }
        int Y { get; set; }
    }

    class WindowOptions {
        public static uint Height = 600;
        public static uint Width = 800;

        public static VideoMode VMode = new VideoMode(Width, Height);
        public static string Title = "Hello friend!";

        public static RenderWindow Window = new RenderWindow(VMode, Title);

        public static void AddGlobalEvents(Window window) {
            window.Closed += (sender, e) => {(sender as Window).Close();};
        }
    }
}
