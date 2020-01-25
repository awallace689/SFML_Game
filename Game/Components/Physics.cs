using Game.Components;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;

namespace Game.Components
{
  public class VelocityVec
  {
    public Vector2f Vector = new Vector2f(0, 0);
    public delegate Vector2f Transform(Time dTime, Vector2f vec, float xConst, float yConst);

    public void Apply(Time dTime, float xConst, float minX, float maxX, float yConst, float minY, float maxY, Transform transform)
    {
      Vector2f result = transform(dTime, Vector, xConst, yConst);

      // transform + -result >= Min
      if (result.X < 0 && Vector.X + result.X >= minX)
      {
        Vector.X += result.X;
      }
      // transform + -result <= Min
      else if (result.X < 0 && Vector.X + result.X <= minX)
      {
        if (Vector.X > minX)
        {
          Vector.X = minX;
        }
      }

      // transform + result <= Max
      if (result.X > 0 && Vector.X + result.X <= maxX)
      {
        Vector.X += result.X;
      }
      else if (result.X > 0 && Vector.X + result.X >= maxX)
      {
        if (Vector.X < maxX)
        {
          Vector.X = maxX;
        }
      }

      // transform + -result >= Min 
      if (result.Y < 0 && Vector.Y + result.Y >= minY)
      {
        Vector.Y += result.Y;
      }
      // transform + -result <= Min
      else if (result.Y < 0 && Vector.Y + result.Y <= minY)
      {
        if (Vector.Y > minY)
        {
          Vector.Y = minY;
        }
      }

      // transform + result <= Max
      if (result.Y > 0 && Vector.Y + result.Y <= maxY)
      {
        Vector.Y += result.Y;
      }
      else if (result.Y > 0 && Vector.Y + result.Y >= maxY)
      {
        if (Vector.Y < maxY)
        {
          Vector.Y = maxY;
        }
      }
    }
  }

  // public class AccelerVec
  // {
  //   public Vector2f Vector = new Vector2f(0, 0);
  //   public delegate Vector2f Transform(Time dTime, Vector2f vec);

  //   public void Apply(Time dTime, float minX, float maxX, float minY, float maxY, Transform transform)
  //   {
  //     Vector2f result = transform(dTime, Vector);

  //     // transform + -result >= Min
  //     if (result.X < 0 && Vector.X + result.X >= minX)
  //     {
  //       Vector.X += result.X;
  //     }
  //     // transform + -result <= Min
  //     else if (result.X < 0 && Vector.X + result.X <= minX)
  //     {
  //       if (Vector.X > minX)
  //       {
  //         Vector.X = minX;
  //       }
  //     }

  //     // transform + result <= Max
  //     if (result.X > 0 && Vector.X + result.X <= maxX)
  //     {
  //       Vector.X += result.X;
  //     }
  //     else if (result.X > 0 && Vector.X + result.X >= maxX)
  //     {
  //       if (Vector.X < maxX)
  //       {
  //         Vector.X = maxX;
  //       }
  //     }

  //     // transform + -result >= Min
  //     if (result.Y < 0 && Vector.Y + result.Y >= minY)
  //     {
  //       Vector.Y += result.Y;
  //     }
  //     // transform + -result <= Min
  //     else if (result.Y < 0 && Vector.Y + result.Y <= minY)
  //     {
  //       if (Vector.Y > minY)
  //       {
  //         Vector.Y = minY;
  //       }
  //     }

  //     // transform + result <= Max
  //     if (result.Y > 0 && Vector.Y + result.Y <= maxY)
  //     {
  //       Vector.Y += result.Y;
  //     }
  //     else if (result.Y > 0 && Vector.Y + result.Y >= maxY)
  //     {
  //       if (Vector.Y < maxY)
  //       {
  //         Vector.Y = maxY;
  //       }
  //     }
  //   }
  // }
}