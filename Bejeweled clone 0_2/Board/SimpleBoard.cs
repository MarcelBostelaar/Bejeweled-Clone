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
        private ITile[,] board;
        private List<Tuple<Point, ITile>> allTiles;
        private List<Point> selectedTiles = new List<Point>();

        public SimpleBoard(int width, int height)
        {
            boardSize = new Point(width, height);
            board = new ITile[width, height];
            var jewelgenerator = new Jewels.JewelGenerators.SimpleJewelGenerator();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (y == 0)
                        board[x, y] = new JewelGeneratingTile(jewelgenerator);
                    else
                        board[x, y] = new NormalTile(this);
                    allTiles.Add(new Tuple<Point, ITile>(new Point(x, y), board[x, y]));
                }
            }

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
            return GetTile(firstTile).jewel.CanDoSpecialActionWith(GetTile(secondTile).jewel);
        }

        public IEnumerable<IEnumerable<Tuple<Point, Jewel>>> ClearingUpdate()
        {
            List<List<Tuple<Point, Jewel>>> AllCollections = new List<List<Tuple<Point, Jewel>>>();
            for (int y = 0; y < board.GetLength(1); y++)//horizontal clearing
            {
                for (int x = 0; x < board.GetLength(0); x++)
                {
                    var i = FindHorizontalClear(new Point(x, y));
                    if (i != null)
                    {
                        AllCollections.Add(i);
                        x = i.Last().Item1.X;
                    }
                }
            }
            for (int x = 0; x < board.GetLength(0); x++)//horizontal clearing
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    var i = FindVerticalClear(new Point(x, y));
                    if (i != null)
                    {
                        AllCollections.Add(i);
                        y = i.Last().Item1.Y;
                    }
                }
            }
            return AllCollections;
        }

        public IEnumerable<Tuple<Point, Point, Jewel>> DropCalculationUpdate()
        {
            List<Tuple<Point, Point, Jewel>> droppedJewels = new List<Tuple<Point, Point, Jewel>>();
            for (int y = boardSize.Y -1; y >= 0; y--)
            {
                for (int x = 0; x < boardSize.X; x++)
                {
                    if(board[x,y].jewel == null)
                    {
                        var i = board[x, y].GetJewelPreviousTile(new Point(x, y));
                        if (i != null)
                            droppedJewels.Add(i);
                    }
                }
            }
            return droppedJewels;
        }

        public IEnumerable<Tuple<Point, Jewel>> GetAllJewels()
        {
            List<Tuple<Point, Jewel>> list = new List<Tuple<Point, Jewel>>();
            for (int x = 0; x < boardSize.X; x++)
            {
                for (int y = 0; y < boardSize.Y; y++)
                {
                    if (board[x, y].jewel != null)
                        list.Add(new Tuple<Point, Jewel>(new Point(x, y), board[x, y].jewel));
                }
            }
            return list;
        }

        public IEnumerable<Tuple<Point, ITile>> GetAllTiles()
        {
            return allTiles;
        }

        public IEnumerable<Point> GetSelectedTiles()
        {
            return selectedTiles;
        }

        public void ClearSelectedTiles()
        {
            selectedTiles.Clear();
        }

        public bool SwapJewels(Point firstTile, Point secondTile)
        {
            if (GetTile(firstTile).jewel != null && GetTile(secondTile).jewel != null)
            {
                var first = GetTile(firstTile).jewel;
                GetTile(firstTile).jewel = GetTile(secondTile).jewel;
                GetTile(secondTile).jewel = first;
                return true;
            }            
            return false;
        }

        public ITile GetTile(Point coordinates)
        {
            return board[coordinates.X, coordinates.Y];
        }

        /// <summary>
        /// Finds all continuous jewels that can be cleared with the given jewel to the right of the given jewel.
        /// </summary>
        /// <param name="index">The index of the jewel.</param>
        /// <returns>A list of clearable jewels (3 or more) with their position, from the given one to the right.</returns>
        private List<Tuple<Point, Jewel>> FindHorizontalClear(Point index)
        {
            var original = index;
            var list = new List<Tuple<Point, Jewel>>();
            while (index.X < boardSize.X && GetTile(index).jewel.CanClearWith(GetTile(original).jewel))
            {
                list.Add(new Tuple<Point, Jewel>(index, GetTile(index).jewel));
                index = new Point(index.X + 1, index.Y);
            }
            if (list.Count > 2)
                return list;
            return null;
        }
        /// <summary>
        /// Finds all continuous jewels that can be cleared with the given jewel to the bottom of the given jewel.
        /// </summary>
        /// <param name="index">The index of the jewel.</param>
        /// <returns>A list of clearable jewels (3 or more) with their position, from the given one to the bottom.</returns>
        private List<Tuple<Point, Jewel>> FindVerticalClear(Point index)
        {
            var original = index;
            var list = new List<Tuple<Point, Jewel>>();
            while (index.Y < boardSize.Y && GetTile(index).jewel.CanClearWith(GetTile(original).jewel))
            {
                list.Add(new Tuple<Point, Jewel>(index, GetTile(index).jewel));
                index = new Point(index.X, index.Y + 1);
            }
            if (list.Count > 2)
                return list;
            return null;
        }
    }
}
