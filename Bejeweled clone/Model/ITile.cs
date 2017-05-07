using Bejeweled_clone.Animation;
using Bejeweled_clone.Model.Jewels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone.Model
{
    interface ITile
    {
        void Accept(ITileVisitor visitor);
        void Clear();
        Jewel jewel { get; set; }
        Texture2D GetSprite();
        /// <summary>
        /// Gets a jewel from the previous tile.
        /// </summary>
        /// <returns>A boolean indicating whether it changed state.</returns>
        IAnimation GetJewelFromPreviousTile(Point ownIndex, GameTime gameTime, Point gemSize);
    }
}
