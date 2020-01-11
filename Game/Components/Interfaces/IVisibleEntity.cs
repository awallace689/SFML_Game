namespace Game.Components
{
  interface VisibleEntity
  {
    void Render();
    IVisual Visual { get; set; }
    bool Visible { get; set; }
  }
}