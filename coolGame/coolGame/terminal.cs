using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace coolGame
{
    class Terminal : GameObject
    {

        //Attributes
        Texture2D view;
        string code;
        Entity hackee;
    

        public Terminal (Texture2D view, Entity hackee)
        {
            this.view = view;
            this.hackee = hackee;
            this.code = hackee.starterCode;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.view,
                new Rectangle(
                    0,
                    0,
                    this.view.Width,
                    this.view.Width),
                Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
