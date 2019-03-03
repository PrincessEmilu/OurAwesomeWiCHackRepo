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
    class HackableEnemy : Enemy
    {
        //Fields
        //Draw effect
        protected SpriteEffects drawEffect = SpriteEffects.None;

        public HackableEnemy(Texture2D texture, Texture2D highlight, Rectangle position)
        : base(texture, highlight, position) { }

        public override bool CanBeHacked ()
        {
            return true;
        }

        public override void Interact(){}

        public bool AcceptHack (string altered)
        {
            return altered.Equals(this.acceptableCode);
        }

        public void DrawHack(SpriteBatch spriteBatch)
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
