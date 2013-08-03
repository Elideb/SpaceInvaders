using SpaceInvaders.Helpers;

namespace SpaceInvaders.Entities {

  /// <summary>
  /// Player ship. Moves left and right.
  /// </summary>
  internal class Ship : PhysicalEntity {

    private float speed;

    public float Speed {
      get { return speed; }
      private set { speed = value; }
    }

    /// <summary>
    /// When did the ship shoot last time.
    /// </summary>
    private float lastShot = -5.0f;

    /// <summary>
    /// How many seconds must have passed for the ship to shoot again.
    /// </summary>
    private float shotFrequency = 1.0f;

    public Ship(Vector2 position, Vector2 size, float speed)
      : base(position, size) {
        Speed = speed;
    }

    public void Move(Direction direction) {
      float dir = direction == Direction.Left ? -1 : 1;
      this.SetX(this.Position.X + this.Speed * Time.Elapsed * dir);
    }

    private void SetX(float x) {
      this.Position = new Vector2(x, this.Position.Y);
    }

    public void Shoot() {
      if (Time.Total - this.lastShot > this.shotFrequency) {
        // TODO : Get shot from pool and initiliaze it.
        ShotPlayer shot = new ShotPlayer();
        this.lastShot = Time.Total;
      }
    }
  }
}
