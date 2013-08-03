
namespace SpaceInvaders.Helpers {

  public struct Point {
    private float x;

    public float X {
      get { return x; }
      set { x = value; }
    }

    private float y;

    public float Y {
      get { return y; }
      set { y = value; }
    }

    public Point(float _x, float _y) {
      x = _x;
      y = _y;
    }

    public static readonly Point zero = new Point(0, 0);
  }
}
