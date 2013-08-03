using SpaceInvaders.Helpers;

namespace SpaceInvaders.Entities {

  internal abstract class Shot : MovingEntity, IUpdatable, ICleanable {

    public Shot(Vector2 pos, Vector2 size, Vector2 speed)
      : base(pos, size, speed) {
      // TODO : Actually, this is a setup method. Use a shots pool.

      Game.Shots.Add(this);
      Game.Updatables.Add(this);
    }

    protected void Destroy() {
      Game.Cleanables.Add(this);
    }

    #region IUpdatable Members

    public virtual void Update() {
      this.Move();

      if (!Game.Area.Contains(Area.BottomLeft)
        && !Game.Area.Contains(Area.TopRight)) {
        this.Destroy();
      }
    }

    #endregion

    #region ICleanable Members

    public void Clean() {
      // TODO : Return to pool.
      Game.Shots.Remove(this);
      Game.Updatables.Remove(this);
    }

    #endregion
  }
}
