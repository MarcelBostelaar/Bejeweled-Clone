using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone_0_2.Graphics.Animation
{
    interface IAnimation : IComparable<IAnimation>
    {
        /// <summary>
        /// Returns a boolean indication if this animation has terminated.
        /// </summary>
        /// <param name="gameTime">Current GameTime.</param>
        /// <returns>True if animation has terminated, false if not terminated.</returns>
        bool Done(GameTime gameTime);
        /// <summary>
        /// Draw this animation using spritebatch.
        /// </summary>
        /// <param name="gameTime">Current GameTime</param>
        /// <param name="spriteBatch">SpriteBatch instance that <b>has already begun (using .Begin())</b>.</param>
        /// <param name="parentSize">Size of its parent render target in pixels.</param>
        void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 parentSize);
        /// <summary>
        /// The z index of this IAnimation. Higher z indexes will be drawn on top of lower z indexes.
        /// </summary>
        int zIndex { get; }
    }
}
