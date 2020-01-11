using Game.Components;
using SFML.Graphics;

namespace Game
{
    public class Game
    {
        public static void Run() {
            RenderWindow window = WindowOptions.Window;
            WindowOptions.AddGlobalEvents(window);

            while (window.IsOpen)
            {
                window.DispatchEvents();
            }
        }
    }
}