﻿using System;
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

        //Movement
        const int moveSpeed = 5;

        public Player(Texture2D texture, Rectangle position, KeyboardState kbState)
        {
            this.texture = texture;
            this.position = position;
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
            }

            //Left
            if (kbState.IsKeyDown(Keys.A))
            {
                position.X -= moveSpeed;
            }

            //Up
            if (kbState.IsKeyDown(Keys.W))
            {
                position.Y -= moveSpeed;
            }

            //Down
            if (kbState.IsKeyDown(Keys.S))
            {
                position.Y += moveSpeed;
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, Color.White);
        }
    }
}