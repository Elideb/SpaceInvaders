using SpaceInvaders.Helpers;

namespace SpaceInvaders.Entities {

  internal class ShotPlayer : Shot {

    public ShotPlayer()
      : base(Game.Ship.Position, new Vector2(.005f, .03f), new Vector2(.0f, .2f)) {
    }

    public override void Update() {
      base.Update();

      // Check if it collides with an enemy.
      AlienArmy army = Game.Aliens;
      if (this.Area.Intersects(army.Area) || army.Area.Intersects(this.Area)) {
        foreach (var column in army.Columns) {
          if (this.Area.Intersects(column.Area) || column.Area.Intersects(this.Area)) {
            foreach (var alien in column.Aliens) {
              if (this.Area.Intersects(alien.Area) || alien.Area.Intersects(this.Area)) {
                alien.Destroy();
                this.Destroy();
              }
            }

            break;
          }
        }
      }
    }
  }
}
