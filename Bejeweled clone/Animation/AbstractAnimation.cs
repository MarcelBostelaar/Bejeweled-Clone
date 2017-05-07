using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bejeweled_clone.Animation
{
    abstract class AbstractAnimation : IAnimation
    {
        public long animationTimeSpanTicks { get; protected set; }
        public AbstractAnimation(Point StartingCoordinates, Point EndCoordinates, Texture2D sprite, Point size, GameTime gameTime, long animationTimeTicks)
        {
            animationTimeSpanTicks = animationTimeTicks;
            start = StartingCoordinates;
            this.size = size;
            this.sprite = sprite;
            CreationTime = gameTime.TotalGameTime.Ticks;
            deltaX = (float)(EndCoordinates.X - StartingCoordinates.X) / (float)animationTimeSpanTicks;
            deltaY = (float)(EndCoordinates.Y - StartingCoordinates.Y) / (float)animationTimeSpanTicks;
        }

        protected Point start;
        protected float deltaX, deltaY;
        protected Texture2D sprite;
        protected Point size;
        protected long CreationTime;

        public long duration
        {
            get
            {
                return animationTimeSpanTicks;
            }
        }

        public bool Done(GameTime gameTime)
        {
            if (CreationTime + animationTimeSpanTicks < gameTime.TotalGameTime.Ticks)
                return true;
            return false;
        }

        protected float DeltaTime(GameTime current)
        {
            return current.TotalGameTime.Ticks - CreationTime;
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
