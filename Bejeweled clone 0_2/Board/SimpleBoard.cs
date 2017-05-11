using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bejeweled_clone_0_2.Board.Jewels;
using Bejeweled_clone_0_2.Board.Tiles;
using Microsoft.Xna.Framework;

namespace Bejeweled_clone_0_2.Board
{
    class SimpleBoard : IPlayBoard
    {
        private ITile[,] Board;
        private List<Tuple<Point, ITile>> allTiles;
        private List<Point> selectedTiles = new List<Point>();

        public SimpleBoard(int width, int height)
        {
            boardSize = new Point(width, height);
            Board = new ITile[width, height];
            //fill board

        }

        public Point boardSize { get; private set; }

        public void AddClick(Point coordinate)
        {
            if (selectedTiles.Contains(coordinate))
                selectedTiles.Remove(coordinate);
            else
                selectedTiles.Add(coordinate);
        }

        public bool CanDoSpecialAction(Point firstTile, Point secondTile)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEnumerable<Tuple<Point, Jewel>>> ClearingUpdate()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tuple<Point, Point, Jewel>> DropCalculationUpdate()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tuple<Point, Jewel>> GetAllJewels()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tuple<Point, ITile>> GetAllTiles()
        {
            return allTiles;
        }

        public IEnumerable<Point> GetSelectedTiles()
        {
            throw new NotImplementedException();
        }

        public void ClearSelectedTiles()
        {
            throw new NotImplementedException();
        }

        public bool SwapJewels(Point firstTile, Point secondTile)
        {
            throw new NotImplementedException();
        }

        public ITile GetTile(Point coordinates)
        {
            return Board[coordinates.X, coordinates.Y];
        }
    }
}
