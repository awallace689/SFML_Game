using System;
using Game.Components;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Game
{
  public class Game
  {
    public static void Run()
    {
      RenderWindow window = WindowOptions.Window;
      
      Clock c = new Clock();
      Time dTime = Time.FromSeconds(0);
      
      Stage Stage = new Stage();
      Player Player = new Player();

      WindowOptions.AddGlobalEvents(window);
      
      // Open
      while (window.IsOpen)
      {
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
            window.Draw(Player.Shape);
            HandleInput(Player, dTime);
            window.Display();
            dTime = c.Restart();
          }
        }
        window.Display();
      }
    }

    static void HandleInput(Player player, Time dTime) {
      if (
        SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.A)
        && !SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.D)) 
      {
        player.Transformer.MoveLeft(dTime, player.Transformer.Velocity);
      }
      else if (
        SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.D)
        && !SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.A)) 
      {
        player.Transformer.MoveRight(dTime, player.Transformer.Velocity);
      }

      if (
        SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.W)
        && !SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.S)) 
      {
        player.Transformer.MoveUp(dTime, player.Transformer.Velocity);
      }
      else if (
        SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.S)
        && !SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.W)) 
      {
        player.Transformer.MoveDown(dTime, player.Transformer.Velocity);
      }
    }
  }  
}