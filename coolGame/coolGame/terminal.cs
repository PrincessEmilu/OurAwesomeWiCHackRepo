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
        List<string> code;

        public Terminal (Texture2D view, List<string> code)
        {
            this.view = view;
            this.code = code;
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
