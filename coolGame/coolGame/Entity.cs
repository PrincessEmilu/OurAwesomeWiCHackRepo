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

        //Can check entitiy positon
        public Rectangle Position { get { return position; } }

        //All entities need a texture and a rectangle
        protected Texture2D texture;
        protected Rectangle position;

        // Movement information
        protected int moveSpeed;
        protected int patrolLength;
        protected int amountMoved;
        protected enum PatrolDirection
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }
        protected PatrolDirection currentDirection;

        public Entity (Texture2D texture, Rectangle position)
        {
            this.texture = texture;
            this.position = position;
            this.moveSpeed = 0;
        }

        abstract public bool CanBeHacked();

        public Rectangle GetFuturePosition ()
        {
            switch (currentDirection)
            {
                case (PatrolDirection.UP):
                    return new Rectangle(this.position.X, 
                        this.position.Y + this.moveSpeed,
                        this.texture.Width, 
                        this.texture.Height);
                case (PatrolDirection.DOWN):
                    return new Rectangle(this.position.X,
                        this.position.Y - this.moveSpeed,
                        this.texture.Width,
                        this.texture.Height);
                case (PatrolDirection.LEFT):
                    return new Rectangle(this.position.X + this.moveSpeed,
                        this.position.Y,
                        this.texture.Width,
                        this.texture.Height);
                case (PatrolDirection.RIGHT):
                    return new Rectangle(this.position.X - this.moveSpeed,
                        this.position.Y,
                        this.texture.Width,
                        this.texture.Height);
            }
            return new Rectangle(this.position.X,
                this.position.Y,
                this.texture.Width,
                this.texture.Height);
        }
    }
}
