using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTank.Source
{
    public class EntityManager
    {
        List<Entity> entities;

        public EntityManager()
        {
            entities = new List<Entity>();
        }

        public void Add(Entity ent)
        {
            entities.Add(ent);
        }

        public void Update(float dt)
        {
            foreach (Entity e in entities)
                e.Update(dt);
        }

        public void Draw()
        {
            foreach (Entity e in entities)
                e.Draw();
        }
    }
}
