using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone.Interfaces
{
    interface ISimpleDraw
    {
        /// <summary>
        /// Calls the draw functionality of the function using spritebatch. Assumes spritebatch has already begun.
        /// </summary>
        /// <param name="gameTime">Gametime</param>
        /// <param name="spriteBatch">Spritebatch</param>
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        int drawWidth { get; set; }
        int drawHeight { get; set; }
        Point drawPosition { get; set; }
    }
}
