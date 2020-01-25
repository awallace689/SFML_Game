using System;
using Game.Components;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;

namespace Game
{
  public class Game
  {
    public static float MAX_MOVEMENT = 3.0f;
    public static float MOVE_VEL_INCREMENT = 0.1f;
    public static void Run()
    {
      RenderWindow Window = WindowOptions.Window;
      
      Clock c = new Clock();
      Time dTime = Time.FromSeconds(0);
      
      Stage Stage = new Stage();
      Player Player = new Player();

      List<IEntity> EntityList = new List<IEntity>();
      EntityList.Add(Stage);
      EntityList.Add(Player);

      WindowOptions.AddGlobalEvents(Window);
      
      // Open
      while (Window.IsOpen)
      {
        c.Restart();
        Window.DispatchEvents();
        c.Restart();

        // In Focus
        while (WindowOptions.InFocus && Window.IsOpen)
        {
          Window.DispatchEvents();

          // Delay Exceeded
          if (c.ElapsedTime.AsMilliseconds() >= WindowOptions.Delay)
          {
            Window.DispatchEvents();
            Window.Clear(Color.Cyan);

            Window.Draw(Stage.Shape);
            Window.Draw(Player.Shape);
            HandleInput(Player, dTime);

            Player.Shape.Position += Player.Transformer.Velocity.Vector;

            Window.Display();
            dTime = c.Restart();
          }
        }
        Window.Display();
      }
    }

    static void HandleInput(Player player, Time dTime) {
      if (
       Keyboard.IsKeyPressed(Keyboard.Key.A)
        && !Keyboard.IsKeyPressed(Keyboard.Key.D)) 
      {
        player.Transformer.Velocity.Apply(
          dTime,
          MOVE_VEL_INCREMENT,
          -MAX_MOVEMENT, 
          0,
          0, 
          float.NegativeInfinity, 
          float.PositiveInfinity, 
          player.Transformer.MoveLeft 
        );
      }
      else if (
        Keyboard.IsKeyPressed(Keyboard.Key.D)
        && !Keyboard.IsKeyPressed(Keyboard.Key.A)) 
      {
        player.Transformer.Velocity.Apply(
          dTime,
          MOVE_VEL_INCREMENT,
          0, 
          MAX_MOVEMENT,
          0, 
          float.NegativeInfinity, 
          float.PositiveInfinity, 
          player.Transformer.MoveRight 
        );
      }

      if (
        Keyboard.IsKeyPressed(Keyboard.Key.W)
        && !Keyboard.IsKeyPressed(Keyboard.Key.S)) 
      {
        player.Transformer.Velocity.Apply(
          dTime,
          0,
          float.NegativeInfinity, 
          float.PositiveInfinity, 
          MOVE_VEL_INCREMENT, 
          -MAX_MOVEMENT, 
          0, 
          player.Transformer.MoveUp 
        );
      }
      else if (
        Keyboard.IsKeyPressed(Keyboard.Key.S)
        && !Keyboard.IsKeyPressed(Keyboard.Key.W)) 
      {
        player.Transformer.Velocity.Apply(
          dTime,
          0,
          float.NegativeInfinity, 
          float.PositiveInfinity, 
          MOVE_VEL_INCREMENT, 
          0, 
          MAX_MOVEMENT, 
          player.Transformer.MoveDown 
        );
      }
    }
  }  
}