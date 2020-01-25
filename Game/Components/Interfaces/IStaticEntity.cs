using System;
using Game.Components;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections;
using System.Collections.Generic;

namespace Game.Components
{
  interface IStaticEntity : IEntity
  {
    Shape Shape { get; set; }
    HashSet<EntityFlags> Flags { get; }
  }
}