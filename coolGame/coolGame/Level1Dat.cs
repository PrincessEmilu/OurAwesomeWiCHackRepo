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
        public List<Entity> GetEntities(Game game)
        {
            List<Entity> entities = new List<Entity>();
            entities.Add(new GuardEnemy(
                Content.Load<Texture2D>("enemy"),
                new Microsoft.Xna.Framework.Rectangle(10, 10, 100, 100),
                null));
            return entities;
        }

        public string GetBackground()
        {
            return null;
        }
    }
}
