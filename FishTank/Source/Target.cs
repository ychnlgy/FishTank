using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTank.Source
{

    using Microsoft.Xna.Framework;

    public class Target
    {
        public Vector2 pos;
        public readonly bool urgent;

        public Target(Vector2 pos, bool urgent)
        {
            this.pos = pos;
            this.urgent = urgent;
        }


    }
}
