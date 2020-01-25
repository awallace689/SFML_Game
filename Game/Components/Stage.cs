using System;
using Game.Components;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;
using System.Collections;

namespace Game.Components
{
  class StageEntity : IStaticEntity
  {
    public HashSet<EntityFlags> Flags { get; }
    public Shape Shape { get; set; }
    private int height = 100;
    public StageEntity()
    {
      Shape = new RectangleShape(new Vector2f(WindowOptions.Width, height));
      Shape.Position = new Vector2f(0, WindowOptions.Height - height);
      Shape.FillColor = Color.Green;
    }
  }
}