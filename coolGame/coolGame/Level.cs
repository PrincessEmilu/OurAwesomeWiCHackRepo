using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace coolGame
{
    class Level : GameObject
    {
        // Attributes
        List<Entity> entities;

        Player player;

        private enum EntityTypes
        {
            GuardEnemy
        }

        /// <summary>
        /// Constructs the level based on 
        /// data class Level Dat Class.
        /// </summary>
        /// <param name="player"></param>
        public Level (int levelNumber, Player player, Game1 game)
        {
            this.BuildLevel(levelNumber, game);
            this.player = player;
        }

        /// <summary>
        /// Gets the entities and background from 
        /// the dummy level dat class.
        /// </summary>
        /// <param name="levelNumber">
        /// Level number of the class to build from. 
        /// </param>
        private void BuildLevel (int levelNumber, Game1 game)
        {
            switch (levelNumber)
            {
                case (1):
                    this.entities = new Level1Dat().GetEntities(game);
                    break;
            }
        }

        /// <summary>
        ///     Draws the entities and background 
        ///     in the level.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Entity entity in this.entities)
            {
                entity.Draw(spriteBatch);
            }
        }

        /// <summary>
        ///     Updates the states of all the
        ///     entities in the level. 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            foreach (Entity entity in this.entities)
            {
                entity.Update(gameTime);
            }
        }
    }
}
