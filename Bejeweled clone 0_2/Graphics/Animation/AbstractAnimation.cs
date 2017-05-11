using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bejeweled_clone_0_2.Graphics.Animation
{
    abstract class AbstractAnimation : IAnimation
    {
        protected Vector2 position, size;
        /// <summary>
        /// Creates a new instance of the abstractanimation class.
        /// </summary>
        /// <param name="zIndex">The z index of this instance. Higher z index is draw on top.</param>
        /// <param name="position">Position of this instance relative to its parent, with 0,0 being to topleft and 1,1 being botton right.</param>
        /// <param name="size">Size of this instance relative to its parent. 1 represent 100% of the size of the parent.</param>
        public AbstractAnimation(int zIndex, Vector2 position, Vector2 size)
        {
            this.position = position;
            this.size = size;
            this.zIndex = zIndex;
        }

        public int zIndex { get; private set; }

        public int CompareTo(IAnimation other)
        {
            return zIndex - other.zIndex;
        }

        public bool Done(GameTime gameTime)
        {
            return false;
        }

        abstract public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 parentSize);
    }
}
