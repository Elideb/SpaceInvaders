using System.Collections.Generic;
using SpaceInvaders.Boundaries;
using SpaceInvaders.Helpers;
using SpaceInvaders.Interactors;

namespace SpaceInvaders.Entities {

  public static class Game {

    public static void Initialize() {
      // Services
      new DisplayProvider();
      new InputReceiver();
      new TimeReceiver();

      // Interactors
      Game.ShipMove = new ShipMove();
      Game.ShipShoot = new ShipShoot();

      // TODO : Read configuration structures from external service
      // and initialize each entity with its corresponding data.

      // Entities
      Game.Ship = new Ship(new Vector2(.5f, .05f), new Vector2(.04f, .04f), .2f);

      Aliens = new AlienArmy();
      Aliens.Initialize(new Vector2(.5f, .7f), 11, 5, new Vector2(.05f, .05f), new Vector2(.025f, .025f));
    }

    #region Entities

    internal static Ship Ship { get; set; }

    internal static AlienArmy Aliens { get; set; }

    private static List<Shot> shots = new List<Shot>();
    internal static List<Shot> Shots {
      get { return shots; }
    }

    private static List<IUpdatable> updatables = new List<IUpdatable>();
    internal static List<IUpdatable> Updatables {
      get { return updatables; }
    }

    private static List<ICleanable> cleanables = new List<ICleanable>();
    internal static List<ICleanable> Cleanables {
      get { return cleanables; }
    }

    /// <summary>
    /// Area in which the game is played.
    /// </summary>
    private static Rectangle area = new Rectangle(Point.zero, Vector2.one);

    /// <summary>
    /// Get the area in which the game is played.
    /// </summary>
    internal static Rectangle Area {
      get { return area; }
    }


    #endregion

    #region Interactors

    internal static ShipMove ShipMove { get; set; }

    internal static ShipShoot ShipShoot { get; set; }

    #endregion
  }
}
