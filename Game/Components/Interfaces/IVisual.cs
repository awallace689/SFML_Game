using SFML.Graphics;

namespace Game.Components
{
  interface IVisual
  {
    Color Color { get; set; }
    Shape Shape { get; set; }
    int X { get; set; }
    int Y { get; set; }
  }
}