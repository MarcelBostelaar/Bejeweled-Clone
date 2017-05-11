using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone_0_2.Board
{
    interface IPlayBoard
    {
        /// <summary>
        /// Returns a boolean indicating if two tiles can perform a special action together.
        /// </summary>
        /// <param name="firstTile">The first tile's coordinates.</param>
        /// <param name="secondTile">The second tile's coordinates.</param>
        /// <returns>Boolean indicating whether or not the tiles can do a special action together.</returns>
        bool CanDoSpecialAction(Point firstTile, Point secondTile);
        /// <summary>
        /// Returns an enumerable of all the selected tiles on the board.
        /// </summary>
        /// <returns>A list containing all the selected tiles in order, earliest being first.</returns>
        IEnumerable<Point> GetSelectedTiles();
        /// <summary>
        /// Clears all the selected tiles on the board.
        /// </summary>
        void ClearSelectedTiles();
        /// <summary>
        /// Adds a click on a specified tile's coordinate.
        /// </summary>
        /// <param name="coordinate">The coordinate of the tile that was clicked.</param>
        void AddClick(Point coordinate);
        /// <summary>
        /// The dimentions of the playboard in tiles.
        /// </summary>
        Point size { get; }
        /// <summary>
        /// Does one drop calculation update and returns an enumerable of tuples indicating which gems were moved.
        /// </summary>
        /// <returns>Enumerable of tuples of 2 points. First point is original position. Second point is new position.</returns>
        IEnumerable<Tuple<Point, Point>> DropCalculationUpdate();
    }
}
