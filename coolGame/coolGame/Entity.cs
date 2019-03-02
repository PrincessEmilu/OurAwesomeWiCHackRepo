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
        public Texture2D Texture { get; protected set; }
        public Rectangle Position { get; protected set; }
    }
}
