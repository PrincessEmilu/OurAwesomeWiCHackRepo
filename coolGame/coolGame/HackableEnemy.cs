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

        public HackableEnemy(Texture2D texture, Rectangle position)
        : base(texture, position) { }

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
            spriteBatch.Draw(texture, position, null, Color.LightBlue, 0, new Vector2(0, 0), drawEffect, 0);
        }
    }
}
