using System.Collections.Generic;
using SpaceInvaders.Entities;
using SpaceInvaders.Helpers;

namespace SpaceInvaders.Boundaries {

  public struct ShipDisplayData {
    /// <summary>
    /// Area occupied by the ship.
    /// </summary>
    public Rectangle Area { get; set; }
    public bool Exploding { get; set; }
  }

  public struct ShotDisplayData {
    public bool IsFromPlayer { get; set; }
    public Rectangle Area { get; set; }
  }

  public struct AlienDisplayData {
    public AlienType Type { get; set; }
    public Rectangle Area { get; set; }
  }

  public struct DisplayData {
    public ShipDisplayData? ShipData { get; set; }
    public List<AlienDisplayData> AliensData { get; set; }
    public List<ShotDisplayData> ShotsData { get; set; }
  }

  /// <summary>
  /// Interface to which external components request information on
  /// what to display and their corresponding information.
  /// </summary>
  public interface IDisplayProvider {
    DisplayData GetDisplayData();
  }
}
