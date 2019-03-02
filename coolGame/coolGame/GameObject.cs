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
    abstract class GameObject
    {
        //Must implement abstract and draw
        abstract protected void Update(GameTime gameTime);
        abstract protected void Draw(SpriteBatch spriteBatch);
    }
}
