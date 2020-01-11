using System;
using SFML.Window;
using SFML.Graphics;

namespace Game
{
    class Program
    {
        int count = 0;
        static void Main(string[] args)
        {
            Window window = new Window(
                new VideoMode(WindowOptions.Width, WindowOptions.Height), 
                WindowOptions.Title
            );

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
        int x { get; set; }
        int y { get; set; }
    }

    class WindowOptions {
        public static uint Height = 600;
        public static uint Width = 800;
        public static string Title = "Hello friend!";

        public static void AddGlobalEvents(Window window) {
            window.Closed += (sender, e) => {(sender as Window).Close();};
        }
    }
}
