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
        public Enemy(Texture2D texture, Texture2D highlight, Rectangle position)
            : base(texture, highlight, position) { }

        public override void Update(GameTime gameTime)
        {}

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        /// <summary>
        /// All the enemies are collidible
        /// </summary>
        /// <returns></returns>
        public override bool IsCollidible()
        {
            return true;
        }

        public abstract void Interact();
    }
}
