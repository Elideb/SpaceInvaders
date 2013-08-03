using SpaceInvaders.Helpers;

namespace SpaceInvaders.Entities {

  internal class ShotEnemy : Shot {

    public ShotEnemy(Vector2 pos)
      : base(pos, new Vector2(.01f, .02f), new Vector2(.0f, -.05f)) {
    }

    public override void Update() {
      base.Update();

      // Check if it collides with the player.
      if (null != Game.Ship) {
        CheckShipCollision();
      }
    }

    private void CheckShipCollision() {
      Ship ship = Game.Ship;

      if (ship.Area.Contains(Position)) {
        // Destroy player ship!
        // Lose one life!
        // Spawn player after a while!
      }
    }
  }
}
