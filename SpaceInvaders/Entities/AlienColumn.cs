using System.Collections.Generic;
using SpaceInvaders.Helpers;

namespace SpaceInvaders.Entities {

  internal class AlienColumn : PhysicalEntity {

    private List<Alien> aliens;
    public IEnumerable<Alien> Aliens { get { return aliens; } }

    private Alien firstAlien = null;

    public Alien FirstAlien {
      get { return firstAlien; }
      private set { firstAlien = value; }
    }

    private Alien lastAlien;

    public Alien LastAlien {
      get { return lastAlien; }
      private set { lastAlien = value; }
    }


    public AlienColumn()
      : base(Vector2.zero, Vector2.zero) {
    }

    public void Initialize(int height, Vector2 firstPos, Vector2 alienSize, float margin) {
      aliens = new List<Alien>(height);
      for (int i = 0; i < height; ++i) {
        AlienType type;
        switch (height) {
        case 0:
        case 1:
          type = AlienType.Crab;
          break;
        case 2:
        case 3:
          type = AlienType.Ant;
          break;
        default:
          type = AlienType.Squid;
          break;
        }

        aliens.Add( new Alien(this, type, new Vector2(firstPos.X, firstPos.Y + i * (alienSize.Y + margin)), alienSize) );
      }

      FirstAlien = aliens[0];
      LastAlien = aliens[height - 1];

      UpdateDimensions();
    }

    /// <summary>
    /// Move the whole column one step in the given direction.
    /// If the column exits its movement range, it moves down.
    /// </summary>
    /// <param name="x">Horizontal distance to move, if possible.</param>
    public void Move(float x) {
      Vector2 delta = new Vector2(x, 0);
      Position += delta;

      foreach (var alien in aliens) {
        alien.Move(delta);
      }
    }

    /// <summary>
    /// Move the whole column on space lower.
    /// </summary>
    /// <param name="y">Vertical distance to descend.</param>
    public void Descend(float y) {
      Vector2 delta = new Vector2(0, y);
      Position += delta;

      foreach (var alien in aliens) {
        alien.Move(delta);
      }
    }

    public void RemoveAlien(Alien alien) {
      aliens.Remove(alien);

      if (alien == FirstAlien || alien == LastAlien) {
        if (aliens.Count == 0) {
          FirstAlien = null;
          LastAlien = null;
        } else {
          FirstAlien = aliens[0];
          LastAlien = aliens[aliens.Count - 1];
        }

        UpdateDimensions();
      }
    }

    private void UpdateDimensions() {
      if(null == FirstAlien && null == LastAlien) {
        Size = Vector2.zero;
        return;
      }

      Size = new Vector2(FirstAlien.Size.X, LastAlien.Area.TopRight.Y - FirstAlien.Area.BottomRight.Y);
      Position = new Vector2(FirstAlien.Position.X, FirstAlien.Position.Y + Size.Y * .5f);
    }
  }
}
