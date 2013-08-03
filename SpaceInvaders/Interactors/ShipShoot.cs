using SpaceInvaders.Entities;

namespace SpaceInvaders.Interactors {

  /// <summary>
  /// Command to shoot in the current frame.
  /// </summary>
  internal class ShipShoot {

    public void Execute() {
      if (null != Game.Ship) {
        Game.Ship.Shoot();
      }
    }
  }
}
