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
    class Player : Entity
    {
        //Fields
        //Current keyboard state
        KeyboardState kbState;

        public Player(Texture2D texture, Rectangle position, KeyboardState kbState)
        {
            Texture = texture;
            Position = position;

            this.kbState = kbState;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(Texture, Position, Color.White);
        }
    }
}
