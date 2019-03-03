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
    class Finish : Entity
    {
        /// <summary>
        /// Constructor.
        /// Just initialize variables.
        /// </summary>
        /// <param name="texture">
        /// Image associated with the object
        /// </param>
        /// <param name="position">
        /// Location of the object on the screen
        /// </param>
        public Finish (Texture2D texture, Rectangle position) 
            : base (texture, position) {}

        /// <summary>
        /// The finish just
        /// cant be hacked....
        /// </summary>
        /// <returns
        /// False. Always false.
        /// </returns>
        public override bool CanBeHacked()
        {
            return false;
        }

        /// <summary>
        /// Just draw the texture at
        /// the position. 
        /// </summary>
        /// <param name="spriteBatch">
        /// Drawing object
        /// </param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        /// <summary>
        /// You can go over these.
        /// </summary>
        /// <returns></returns>
        public override bool IsCollidible()
        {
            return false; ;
        }

        public override void Update(GameTime gameTime)
        {
            // Pass
        }
    }
}
