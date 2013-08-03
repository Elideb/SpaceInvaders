
namespace SpaceInvaders.Helpers {

  /// <summary>
  /// Structure representing a Axis Aligned Bounding Box (AABB).
  /// </summary>
  public struct Rectangle {

    private float x;

    /// <summary>
    /// Origin X coordinate of the AABB, starting at the left.
    /// </summary>
    public float X {
      get { return x; }
      set { x = value; }
    }

    private float y;

    /// <summary>
    /// Origin Y coordinate of the AABB, starting at the top.
    /// </summary>
    public float Y {
      get { return y; }
      set { y = value; }
    }

    private float width;

    /// <summary>
    /// Width of the AABB.
    /// </summary>
    public float Width {
      get { return width; }
      set { width = Width; }
    }

    private float height;

    /// <summary>
    /// Height of the AABB.
    /// </summary>
    public float Height {
      get { return height; }
      set { height = value; }
    }

    public Point TopLeft {
      get { return new Point(X, Y + Height); }
    }

    public Point TopRight {
      get { return new Point(X + Width, Y + Height); }
    }

    public Point BottomLeft {
      get { return new Point(X, Y); }
    }

    public Point BottomRight {
      get { return new Point(X + Width, Y); }
    }

    public Rectangle(Point bottomLeft, Vector2 size) {
      x = bottomLeft.X;
      y = bottomLeft.Y;
      width = size.X;
      height = size.Y;
    }

    public Rectangle(Point topLeft, Point bottomRight) {
      x = topLeft.X;
      y = bottomRight.Y;
      width = bottomRight.X - x;
      height = topLeft.Y - y;
    }

    public bool Contains(float x, float y) {
      return this.Contains(new Point(x, y));
    }

    public bool Contains(Point point) {
      return this.X < point.X
          && point.X < this.X + this.Width
          && this.Y < point.Y
          && point.Y < this.Y + this.Height;
    }

    public bool Contains(Vector2 point) {
      return this.X < point.X
          && point.X < this.X + this.Width
          && this.Y < point.Y
          && point.Y < this.Y + this.Height;
    }

    public bool Contains(Rectangle rect) {
      return this.Contains(rect.TopLeft)
          && this.Contains(rect.TopRight)
          && this.Contains(rect.BottomLeft)
          && this.Contains(rect.BottomRight);
    }

    public bool Intersects(Rectangle rect) {
      return this.Contains(rect.TopLeft)
          || this.Contains(rect.TopRight)
          || this.Contains(rect.BottomLeft)
          || this.Contains(rect.BottomRight);
    }

  }
}
