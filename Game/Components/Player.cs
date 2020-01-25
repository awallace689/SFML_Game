using System;
using Game.Components;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections;
using System.Collections.Generic;

namespace Game.Components
{
  class PlayerEntity : IActor
  {
    public Shape Shape { get; set; }
    public IActorTransformer Transformer { get; set; }
    public HashSet<EntityFlags> Flags { get; private set; }
    public PlayerEntity()
    {
      Shape = new RectangleShape(new Vector2f(40, 40));
      Shape.FillColor = Color.Yellow;
      Shape.OutlineThickness = -2;
      Shape.OutlineColor = Color.Black;

      Transformer = new PlayerTransformer();
      Flags = new HashSet<EntityFlags>();
    }
  }

  public class PlayerTransformer : IActorTransformer
  {
    public float MaxMoveAccel = 0.1F;
    // AccelerVec Acceleration { get; set; }
    public VelocityVec Velocity { get; set; }
    public PlayerTransformer()
    {
      // Acceleration = new AccelerVec();
      Velocity = new VelocityVec();
    }
  }
}