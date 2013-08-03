using SpaceInvaders.Helpers;

namespace SpaceInvaders.Boundaries {

  public struct InputData {
    public Direction? Direction { get; set; }
    public bool Shot { get; set; }
  }

  public interface IInputReceiver {
    void TreatInput(InputData inputData);
  }
}
