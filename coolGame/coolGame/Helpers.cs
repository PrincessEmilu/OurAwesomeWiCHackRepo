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
            return kbState.IsKeyDown(keys) && pbState.IsKeyDown(keys;
        }

        // TODO: Further Static methods.

    }
}
