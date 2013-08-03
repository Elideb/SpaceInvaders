using SpaceInvaders.Helpers;

namespace SpaceInvaders.Entities {

  public enum AlienType {
    Crab,
    Ant,
    Squid
  }

  internal class Alien : PhysicalEntity, ICleanable {

    public AlienColumn Column { get; private set; }

    public AlienType Type { get; private set; }

    private float lastShot = -5.0f;

    public Alien(AlienColumn column, AlienType type, Vector2 position, Vector2 size)
      : base(position, size) {
        Column = column;
        Type = type;
    }

    public void Move(Vector2 distance) {
      this.Position += distance;
    }

    public bool CanShoot(float frequency) {
      return Time.Total - lastShot > frequency;
    }

    public bool Shoot(float frequency) {
      if (!CanShoot(frequency)) {
        return false;
      }

      // TODO : Get shot from pool and initiliaze it.
      ShotEnemy shot = new ShotEnemy(this.Position);
      this.lastShot = Time.Total;

      return true;
    }

    public void Destroy() {
      Game.Cleanables.Add(this);
    }

    #region ICleanable Members

    public void Clean() {
      Column.RemoveAlien(this);

      // Return to aliens pool
    }

    #endregion
  }
}
