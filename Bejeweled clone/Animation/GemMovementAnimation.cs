using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bejeweled_clone.Animation
{
    class GemMovementAnimation : AbstractAnimation
    {
        public static long duration { get { return 2000000; } }
        public GemMovementAnimation(Point startPosition, Point endPosition, Texture2D sprite, Point size, GameTime gametime) : base(startPosition, endPosition, sprite, size, gametime, duration, 5)
        {

        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (gameTime.TotalGameTime.Ticks <= CreationTime + animationTimeSpanTicks && gameTime.TotalGameTime.Ticks >= CreationTime)
            {
                int x = (int)(deltaX * DeltaTime(gameTime));
                int y = (int)(deltaY * DeltaTime(gameTime));
                spriteBatch.Draw(sprite, new Rectangle(x + start.X, y + start.Y, size.X, size.Y), Color.White);
            }
        }
    }
}
