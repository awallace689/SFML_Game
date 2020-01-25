using System;
using Game.Components;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections;
using System.Collections.Generic;

namespace Game.Components
{
    public interface IActorTransformer
    {
      public VelocityVec Velocity { get; set; }
    }
}