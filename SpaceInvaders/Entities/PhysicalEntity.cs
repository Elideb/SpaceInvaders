using SpaceInvaders.Helpers;

namespace SpaceInvaders.Entities {

  internal abstract class PhysicalEntity {
    /// <summary>
    /// Position of the entity, in [0..1] coordinates.
    /// </summary>
    private Vector2 position;

    /// <summary>
    /// Get or set the position of the entity, in [0..1] coordinates.
    /// </summary>
    public Vector2 Position {
      get { return position; }
      protected set {
        position = value;

        if (position.X < this.Size.X * .5f) {
          position.X = this.Size.X * .5f;
        } else if (position.X > 1 - this.Size.X * .5f) {
          position.X = 1 - this.Size.X * .5f;
        }

        RecalculateArea();
      }
    }

    /// <summary>
    /// Ratio of the game area taken by the entity.
    /// </summary>
    private Vector2 size;

    /// <summary>
    /// Get or set the ratio of the game area taken by the entity.
    /// </summary>
    public Vector2 Size {
      get { return size; }
      set {
        size = value;
        RecalculateArea();
      }
    }

    /// <summary>
    /// Area of the screen currently taken up by the entity's vulnerable area.
    /// </summary>
    private Rectangle area = new Rectangle(Point.zero, new Vector2(.1f, .1f));

    /// <summary>
    /// Gets the area of the screen currently taken up by the entity's vulnerable area.
    /// </summary>
    public Rectangle Area {
      get { return area; }
      private set { area = value; }
    }

    public PhysicalEntity(Vector2 position, Vector2 size) {
      this.Size = size;
      this.Position = position;
    }

    private void RecalculateArea() {
      Area = new Rectangle(
            new Point(position.X - Size.X * .5f, position.Y - Size.Y * .5f),
            Size);
    }
  }
}
