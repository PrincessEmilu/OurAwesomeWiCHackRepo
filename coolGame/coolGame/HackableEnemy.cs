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

        public HackableEnemy(Texture2D texture, Rectangle position)
        : base(texture, position) { }

        public override bool CanBeHacked ()
        {
            return true;
        }

        public override void Interact()
        {
            
        }
    }
}
