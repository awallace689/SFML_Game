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
      Transformer = new PlayerTransformer(Shape);
      Shape = new RectangleShape(new Vector2f(40, 40));
      Shape.FillColor = Color.Yellow;
      Shape.OutlineThickness = -2;
      Shape.OutlineColor = Color.Black;
    }
  }

  public class PlayerTransformer
  {
    public float Velocity = 2;
    public Shape Shape { get; set; }

    public PlayerTransformer(Shape shape)
    {
      Shape = shape;
    }

    public void MoveRight(Time dTime, float vel) 
    {
      Shape.Position += new Vector2f(
        vel * (dTime.AsMilliseconds() / WindowOptions.Delay),
        0
      );
    }

    public void MoveLeft(Time dTime, float vel) 
    {
      Shape.Position += new Vector2f(
        -(vel * (dTime.AsMilliseconds() / WindowOptions.Delay)),
        0
      );
    }

    public void MoveUp(Time dTime, float vel) 
    {
      Shape.Position += new Vector2f(
        0,
        -(vel * (dTime.AsMilliseconds() / WindowOptions.Delay))
      );
    }
    
    public void MoveDown(Time dTime, float vel) 
    {
      Shape.Position += new Vector2f(
        0,
        (vel * (dTime.AsMilliseconds() / WindowOptions.Delay))
      );
    }
  }
}