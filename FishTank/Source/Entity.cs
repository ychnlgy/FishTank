using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTank.Source
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Entity
    {
        Image img;
        protected Vector2 pos;
        protected bool flip;
        protected float rotation;

        public Entity(Image img)
        {
            Init(img, new Vector2(0), false);
        }

        public Entity(Image img, Vector2 pos, bool flip)
        {
            Init(img, pos, flip);
        }

        public void Update(float dt)
        {

        }

        public void Draw()
        {
            img.Draw(pos, flip, rotation);
        }

        private void Init(Image img, Vector2 pos, bool flip)
        {
            this.img = img;
            this.pos = pos;
            this.flip = flip;
        }
    }
}
