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

        // Code Information
        protected string starterCode;
        protected string acceptableCode;

        public Entity (Texture2D texture, Rectangle position)
        {
            this.texture = texture;
            this.position = position;
            this.moveSpeed = 0;
        }

        abstract public bool CanBeHacked();

        abstract public bool IsCollidible();

        /// <summary>
        /// Calculates the future position
        /// that an entity would take up after 
        /// it moves. 
        /// </summary>
        /// <returns>
        /// A new rectangle object
        /// to test a given position against. 
        /// </returns>
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

        /// <summary>
        /// Method that allows another class
        /// to see what direction this will move in
        /// not just if there will be an intersection.
        /// </summary>
        /// <returns>
        /// A list with two objects:   
        /// 1) a character denoting the next
        /// direction (Y for vertical and X for 
        /// horizontal with capital / lowercase
        /// for negative / positive).
        /// 2) the distance to be moved. 
        /// </returns>
        public List<Object> GetNextMovement ()
        {
            List<Object> returnVal = new List<object>();
            switch (this.currentDirection)
            {
                case (PatrolDirection.UP):
                    returnVal.Add('Y');
                    break;
                case (PatrolDirection.DOWN):
                    returnVal.Add('y');
                    break;
                case (PatrolDirection.LEFT):
                    returnVal.Add('X');
                    break;
                case (PatrolDirection.RIGHT):
                    returnVal.Add('x');
                    break;
            }
            returnVal.Add(this.moveSpeed);
            return returnVal;
        }

        /// <summary>
        /// Helper method that flips the direction 
        /// of the patrol in the enum
        /// </summary>
        /// <param name="initial">
        /// Initial direction
        /// </param>
        /// <returns>d
        /// Direction opposite
        /// </returns>
        protected PatrolDirection FlipDirection (PatrolDirection initial)
        {
            switch (initial)
            {
                case (PatrolDirection.UP):
                    return PatrolDirection.DOWN;
                case (PatrolDirection.DOWN):
                    return PatrolDirection.UP;
                case (PatrolDirection.LEFT):
                    return PatrolDirection.RIGHT;
                case (PatrolDirection.RIGHT):
                    return PatrolDirection.LEFT;
            }
            return initial;
        }

        /// <summary>
        /// Method to move an entity on update.
        /// </summary>
        protected void Move ()
        {
            switch (this.currentDirection)
            {
                case (PatrolDirection.UP):
                    this.position.Y += this.moveSpeed;
                    this.amountMoved += this.moveSpeed;
                    break;
                case (PatrolDirection.DOWN):
                    this.position.Y -= this.moveSpeed;
                    this.amountMoved -= this.moveSpeed;
                    break;
                case (PatrolDirection.LEFT):
                    this.position.X += this.moveSpeed;
                    this.amountMoved += this.moveSpeed;
                    break;
                case (PatrolDirection.RIGHT):
                    this.position.X -= this.moveSpeed;
                    this.amountMoved -= this.moveSpeed;
                    break;
            }
            if (this.amountMoved == 0 || 
                this.amountMoved == this.patrolLength)
            {
                this.currentDirection = FlipDirection(this.currentDirection);
            }
        }
    }
}
