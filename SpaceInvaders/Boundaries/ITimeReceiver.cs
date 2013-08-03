using SpaceInvaders.Helpers;

namespace SpaceInvaders.Boundaries {

  /// <summary>
  /// Time data received from the execution environment.
  /// </summary>
  public struct TimeData {
    /// <summary>
    /// Total execution time.
    /// </summary>
    public float Total { get; set; }
  }

  /// <summary>
  /// Interface to communicate changes in the timing.
  /// </summary>
  public interface ITimeReceiver {

    /// <summary>
    /// Update the timing information used.
    /// </summary>
    /// <param name="input"></param>
    void Update(TimeData input);
  }
}
