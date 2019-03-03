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
        Entity hackee;
        List<char> code;
        char holder;
        int cursorIndex;

        public Terminal (Texture2D view, Entity hackee)
        {
            this.view = view;
            this.hackee = hackee;
            this.code = new List<char>(hackee.starterCode.ToCharArray());
            this.cursorIndex = 0;
            this.holder = code.ElementAt(cursorIndex);
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

        public void MoveDownLine ()
        {
            int searcherIndex = this.cursorIndex;
            int counter = 0;
            char charAt = this.code.ElementAt(searcherIndex);
            // Search backward for last newline or the begginning
            while (charAt != '\n' && searcherIndex > 0)
            {
                searcherIndex--;
                counter++;
                charAt = this.code.ElementAt(searcherIndex);
            }
            // Reset
            searcherIndex = this.cursorIndex;
            charAt = this.code.ElementAt(searcherIndex);
            // Search forward for newline
            while (charAt != '\n' && searcherIndex <= this.code.Count)
            {
                searcherIndex++;
                charAt = this.code.ElementAt(searcherIndex);
            }
            // Search forward for the next line, but make sure that
            // you don't go past end of the list or hit a newline. 
            while (charAt != '\n' && searcherIndex <= this.code.Count && counter > 0)
            {
                searcherIndex++;
                counter--;
                charAt = this.code.ElementAt(searcherIndex);
            }
            this.cursorIndex = searcherIndex;
        }

        public void MoveUpLine()
        {
            int searcherIndex = this.cursorIndex;
            int counter = 0;
            char charAt = this.code.ElementAt(searcherIndex);
            // Search backward for last newline or the begginning
            while (charAt != '\n' && searcherIndex > 0)
            {
                searcherIndex--;
                counter++;
                charAt = this.code.ElementAt(searcherIndex);
            }
            if (searcherIndex == 0)
            {
                this.cursorIndex = searcherIndex;
                return;
            }
            // Reset
            searcherIndex = this.cursorIndex;
            charAt = this.code.ElementAt(searcherIndex);
            // Search forward for newline
            while (charAt != '\n' && searcherIndex <= this.code.Count)
            {
                searcherIndex++;
                charAt = this.code.ElementAt(searcherIndex);
            }
            // Search forward for the next line, but make sure that
            // you don't go past end of the list or hit a newline. 
            while (charAt != '\n' && searcherIndex <= this.code.Count && counter > 0)
            {
                searcherIndex++;
                counter--;
                charAt = this.code.ElementAt(searcherIndex);
            }
            this.cursorIndex = searcherIndex;
        }

        public void MoveCursor ()
        {
            
        }
    }
}
