using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTank.Source
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class ImageCreator
    {
        readonly float scale;
        readonly SpriteBatch batcher;
        readonly ContentManager manager;

        public ImageCreator(float scale, SpriteBatch batcher, ContentManager manager)
        {
            this.scale = scale;
            this.batcher = batcher;
            this.manager = manager;
        }

        public Image Create(String path)
        {
            return new Image(
                manager.Load<Texture2D>(path),
                scale,
                batcher
            );
        }
    }
}
