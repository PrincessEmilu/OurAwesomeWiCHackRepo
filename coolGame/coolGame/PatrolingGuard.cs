using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace coolGame
{
    class PatrolingGuard : HackableEnemy
    {
            
        // Movement

        public PatrolingGuard(Texture2D texture, Texture2D highlight, Rectangle position)
            : base(texture, highlight, position)
        {
            this.moveSpeed = 2;
            this.patrolLength = 800;
            this.currentDirection = PatrolDirection.LEFT;
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

        public override void Update(GameTime gameTime)
        {
            Move();
        }
    }
}
