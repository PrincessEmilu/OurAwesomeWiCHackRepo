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

        public PatrolingGuard(Texture2D texture, Rectangle position)
            : base(texture, position)
        {
            this.moveSpeed = 2;
            this.patrolLength = 800;
            this.currentDirection = PatrolDirection.LEFT;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            Move();
        }
    }
}
