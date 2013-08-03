using SpaceInvaders.Entities;

namespace SpaceInvaders.Boundaries {

  internal class InputReceiver : IInputReceiver {

    public InputReceiver() {
      ServiceLocator.Register<IInputReceiver>(this);
    }

    #region IInputReceiver Members

    public void TreatInput(InputData inputData) {
      if (inputData.Direction.HasValue) {
        Game.ShipMove.Execute(inputData.Direction.Value);
      }

      if (inputData.Shot) {
        Game.ShipShoot.Execute();
      }
    }

    #endregion
  }
}
