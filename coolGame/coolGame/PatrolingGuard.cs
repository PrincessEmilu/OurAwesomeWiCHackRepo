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
        const int moveSpeed = 5;
        const int patrolLength = 200;
        int amountMoved;
        bool patrolDirection = true;

        public PatrolingGuard(Texture2D texture, Rectangle position)
            : base(texture, position) { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (patrolDirection)
            {
                position.X += moveSpeed;
                amountMoved += moveSpeed;
            }
            else
            {
                position.X -= moveSpeed;
                amountMoved -= moveSpeed;
            }
            if (amountMoved == 0 || 
                amountMoved == patrolLength)
            {
                patrolDirection = !patrolDirection;
            }
        }
    }
}
