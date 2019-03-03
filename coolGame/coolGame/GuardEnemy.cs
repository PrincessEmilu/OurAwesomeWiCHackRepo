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

        //Reference to player
        Player player;

        public GuardEnemy(Texture2D texture, Texture2D textureHighlight, Rectangle position, Player player)
            :base(texture, textureHighlight, position)
        {
            this.player = player;
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

            //Changes draw effect- enemy faces direction of player
            if (player.X < position.X)
            {
                drawEffect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                drawEffect = SpriteEffects.None;
            }

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Helpers.IsHovering(position.Left, position.Top, position.Width, position.Height))
            {
                spriteBatch.Draw(highlight, position, null, Color.White, 0, new Vector2(0, 0), drawEffect, 0);
            }
            else
            {
                spriteBatch.Draw(texture, position, null, Color.White, 0, new Vector2(0, 0), drawEffect, 0);
            }
        }

    }
}
