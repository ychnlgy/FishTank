using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTank.Source
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Diagnostics;

    public class Image
    {

        Texture2D tex;
        float scale;
        Vector2 localHeadPos;
        SpriteBatch batcher;

        public Image(
            Texture2D tex,
            float scale,
            SpriteBatch batcher
        )
        {
            Init(tex, scale, new Vector2(0), batcher);
        }

        public Image(
            Texture2D tex,
            float scale,
            Vector2 localHeadPos,
            SpriteBatch batcher
        )
        {
            Init(tex, scale, localHeadPos, batcher);
        }

        public void Draw(Vector2 pos, bool flip, float rotation)
        {
            Rectangle rect = flip ? GetFlippedRectangle(pos) : GetRectangle(pos);
            SpriteEffects flipEff = flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            batcher.Draw(tex, rect, null, Color.White, rotation, new Vector2(0), flipEff, 0f);
        }

        public Rectangle GetBaseRectangle()
        {
            int w = (int)(tex.Width * scale);
            int h = (int)(tex.Height * scale);
            int x = (int)(-localHeadPos.X * scale);
            int y = (int)(-localHeadPos.Y * scale);
            return new Rectangle(x, y, w, h);
        }

        // === PRIVATE ===

        private void Init(
            Texture2D tex,
            float scale,
            Vector2 localHeadPos,
            SpriteBatch batcher
        )
        {
            this.tex = tex;
            this.scale = scale;
            this.localHeadPos = localHeadPos;
            this.batcher = batcher;
        }

        private Rectangle GetRectangle(Vector2 pos)
        {
            Rectangle baseRect = GetBaseRectangle();
            return new Rectangle(
                (int) (pos.X + baseRect.X),
                (int) (pos.Y + baseRect.Y),
                baseRect.Width,
                baseRect.Height
            );
        }

        private Rectangle GetFlippedRectangle(Vector2 pos)
        {
            Rectangle baseRect = GetBaseRectangle();
            return new Rectangle(
                (int)(pos.X - baseRect.X - baseRect.Width),
                (int)(pos.Y - baseRect.Y - baseRect.Height),
                baseRect.Width,
                baseRect.Height
            );
        }

        
    }
}
