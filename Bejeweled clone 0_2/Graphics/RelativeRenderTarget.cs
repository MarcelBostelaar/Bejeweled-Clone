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
        private GraphicsDevice graphicsDevice { get; set; }
        private LinkedList<Vector2> mouseClicks = new LinkedList<Vector2>();

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
        public IEnumerable<IAnimation> animations { get; set; }
        
        /// <summary>
        /// A relative render target is used to draw IAnimations using relative coordinates and relative sizes. The top left is 0,0 and the bottom right is 1,1.
        /// </summary>
        /// <param name="graphicsDevice">A graphics device instance.</param>
        /// <param name="width">The width of this render target.</param>
        /// <param name="height">The height of this render target.</param>
        public RelativeRenderTarget(GraphicsDevice graphicsDevice, int width, int height)
        {
            renderTarget = new RenderTarget2D(graphicsDevice, width, height);
            this.width = width;
            this.height = height;
            this.graphicsDevice = graphicsDevice;
            childTextures = new List<RelativeRenderTarget>();
            animations = new List<IAnimation>();
        }

        /// <summary>
        /// Draws the children of this RelativeRenderTexture onto itself. Also draws any child RelativeRenderTexture using this method.
        /// </summary>
        /// <param name="gameTime">Current gametime.</param>
        /// <param name="spriteBatch">A spritebatch instance, <b>not started</b>.</param>
        public void DrawChildren(GameTime gameTime, SpriteBatch spriteBatch)
        {
            List<IAnimation> newAnimations = new List<IAnimation>();
            foreach (var animation in animations)
            {
                if (!animation.Done(gameTime))
                    newAnimations.Add(animation);
            }
            animations = newAnimations;

            foreach (var child in childTextures)
                child.DrawChildren(gameTime, spriteBatch);

            var AllAnimations = new List<IAnimation>();
            AllAnimations.AddRange(childTextures);
            AllAnimations.AddRange(animations);
            AllAnimations.Sort();
            
            var oldTarget = graphicsDevice.GetRenderTargets();
            graphicsDevice.SetRenderTarget(renderTarget);

            spriteBatch.Begin();
            foreach (var animation in AllAnimations)
            {
                animation.Draw(gameTime, spriteBatch, size);
            }
            spriteBatch.End();

            graphicsDevice.SetRenderTargets(oldTarget);
        }

        /// <summary>
        /// Returns the oldest click that is saved. Removes that click from the saved clicks.
        /// </summary>
        /// <returns>A click position, normalised to 0,0 as the top left and 1,1 as the bottom right.</returns>
        public Vector2 GetEarliestClick()
        {
            if (mouseClicks.Count == 0)
                throw new Exception("No click was found.");
            var i = mouseClicks.First.Value;
            mouseClicks.RemoveFirst();
            return i;
        }

        /// <summary>
        /// Indicates if there is a new click available.
        /// </summary>
        /// <returns>Boolean indicating the presence of a new click.</returns>
        public bool HasClick()
        {
            if (mouseClicks.Count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Saves a mouseclick in the relative position of this RelativeRenderTarget, and saves it to all its children.
        /// </summary>
        /// <param name="position">The position normalised to 0,0 as the top left and 1,1 as the bottom right.</param>
        public void AddClick(Vector2 position)
        {
            mouseClicks.AddLast(position);
            foreach(var child in childTextures)
            {
                Vector2 newPosition = (position - child.position) / child.size;
                if (newPosition.X >= 0 && newPosition.X < 1 && newPosition.Y >= 0 && newPosition.Y < 1)
                    child.AddClick(newPosition);
            }
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
