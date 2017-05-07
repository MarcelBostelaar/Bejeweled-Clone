using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bejeweled_clone
{
    class ClickableTextureTarget
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        private GraphicsDevice graphicsDevice;
        private SpriteBatch spriteBatch;
        public RenderTarget2D texture { get; private set; }
        public int width { get; private set; }
        public int height { get; private set; }

        public List<ClickableTextureTarget> childTextures { get; set; }

        LinkedList<Vector2> mousePresses = new LinkedList<Vector2>();

        public ClickableTextureTarget(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, int width, int height)
        {
            childTextures = new List<ClickableTextureTarget>();
            this.graphicsDevice = graphicsDevice;
            this.spriteBatch = spriteBatch;
            this.width = width;
            this.height = height;
            texture = new RenderTarget2D(graphicsDevice, width, height);
        }
        /// <summary>
        /// Draws the child textures into the larger texture.
        /// </summary>
        /// <param name="gameTime">Current gamtime.</param>
        public void Draw(GameTime gameTime)
        {
            foreach(var i in childTextures)
            {
                i.Draw(gameTime);
            }
            var j = graphicsDevice.GetRenderTargets();
            graphicsDevice.SetRenderTarget(texture);
            spriteBatch.Begin();
            foreach(var child in childTextures)
            {
                spriteBatch.Draw(child.texture, child.CalculateRectangle(width, height), Color.White);
            }
            spriteBatch.End();
            graphicsDevice.SetRenderTargets(j);
        }

        public Rectangle CalculateRectangle(int width, int height)
        {
            var position = new Vector2(width, height) * Position;
            var size = new Vector2(width, height) * Size;
            return new Rectangle(position.ToPoint(), size.ToPoint());
        }
        /// <summary>
        /// Adds a click that has happened to itself and, if it happened to its children, to its children.
        /// </summary>
        /// <param name="position">The position of the click, normalised to between 0 and 1, within the bounds of this element.</param>
        public void AddClick(Vector2 position)
        {
            mousePresses.AddLast(position);
            foreach(var child in childTextures)
            {
                var newposition = (position - child.Position)/child.Size;
                if (newposition.X >= 0 && newposition.X < 1 && newposition.Y >= 0 && newposition.Y < 1)
                    child.AddClick(newposition);
            }
        }

        public bool HasPress()
        {
            if (mousePresses.Count > 0)
                return true;
            return false;
        }

        public Vector2 EarliestPress()
        {
            var i = mousePresses.First;
            if (i.Value != null)
            {
                mousePresses.RemoveFirst();
                return i.Value;
            }
            throw new Exception("No new mousepress found");
        }
    }
}
