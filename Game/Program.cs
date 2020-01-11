using System;
using SFML.Window;
using SFML.Graphics;
using Game;
using Game.Components;

namespace Game
{
  class Program
  {
    static void Main(string[] args)
    {
      Game Game = new Game();
      Game.Run();
    }
  }
}
