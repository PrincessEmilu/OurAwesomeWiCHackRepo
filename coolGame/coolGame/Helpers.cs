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
        static string CONTENT_TITLE = "title";
        static string CONTENT_PRESS_ENTER = "pressEnterToPlay";
        static string CONTENT_PRESS_ENTER_HIGHLIGHT = "pressEnterToPlayHighlighted";
        static string CONTENT_RABBIT = "rabbit";
        static string CONTENT_CARROT = "carrot";
        static string CONTENT_ENEMY = "enemy";
        static string CONTENT_LEVEL1 = "level1";
        static string CONTENT_LEVEL1_HIGHLIGHT = "level1Highlighted";
        static string CONTENT_ARROW = "arrow";

        public static MouseState mouseState;
        public static MouseState lastMouseState;
        public enum MousePressState
        {
            NONE,       // nothing
            PRESS,      // pressed
            HOLD,       // holding
            RELEASE     // released
        }

        public static bool CheckSingleKeyPress (Keys keys, KeyboardState kbState, KeyboardState pbState)
        {
            return kbState.IsKeyDown(keys) && pbState.IsKeyUp(keys);
        }

        /// <summary>
        /// Is the mouse hovering over a certain rextangle?
        /// <returns></returns>
        public static bool IsHovering(int x, int y, int width, int height)
        {
            return (Mouse.GetState().X >= x && Mouse.GetState().X <= (x + width) &&
                Mouse.GetState().Y >= y && Mouse.GetState().Y <= (y + height));
        }

        /// <summary>
        /// This function is used so that the user can't just hold down the mouse and play the whole game.
        /// They have to click multiple things.
        /// </summary>
        public static MousePressState GetLeftMousePressState()
        {
            if (mouseState.LeftButton == ButtonState.Released && 
                lastMouseState.LeftButton == ButtonState.Released) return MousePressState.NONE;
            if (mouseState.LeftButton == ButtonState.Pressed &&
                lastMouseState.LeftButton == ButtonState.Released) return MousePressState.PRESS;
            if (mouseState.LeftButton == ButtonState.Pressed &&
                lastMouseState.LeftButton == ButtonState.Pressed) return MousePressState.HOLD;
            if (mouseState.LeftButton == ButtonState.Released &&
                lastMouseState.LeftButton == ButtonState.Pressed) return MousePressState.RELEASE;
            return MousePressState.NONE;
        }

        public static bool CheckHackSingle(Entity entity)
        {
            Rectangle pos = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);
            return entity.Position.Intersects(pos);
        }

        public static bool CheckHack (List<Entity> entities)
        {
            foreach (Entity entity in entities)
            {
                if (CheckHackSingle(entity))
                {
                    return entity.CanBeHacked();
                }
            }
            return false;
        }

    }
}
