using SpaceInvaders.Helpers;

namespace SpaceInvaders.Entities {

  internal class MovingEntity : PhysicalEntity {

    /// <summary>
    /// Movement speed, in screen ratio per second.
    /// </summary>
    private Vector2 speed;

    /// <summary>
    /// Get or set the movement speed, in screen ratio per second.
    /// </summary>
    public Vector2 Speed {
      get { return speed; }
      set { speed = value; }
    }

    public MovingEntity(Vector2 position, Vector2 size, Vector2 speed)
      : base(position, size) {
        this.Speed = speed;
    }

    public void Move() {
      this.Position += new Vector2(Speed.X, Speed.Y) * Time.Elapsed;
    }
  }
}
