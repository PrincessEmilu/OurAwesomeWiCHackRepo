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
        public PatrolingGuard(Texture2D texture, Rectangle position)
            : base(texture, position) { }

        // Movement
        const int moveSpeed = 5;
        const int patrolLength = 200;
        bool patrolDirection = true;

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (patrolDirection)
            {
                position.X += moveSpeed;
            }
            else
            {

            }
        }
    }
}
