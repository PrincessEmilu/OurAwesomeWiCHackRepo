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
    class HackableEnempy : Enemy
    {

        public HackableEnempy(Texture2D texture, Rectangle position, KeyboardState kbState)
        : base(texture, position, kbState) { }

        private bool hasBeenHacked;

        public override void Interact()
        {
            
        }
    }
}
