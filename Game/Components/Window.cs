using SFML.Window;
using SFML.Graphics;

namespace Game.Components
{
  public static class WindowOptions
  {
    public static uint Height = 600;
    public static uint Width = 800;

    public static VideoMode VMode = new VideoMode(Width, Height);
    public static string Title = "Hello friend!";

    public static RenderWindow Window 
    { 
        get {
            RenderWindow window = new RenderWindow(VMode, Title);
            window.SetVerticalSyncEnabled(true);
            return window;
        }
    }

    public static void AddGlobalEvents(Window window)
    {
      window.Closed += (sender, e) => { (sender as Window).Close(); };
    }
  }
}