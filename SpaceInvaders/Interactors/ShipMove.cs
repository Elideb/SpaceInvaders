using SpaceInvaders.Entities;
using SpaceInvaders.Helpers;

namespace SpaceInvaders.Interactors {

  /// <summary>
  /// Command to move the ship in the current frame.
  /// </summary>
  internal class ShipMove {

    /// <summary>
    /// Command the ship to move in a given direction.
    /// </summary>
    /// <param name="direction"></param>
    public void Execute(Direction direction) {
      if (null != Game.Ship) {
        Game.Ship.Move(direction);
      }
    }
  }
}
