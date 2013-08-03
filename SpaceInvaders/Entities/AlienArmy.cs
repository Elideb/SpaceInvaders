using System.Collections.Generic;
using SpaceInvaders.Helpers;

namespace SpaceInvaders.Entities {

  internal class AlienArmy : PhysicalEntity, IUpdatable {

    AlienColumn[] columns;
    public IEnumerable<AlienColumn> Columns { get { return columns; } }

    Direction direction = Direction.Left;
    private Vector2 movementDistance = new Vector2(.03f, -.03f);
    private float lastMove = -5.0f;
    private float moveFrequency = 1.0f;

    public AlienArmy()
      : base(Vector2.zero, Vector2.zero) {
    }

    /// <summary>
    /// Initiliaze a new alien army.
    /// </summary>
    /// <param name="centre">Centre of the army.</param>
    /// <param name="width">Number of columns composing the army.</param>
    /// <param name="height">Number of rows in each column.</param>
    /// <param name="alienSize">Size of aliens.</param>
    /// <param name="margin">Space to leave between aliens.</param>
    public void Initialize(Vector2 centre, int width, int height, Vector2 alienSize, Vector2 margin) {
      float armyWidth = width * (alienSize.X + margin.X) - margin.X;
      float armyHeight = height * (alienSize.Y + margin.Y) - margin.Y;

      float lowestPos = centre.Y - armyHeight * .5f;
      float rightMostPos = centre.X - armyWidth * .5f;
      float leftMostPos = centre.X + armyWidth * .5f;

      columns = new AlienColumn[width];

      for (int i = 0; i < width; ++i) {
        columns[i] = new AlienColumn();
        columns[i].Initialize(
          height,
          new Vector2(rightMostPos + alienSize.X * .5f + i * (alienSize.X + margin.X), lowestPos),
          alienSize,
          margin.Y);
      }

      Position = centre;
      Size = new Vector2(
        columns[width - 1].Area.TopRight.X - columns[0].Area.TopLeft.X,
        columns[0].Area.TopLeft.Y - columns[0].Area.BottomLeft.Y);

      Game.Updatables.Add(this);
    }

    private void Move() {
      float movement = direction == Direction.Left ? movementDistance.X * -1 : movementDistance.X;

      if (Area.X + movement > 0 && Area.X + Area.Width + movement < 1) {
        Position += new Vector2(movement, 0);

        foreach (var column in columns) {
          column.Move(movement);
        }
      } else {
        Position += new Vector2(0, movementDistance.Y);
        direction = direction == Direction.Left ? Direction.Right : Direction.Left;

        foreach (var column in columns) {
          column.Descend(movementDistance.Y);
        }
      }
    }

    #region IUpdatable Members

    public void Update() {
      if (Time.Total - lastMove > moveFrequency) {
        Move();
        lastMove = Time.Total;
      }
    }

    #endregion
  }
}
