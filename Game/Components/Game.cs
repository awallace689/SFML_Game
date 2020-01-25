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
    public static float PlAYER_MOVE_MAX = 8.0f;
    public static float PLAYER_MOVE_ACCEL = 0.3f;
    public static void Run()
    {
      RenderWindow Window = WindowOptions.Window;

      Clock c = new Clock();
      Time dTime = Time.FromSeconds(0);

      StageEntity Stage = new StageEntity();
      PlayerEntity Player = new PlayerEntity();

      List<IActor> ActorList = new List<IActor>();
      ActorList.Add(Player);

      List<IStaticEntity> StaticEntityList = new List<IStaticEntity>();
      StaticEntityList.Add(Stage);

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

            foreach (IActor actor in ActorList)
            {
              while (actor.Flags.Count > 0)
              {
                actor.Flags.Clear();
              }
            }
            
            HandleInput(Player, dTime);

            foreach (IActor actor in ActorList)
            {
              Physics.Update(actor, dTime);
            }
            
            foreach (IActor actor in ActorList) 
            {
              actor.Shape.Position += actor.Transformer.Velocity.Vector;
            }

            Window.Display();
            dTime = c.Restart();
          }
        }

        Window.Display();
      }
    }

    static void RunLoopEvents(IEntity entity)
    {

    }

    static void HandleInput(PlayerEntity player, Time dTime)
    {
      if (Keyboard.IsKeyPressed(Keyboard.Key.A)
        && !Keyboard.IsKeyPressed(Keyboard.Key.D))
      {
        player.Transformer.Velocity.Apply(
          dTime,
          PLAYER_MOVE_ACCEL,
          -PlAYER_MOVE_MAX,
          0,
          0,
          float.NegativeInfinity,
          float.PositiveInfinity,
          MovementActions.MoveLeft
        );

        player.Flags.Add(EntityFlags.IGNORE_FRICTION);
      }
      else if (Keyboard.IsKeyPressed(Keyboard.Key.D)
        && !Keyboard.IsKeyPressed(Keyboard.Key.A))
      {
        player.Transformer.Velocity.Apply(
          dTime,
          PLAYER_MOVE_ACCEL,
          0,
          PlAYER_MOVE_MAX,
          0,
          float.NegativeInfinity,
          float.PositiveInfinity,
          MovementActions.MoveRight
        );

        player.Flags.Add(EntityFlags.IGNORE_FRICTION);
      }

      if (Keyboard.IsKeyPressed(Keyboard.Key.W)
        && !Keyboard.IsKeyPressed(Keyboard.Key.S))
      {
        player.Transformer.Velocity.Apply(
          dTime,
          0,
          float.NegativeInfinity,
          float.PositiveInfinity,
          PLAYER_MOVE_ACCEL,
          -PlAYER_MOVE_MAX,
          0,
          MovementActions.MoveUp
        );

        player.Flags.Add(EntityFlags.IGNORE_GRAVITY);
      }
      else if (Keyboard.IsKeyPressed(Keyboard.Key.S)
        && !Keyboard.IsKeyPressed(Keyboard.Key.W))
      {
        player.Transformer.Velocity.Apply(
          dTime,
          0,
          float.NegativeInfinity,
          float.PositiveInfinity,
          PLAYER_MOVE_ACCEL,
          0,
          PlAYER_MOVE_MAX,
          MovementActions.MoveDown
        );

        player.Flags.Add(EntityFlags.IGNORE_GRAVITY);
      }
    }
  }
}