using SpaceInvaders.Entities;
using SpaceInvaders.Helpers;

namespace SpaceInvaders.Boundaries {

  internal class TimeReceiver : ITimeReceiver {

    public TimeReceiver() {
      ServiceLocator.Register<ITimeReceiver>(this);
    }

    #region ITiming Members

    public void Update(TimeData input) {
      Time.Total = input.Total;

      foreach (var updatable in Game.Updatables) {
        updatable.Update();
      }

      // Cleanup after frame execution.
      foreach (var cleanable in Game.Cleanables) {
        cleanable.Clean();
      }

      Game.Cleanables.Clear();
    }

    #endregion
  }
}
