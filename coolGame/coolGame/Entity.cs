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
    abstract class Entity : GameObject
    {
        public Entity (Texture2D texture, Rectangle position, KeyboardState kbState)
        {
            this.texture = texture;
            this.position = position;
        }
        
        //All entities need a texture and a rectangle
        protected Texture2D texture;
        protected Rectangle position;
    }
}
