using System;
using Game.Components;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Game.Components
{
  public class Player : IEntity
  {
    public Shape Shape { get; set; }
    public PlayerTransformer Transformer { get; set; }

    public Player()
    {
      Shape = new RectangleShape(new Vector2f(40, 40));
      Shape.FillColor = Color.Yellow;
      Shape.OutlineThickness = -2;
      Shape.OutlineColor = Color.Black;

      Transformer = new PlayerTransformer(Shape);
    }
  }

  public class PlayerTransformer
  {
    public float MaxMoveAccel = 0.1F;
    // AccelerVec Acceleration { get; set; }
    public VelocityVec Velocity { get; set; }
    public Shape Shape { get; set; }

    public PlayerTransformer(Shape shape)
    {
      Shape = shape;
      // Acceleration = new AccelerVec();
      Velocity = new VelocityVec();
    }

    /*******************/
    /**** MOVEMENTS ****/
    /*******************/

    public Vector2f MoveRight(Time dTime, Vector2f vec, float xConst, float yConst)
    {
      Vector2f transf = new Vector2f(
        xConst * (dTime.AsMilliseconds() / WindowOptions.Delay),
        0
      );
      
      return transf;
    }

    public Vector2f MoveLeft(Time dTime, Vector2f vec, float xConst, float yConst)
    {
      Vector2f transf = new Vector2f(
        -(xConst * (dTime.AsMilliseconds() / WindowOptions.Delay)),
        0
      );

      return transf;
    }

    public Vector2f MoveUp(Time dTime, Vector2f vec, float xConst, float yConst)
    {
      Vector2f transf = new Vector2f(
        0,
        -(yConst * (dTime.AsMilliseconds() / WindowOptions.Delay))
      );

      return transf;
    }

    public Vector2f MoveDown(Time dTime, Vector2f vec, float xConst, float yConst)
    {
      Vector2f transf = new Vector2f(
        0,
        (yConst * (dTime.AsMilliseconds() / WindowOptions.Delay))
      );

      return transf;
    }
  }
}