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

        private enum EntityTypes
        {
            GuardEnemy
        }

        /// <summary>
        /// Constructor that builds a level
        /// from a file.
        /// </summary>
        /// <param name="file">
        ///     File location for the level information.
        /// </param>
        public Level (String file, Player player)
        {
            this.entities = new List<Entity>();
            this.BuildLevel(file);
        }

        /// <summary>
        ///     Builds the level from the file.
        /// </summary>
        /// <param name="file"></param>
        private void BuildLevel (String file)
        {
            TextReader fileIn = new StreamReader(
                new BufferedStream( 
                    new FileStream ( file, FileMode.Open, FileAccess.Read)), 
                Encoding.UTF8);
            String line = fileIn.ReadLine();
            while (line != null)
            {
                if (line.Equals("") || line.StartsWith("#"))
                {
                    continue;
                }

                // Make Entity
                String[] contents = line.Split(',');
                // Note default size of enemies is 100. Change later. 
                switch (contents[2])
                {
                    case "GuardEnemy":
                        this.entities.Add(new GuardEnemy(
                            null, new Rectangle( 
                                Int32.Parse(contents[0]), 
                                Int32.Parse(contents[1]), 
                                100,
                                100)),
                                player);
                        break;
                }
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
