using Bejeweled_clone_0_2.Board.Jewels;
using Bejeweled_clone_0_2.Graphics.Animation.SpriteCycles;
using Microsoft.Xna.Framework;
using System;

namespace Bejeweled_clone_0_2.Board.Tiles
{
    interface ITile
    {
        Jewel jewel { get; set; }
        ISpriteCycle GetSpriteCycle();
        /// <summary>
        /// Attempts to retrieve a jewel from this tiles previous tile.
        /// </summary>
        /// <param name="ownIndex">The positional index of this tile.</param>
        /// <returns>Null if unsuccesfull. If succesfull, a tuple containing the jewels original position, its new position and the jewel itself.</returns>
        Tuple<Point, Point, Jewel> GetJewelPreviousTile(Point ownIndex); //need the index for non-directly connected tiles.
    }
}
