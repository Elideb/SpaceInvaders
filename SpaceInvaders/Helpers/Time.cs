
namespace SpaceInvaders.Helpers {

  internal static class Time {
    private static float total = 0;

    /// <summary>
    /// Total execution time.
    /// </summary>
    public static float Total {
      get {
        return Time.total;
      }
      set {
        Elapsed = value - Time.total;
        Time.total = value;
      }
    }

    private static float elapsed = 0;

    /// <summary>
    /// Update the time since the previous update call.
    /// </summary>
    public static float Elapsed {
      get { return Time.elapsed; }
      private set { elapsed = value; }
    }
  }
}
