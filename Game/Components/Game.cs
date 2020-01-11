using System;
using Game.Components;
using SFML.Graphics;
using SFML.System;

namespace Game
{
    public class Game
    {

        public static void Run() {
            RenderWindow window = WindowOptions.Window;
            WindowOptions.AddGlobalEvents(window);
            Clock c = new Clock();
            Time dTime = Time.FromSeconds(0);
            Stage Stage = new Stage();

            // Open
            while (window.IsOpen)
            {
                window.Clear(Color.White);
                c.Restart();
                window.DispatchEvents();
                c.Restart();

                // In Focus
                while (WindowOptions.InFocus && window.IsOpen) 
                {
                    window.DispatchEvents();

                    // Delay Exceeded
                    if (c.ElapsedTime.AsMilliseconds() >= WindowOptions.Delay)
                    {
                        window.DispatchEvents();
                        window.Clear(Color.Cyan);
                        window.Draw(Stage.Shape);
                        
                        window.Display();
                        dTime = c.Restart();
                    }
                }
                window.Display();
            }
        }
    }

    class Entity {
        private int count = 0;
        public float Velocity = 1;
        public Shape Shape;

        public Entity() {
            Shape = new CircleShape(50);
            Shape.FillColor = Color.Green;
        }

        public void move(Time dTime)
        {
            if (count < 10) {
                Shape.Position += new Vector2f(Velocity * (dTime.AsMilliseconds() / WindowOptions.Delay), 0);
                count++;
            }
            else {
                Shape.Position = new Vector2f(0, Shape.Position.Y);
                count = 0;
            }
        }
    }

    class Stage {
        public Shape Shape;
        private int height = 100;
        public Stage() {
            Shape = new RectangleShape(new Vector2f(WindowOptions.Width, height));
            Shape.Position = new Vector2f(0, WindowOptions.Height - height);
            Shape.FillColor = Color.Green;
        }
    }
}