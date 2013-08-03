using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Helpers {

  static class MathHelpers {
    /// <summary>
    /// Clamp <code>value</code> to the range <code>[min..max]</code>.
    /// </summary>
    /// <param name="value">Value to clamp.</param>
    /// <param name="min">Minimum value to return.</param>
    /// <param name="max">Maximum value to return.</param>
    /// <returns>The result of clamping <code>value</code> in the range <code>[min..max]</code>.</returns>
    public static float Clamp(float value, float min, float max) {
      if (value < min) {
        return min;
      }

      if (value > max) {
        return max;
      }

      return value;
    }
  }
}
