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
        // ATTRIBUTES
        private List<char> text;    // Holds the text that the terminal will display
        SpriteBatch spriteBatch;    // ???
        Rectangle wholeBox;     // the outer border of the terminal
        Rectangle textBox;      // the box in which text will be written
        Rectangle closeX;       // the box that you'll click to close the window

        public Terminal(Texture2D texture, Rectangle position, String text)
        {
            foreach (char ch in text)
            {
                this.text.Add(ch);
            }
        }

        public void LoadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the string that this terminal contains.
        /// </summary>
        public String getText()
        {
            String str = "";
            foreach(char ch in text)
            {
                str += ch;
            }
            return str;
        }
       
    }
}
