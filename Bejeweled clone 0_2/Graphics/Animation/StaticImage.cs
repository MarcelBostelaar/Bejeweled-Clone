using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bejeweled_clone_0_2.Graphics.Animation
{
    class StaticImage : AbstractAnimation
    {
        Texture2D sprite;

        public StaticImage(Texture2D sprite, int zIndex, Vector2 position, Vector2 size) : base(zIndex, position, size)
        {
            this.sprite = sprite;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 parentSize)
        {
            spriteBatch.Draw(sprite, new Rectangle((position * parentSize).ToPoint(), (size * parentSize).ToPoint()), Color.White);
        }
    }
}
