using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace coolGame
{
    static class Helpers
    {
        public static bool CheckSingleKeyPress (Keys keys, KeyboardState kbState, KeyboardState pbState)
        {
            return kbState.IsKeyDown(keys) && pbState.IsKeyUp(keys);
        }

        // TODO: Further Static methods.

            /// <summary>
            /// Is the mouse hovering over a certain rextangle?
            /// <returns></returns>
        public static bool isHovering(int x, int y, int width, int height)
        {
            return (Mouse.GetState().X >= x && Mouse.GetState().X <= (x + width) &&
                Mouse.GetState().Y >= y && Mouse.GetState().Y <= (y + height));
        }
    }
}
