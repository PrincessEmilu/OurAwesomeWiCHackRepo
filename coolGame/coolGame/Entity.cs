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
        //All entities need a texture and a rectangle
        protected Texture2D texture;
        protected Rectangle position;

        public Entity (Texture2D texture, Rectangle position, KeyboardState kbState)
        : base(texture, position, kbState) { }   
    }
}
