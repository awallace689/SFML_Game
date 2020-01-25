using System;
using Game.Components;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections;
using System.Collections.Generic;

namespace Game.Components
{
    interface IActor
    {
      Shape Shape { get; set; }
      IActorTransformer Transformer { get; set; }
      HashSet<EntityFlags> Flags { get; }
    }
}