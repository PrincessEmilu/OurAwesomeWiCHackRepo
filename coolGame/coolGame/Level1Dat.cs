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
    class Level1Dat
    {
        public List<Entity> GetEntities(Game1 game)
        {
            List<Entity> entities = new List<Entity>();
            entities.Add(new GuardEnemy(
                game.GetEnemy(),
                new Rectangle(10, 10, 100, 100),
                game.GetPlayer()));
            return entities;
        }

        public string GetBackground()
        {
            return null;
        }
    }
}
