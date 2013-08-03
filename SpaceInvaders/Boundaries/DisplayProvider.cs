using System;
using System.Collections.Generic;
using SpaceInvaders.Entities;

namespace SpaceInvaders.Boundaries {

  internal class DisplayProvider : IDisplayProvider {

    public DisplayProvider() {
      ServiceLocator.Register<IDisplayProvider>(this);
    }

    #region IDisplay Members

    public DisplayData GetDisplayData() {
      DisplayData data = new DisplayData();

      // Obtain the ship and copy its information
      Ship ship = Game.Ship;
      if (ship == null) {
        data.ShipData = null;
      } else {
        ShipDisplayData shipData = new ShipDisplayData();
        shipData.Exploding = false;
        shipData.Area = ship.Area;
        data.ShipData = shipData;
      }

      List<AlienDisplayData> aliens = new List<AlienDisplayData>();
      foreach (var column in Game.Aliens.Columns) {
        foreach (var alien in column.Aliens) {
          // There can be holes in the column
          if (null != alien) {
            AlienDisplayData alienData = new AlienDisplayData();
            alienData.Type = alien.Type;
            alienData.Area = alien.Area;

            aliens.Add(alienData);
          }
        }
      }

      data.AliensData = aliens;

      List<ShotDisplayData> shots = new List<ShotDisplayData>();
      foreach (var shot in Game.Shots) {
        ShotDisplayData shotData = new ShotDisplayData();
        shotData.Area = shot.Area;
        if (shot is ShotPlayer) {
          shotData.IsFromPlayer = true;
        } else {
          shotData.IsFromPlayer = false;
        }

        shots.Add(shotData);
      }

      data.ShotsData = shots;

      return data;
    }

    #endregion
  }
}
