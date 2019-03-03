using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace coolGame
{
    class GuardEnemy : HackableEnemy
    {
        public GuardEnemy(Texture2D texture, Rectangle position)
            :base(texture, position)
        {

        }

        //Hacking
        public override void Interact()
        {
            base.Interact();
        }

        //Updating and Drawing
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }
}
