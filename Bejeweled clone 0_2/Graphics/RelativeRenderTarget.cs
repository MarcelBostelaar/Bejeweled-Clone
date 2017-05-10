using Bejeweled_clone_0_2.Graphics.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bejeweled_clone_0_2.Graphics
{
    class RelativeRenderTarget : IAnimation
    {
        private RenderTarget2D renderTarget { get; set; }
        private int width { get; set; }
        private int height { get; set; }


        /// <summary>
        /// The position of this RelativeRenderTarget in its parent, with 0,0 representing topleft and 1,1 representing bottomright.
        /// </summary>
        public Vector2 position { get; set; }
        /// <summary>
        /// The size of this RelativeRenderTarget in its parent, with 0,0 representing topleft and 1,1 representing bottomright.
        /// </summary>
        public Vector2 size { get; set; }
        /// <summary>
        /// A list of the child textures of this texture.
        /// </summary>
        public List<RelativeRenderTarget> childTextures { get; set; }

        /// <summary>
        /// List of all the IAnimations, except for the ChildRenderTargets.
        /// </summary>
        public List<IAnimation> animations { get; set; }

        /// <summary>
        /// Draws the children of this RelativeRenderTexture onto itself. Also draws any child RelativeRenderTexture using this method.
        /// </summary>
        /// <param name="gameTime">Current gametime.</param>
        /// <param name="spriteBatch">A spritebatch instance, <b>not started</b>.</param>
        public void DrawChildren(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var child in childTextures)
                child.DrawChildren(gameTime, spriteBatch);

            var AllAnimations = new List<IAnimation>();
            AllAnimations.AddRange(childTextures);
            AllAnimations.AddRange(animations);
            animations.Sort();
            //add children and animations into one sorted list.
            //draw the list.
            throw new NotImplementedException();
        }

        public RelativeRenderTarget(GraphicsDevice graphicsDevice, int width, int height)
        {
            renderTarget = new RenderTarget2D(graphicsDevice, width, height);
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// The z index of this Relative Render Target. Higher z indexes will be drawn on top of lower z indexes.
        /// </summary>
        public int zIndex
        {
            get; set;
        }

        /// <summary>
        /// Compares an IAnimation object to this one based on its zIndex.
        /// </summary>
        /// <param name="other">An IAnimation object.</param>
        /// <returns>An integer indicating the order. If &lt;0, this instance should come before the other. If &gt;0, this instance should come after the other. Is 0, they have the same zIndex and can be ordered in either way.</returns>
        public int CompareTo(IAnimation other)
        {
            return zIndex - other.zIndex;
        }

        /// <summary>
        /// Returns a boolean indication if this animation has terminated. This class is never terminated by time.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <returns>False, not terminated</returns>
        public bool Done(GameTime gameTime)
        {
            return false;
        }

        /// <summary>
        /// Draw this animation using spritebatch.
        /// </summary>
        /// <param name="gameTime">Current GameTime</param>
        /// <param name="spriteBatch">SpriteBatch instance that <b>has already begun (using .Begin())</b>.</param>
        /// <param name="parentSize">Size of its parent render target in pixels.</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 parentSize)
        {
            spriteBatch.Draw(renderTarget, new Rectangle((position * parentSize).ToPoint(), (size * parentSize).ToPoint()), Color.White);
        }
    }
}
