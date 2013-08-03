
namespace SpaceInvaders.Helpers {

  public struct Vector2 {
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

    public Vector2(float _x, float _y) {
      x = _x;
      y = _y;
    }

    public static readonly Vector2 zero = new Vector2(0, 0);
    public static readonly Vector2 one = new Vector2(1, 1);

    public static Vector2 operator -(Vector2 v) {
      return new Vector2(-v.X, -v.Y);
    }

    public static Vector2 operator +(Vector2 v1, Vector2 v2) {
      return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
    }

    public static Vector2 operator -(Vector2 v1, Vector2 v2) {
      return new Vector2(v2.X - v1.X, v2.Y - v1.Y);
    }

    public static Vector2 operator *(Vector2 v, float f) {
      return new Vector2(v.X * f, v.Y * f);
    }

    public static Vector2 operator /(Vector2 v, float f) {
      return new Vector2(v.X / f, v.Y / f);
    }
  }
}
