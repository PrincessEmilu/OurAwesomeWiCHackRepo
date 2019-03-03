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
    class Player : Entity
    {
        //Fields
        List<Entity> listEntities;

        //Movement
        const int moveSpeed = 6;

        //Properties for checking player's position
        public int X
        {
            get { return position.X; }
        }
        public int Y
        {
            get { return position.Y; }
        }

        public Player(Texture2D texture, Rectangle position, List<Entity> list) 
            : base(texture, position)
        {
            //Reference to list of entities
            listEntities = list;
        }

        public override void Update(GameTime gameTime)
        {
            //
            //Movement
            //
            KeyboardState kbState = Keyboard.GetState();

            //Right
            if (kbState.IsKeyDown(Keys.D))
            {
                position.X += moveSpeed;

                //Stop player from walking into collidable object
                if (CheckCollision())
                {
                    position.X -= 1;
                }
            }

            //Left
            if (kbState.IsKeyDown(Keys.A))
            {
                position.X -= moveSpeed;

                //Stop player from walking into collidable object
                if (CheckCollision())
                {
                    position.X += 1;
                }
            }

            //Up
            if (kbState.IsKeyDown(Keys.W))
            {
                position.Y -= moveSpeed;

                //Stop player from walking into collidable object
                if (CheckCollision())
                {
                    position.Y += 1;
                }
            }

            //Down
            if (kbState.IsKeyDown(Keys.S))
            {
                position.Y += moveSpeed;

                //Stop player from walking into collidable object
                if (CheckCollision())
                {
                    position.Y -= 1;
                }
            }
        }

        //Checks for collision
        public bool CheckCollision()
        {
            //Loops through list; checks collision
            foreach(Entity e in listEntities)
            {
                if (e.Position.Intersects(position))
                {
                    return true;
                }
            }
            return false;
        }
        //Drawing the player
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, Color.White);
        }
    }
}
