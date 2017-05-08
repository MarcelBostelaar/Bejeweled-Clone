using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bejeweled_clone.Animation
{
    class StaticSprite : AbstractAnimation
    {
        public StaticSprite(Point coordinates, Texture2D sprite, Point size, GameTime gameTime, long duration, int zIndex) : base(coordinates, coordinates, sprite, size, gameTime, duration, zIndex)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (gameTime.TotalGameTime.Ticks <= CreationTime + animationTimeSpanTicks && gameTime.TotalGameTime.Ticks >= CreationTime)
            {
                spriteBatch.Draw(sprite, new Rectangle(start.X, start.Y, size.X, size.Y), Color.White);
            }
        }
    }
}
