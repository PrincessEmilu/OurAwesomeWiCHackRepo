using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coolGame
{
    class Level1Dat
    {
        public List<Entity> GetEntities()
        {
            List<Entity> entities = new List<Entity>();
            entities.Add(new GuardEnemy(
                null,
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
