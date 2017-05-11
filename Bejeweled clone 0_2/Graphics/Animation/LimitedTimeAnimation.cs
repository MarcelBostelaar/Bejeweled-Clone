using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bejeweled_clone_0_2.Graphics.Animation
{
    class LimitedTimeAnimation : IAnimation
    {
        private IAnimation animation;
        private long lenght, startingTime;

        /// <summary>
        /// Constructs a new instance of a limited time animation that wraps another IAnimation instance. Will return true to "done" after specified time.
        /// </summary>
        /// <param name="animation">The IAnimation to be wrapped.</param>
        /// <param name="lenghtInTicks">The lenght in ticks (100 nanoseconds) for the animation to last.</param>
        /// <param name="currentGameTime">The current gametime.</param>
        public LimitedTimeAnimation(IAnimation animation, long lenghtInTicks, GameTime currentGameTime)
        {
            this.animation = animation;
            this.lenght = lenghtInTicks;
            startingTime = currentGameTime.TotalGameTime.Ticks;
        }

        public int zIndex
        {
            get
            {
                return animation.zIndex;
            }
        }

        public int CompareTo(IAnimation other)
        {
            return zIndex - other.zIndex;
        }

        public bool Done(GameTime gameTime)
        {
            if (startingTime + lenght < gameTime.TotalGameTime.Ticks)
                return true;
            return false;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 parentSize)
        {
            animation.Draw(gameTime, spriteBatch, parentSize);
        }
    }
}
