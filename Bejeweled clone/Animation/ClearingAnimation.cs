using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bejeweled_clone.Animation
{
    class ClearingAnimation : AbstractAnimation
    {
        public static Texture2D ClearingSprite;
        public static long Duration { get { return 20000000; } }
        
        public ClearingAnimation(Point position, Point size, GameTime gameTime) : base(position, position, ClearingSprite, size, gameTime, Duration)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (gameTime.TotalGameTime.Ticks <= CreationTime + animationTimeSpanTicks && gameTime.TotalGameTime.Ticks >= CreationTime)
            {
                spriteBatch.Draw(sprite, new Rectangle(start.X,start.Y, size.X, size.Y), Color.White);
            }
        }
    }
}
