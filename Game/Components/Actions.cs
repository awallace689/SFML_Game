using System;
using Game.Components;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections;
using System.Collections.Generic;

namespace Game.Components
{
  public static class MovementActions 
  {
    public static Vector2f MoveRight(Time dTime, Vector2f vec, float xConst, float yConst)
    {
      Vector2f transf = new Vector2f(
        xConst * (dTime.AsMilliseconds() / WindowOptions.Delay),
        0
      );

      return transf;
    }

    public static Vector2f MoveLeft(Time dTime, Vector2f vec, float xConst, float yConst)
    {
      Vector2f transf = new Vector2f(
        -(xConst * (dTime.AsMilliseconds() / WindowOptions.Delay)),
        0
      );

      return transf;
    }

    public static Vector2f MoveUp(Time dTime, Vector2f vec, float xConst, float yConst)
    {
      Vector2f transf = new Vector2f(
        0,
        -(yConst * (dTime.AsMilliseconds() / WindowOptions.Delay))
      );

      return transf;
    }

    public static Vector2f MoveDown(Time dTime, Vector2f vec, float xConst, float yConst)
    {
      Vector2f transf = new Vector2f(
        0,
        (yConst * (dTime.AsMilliseconds() / WindowOptions.Delay))
      );

      return transf;
    }
  }
}