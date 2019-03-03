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

        private enum Direction
        {
            LEFT,
            RIGHT
        }

        // Movement & Direction
        const int moveSpeed = 6;
        private Direction direction;
        SpriteEffects spriteEffect = SpriteEffects.None;
        Direction lastDirection;

        // Properties for checking player's position
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
            // Reference to list of entities
            listEntities = list;
            this.direction = Direction.RIGHT;
        }

        public override void Update(GameTime gameTime)
        {
            //
            // Movement
            //
            KeyboardState kbState = Keyboard.GetState();

            // Right
            if (kbState.IsKeyDown(Keys.D) || kbState.IsKeyDown(Keys.Right))
            {
                direction = Direction.RIGHT;
                spriteEffect = SpriteEffects.None;
                position.X += moveSpeed;

                // Stop player from walking into collidable object
                if (CheckCollision())
                {
                    position.X -= moveSpeed;
                }
            }

            // Left
            if (kbState.IsKeyDown(Keys.A) || kbState.IsKeyDown(Keys.Left))
            {
                direction = Direction.LEFT;
                spriteEffect = SpriteEffects.FlipHorizontally;
                position.X -= moveSpeed;

                // Stop player from walking into collidable object
                if (CheckCollision())
                {
                    position.X += moveSpeed;
                }
            }

            // Up
            if (kbState.IsKeyDown(Keys.W) || kbState.IsKeyDown(Keys.Up))
            {
                position.Y -= moveSpeed;

                // Stop player from walking into collidable object
                if (CheckCollision())
                {
                    position.Y += moveSpeed;
                }
            }

            // Down
            if (kbState.IsKeyDown(Keys.S) || kbState.IsKeyDown(Keys.Down))
            {
                position.Y += moveSpeed;

                //Stop player from walking into collidable object
                if (CheckCollision())
                {
                    position.Y -= moveSpeed;
                }   
            }
            CheckFutureCollision();
        }

        // Checks for collision
        public bool CheckCollision()
        {
            // Loops through list; checks collision
            foreach(Entity e in listEntities)
            {
                if (e.Position.Intersects(position))
                {
                    return true;
                }
            }
            return false;
        }

        public void CheckFutureCollision ()
        {
            bool flag = false;
            foreach (Entity entity in listEntities)
            {
                if (entity.GetFuturePosition().Intersects(this.position))
                {
                    List<Object> nextMove = entity.GetNextMovement();
                    int movement = (int)nextMove.ElementAt(1);
                    switch ((char) nextMove.ElementAt(0))
                    {
                        case ('X'):
                            this.position.X += movement;
                            break;
                        case ('x'):
                            this.position.X -= movement;
                            break;
                        case ('Y'):
                            this.position.Y += movement;
                            break;
                        case ('y'):
                            this.position.Y -= movement;
                            break;
                    }
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                if (CheckCollision())
                {
                    throw new DivideByZeroException();
                }
            }
        }

        // Drawing the player
        public override void Draw(SpriteBatch sb)
        {
            
            if (direction == Direction.LEFT)
            {
                sb.Draw(texture, position, null, Color.White, 0, new Vector2(0, 0), spriteEffect, 0);
            }
            else
            {
                sb.Draw(texture, position, null, Color.White, 0, new Vector2(0, 0), spriteEffect, 0);
            }
            
        }

        // The player can't be hacked
        public override bool CanBeHacked()
        {
            return false;
        }

    }
}
