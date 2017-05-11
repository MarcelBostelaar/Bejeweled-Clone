using Bejeweled_clone_0_2.Board.Jewels;
using Bejeweled_clone_0_2.Board.Tiles;
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
        Point boardSize { get; }
        /// <summary>
        /// Does one drop calculation update and returns an enumerable of tuples indicating how the jewels moved.
        /// </summary>
        /// <returns>Enumerable of tuples of 2 points and a jewel. First point is original position. Second point is new position. The jewel is the jewel that was moved.</returns>
        IEnumerable<Tuple<Point, Point, Jewel>> DropCalculationUpdate();
        /// <summary>
        /// Attempts to swap the jewels of two tiles. Returns boolean indicating success.
        /// </summary>
        /// <param name="firstTile">Coordinates of first tile.</param>
        /// <param name="secondTile">Coordinates of second tile.</param>
        /// <returns>Boolean idicatin success.</returns>
        bool SwapJewels(Point firstTile, Point secondTile);
        /// <summary>
        /// Does a clearing update and returns an enumerable of enumerables, which are the collections of clearing jewels.
        /// </summary>
        /// <returns>An enumerable of enumerable of tuples. Each enumerable in of tuples is a group of cleared jewels. In the tuple, the point indicates the coordinates where it was cleared, and the Jewel is the jewel that was cleared.</returns>
        IEnumerable<IEnumerable<Tuple<Point, Jewel>>> ClearingUpdate();
        /// <summary>
        /// Returns an enumerable of tuples of all existing jewels. Point indicated the coordinates, Jewel is the jewel.
        /// </summary>
        /// <returns>Enumerable of tuples. Point is coordinate on the board. Jewel is the jewel.</returns>
        IEnumerable<Tuple<Point, Jewel>> GetAllJewels();
        /// <summary>
        /// Returns an enumerable of tuples of all existing tiles. Point indicated the coordinates, ITile is the tile.
        /// </summary>
        /// <returns>Enumerable of tuples. Point is coordinate on the board. ITile is the tile.</returns>
        IEnumerable<Tuple<Point, ITile>> GetAllTiles();
        /// <summary>
        /// Returns a specified ITile by coordinate.
        /// </summary>
        /// <param name="coordinates">The coordinate of the tile to retrieve.</param>
        /// <returns>The specified ITile.</returns>
        ITile GetTile(Point coordinates);
    }
}
