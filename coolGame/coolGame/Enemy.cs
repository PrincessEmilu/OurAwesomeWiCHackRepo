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

    abstract class Enemy : Entity
    {
        public Enemy(Texture2D texture, Rectangle position, KeyboardState kbState)
            : base(texture, position, kbState) { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public abstract void Interact();
    }
}
