using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bejeweled_clone.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bejeweled_clone.Model
{
    class SimpleBoard : IPlayBoard
    {
        ClickableTextureTarget renderTexture;
        GraphicsDevice graphicsDevice;
        SpriteBatch spriteBatch;
        const int tileWidth = 100;
        const int tileHeight = 100;

        ITile[,] board;
        List<Point> selectedTiles;

        public ClickableTextureTarget BoardTexture
        {
            get
            {
                return renderTexture;
            }
        }

        public Point TileSize
        {
            get
            {
                return new Point(tileWidth, tileHeight);
            }
        }

        public SimpleBoard(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, int widthInTiles, int heightInTiles)
        {
            selectedTiles = new List<Point>();
            renderTexture = new ClickableTextureTarget(spriteBatch, graphicsDevice, widthInTiles * tileWidth, heightInTiles * tileHeight);
            this.graphicsDevice = graphicsDevice;
            this.spriteBatch = spriteBatch;

            board = new ITile[widthInTiles, heightInTiles];
            for (int x = 0; x < widthInTiles; x++)
            {
                for (int y = 0; y < heightInTiles; y++)
                {
                    if (y == 0)
                    {
                        board[x, y] = new JewelGeneratingTile();
                    }
                    else
                    {
                        var prevTiles = new List<Point> { new Point(x, y - 1) };
                        board[x, y] = new NormalTile(prevTiles, this);
                    }
                }
            }
        }

        public bool CanSwap(Point FirstTile, Point SecondTile)
        {
            return GetTile(FirstTile).jewel.CanDoSpecialActionWith(GetTile(SecondTile).jewel);
        }
        /// <summary>
        /// Draws the board onto a ClickableRenderTarget. Spritebatch must not have started.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <returns></returns>
        public void Draw(GameTime gameTime)
        {
            var originalRendertargets = graphicsDevice.GetRenderTargets();
            graphicsDevice.SetRenderTarget(renderTexture.texture);
            graphicsDevice.Clear(Color.White);
            spriteBatch.Begin();

            DrawBoard(gameTime);
            DrawGems(gameTime);

            spriteBatch.End();
            graphicsDevice.SetRenderTargets(originalRendertargets);
        }

        public List<Tuple<Point, IAnimation>> GetAllTiles(long ticks, GameTime gameTime)
        {
            List<Tuple<Point, IAnimation>> sprites = new List<Tuple<Point, IAnimation>>();
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (board[x, y].GetSprite() != null)
                        sprites.Add(new Tuple<Point, IAnimation>(new Point(x, y), new StaticBoardTile(new Point(x, y) * TileSize, board[x, y].GetSprite(), TileSize, gameTime, ticks)));
                }
            }
            return sprites;
        }
        
        public List<Tuple<Point, IAnimation>> GetAllJewels(long ticks, GameTime gameTime)
        {
            List<Tuple<Point, IAnimation>> sprites = new List<Tuple<Point, IAnimation>>();
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (board[x, y].jewel != null)
                        sprites.Add(new Tuple<Point, IAnimation>(new Point(x, y),new StaticGem(new Point(x, y) * TileSize, board[x, y].jewel.sprite, TileSize, gameTime, ticks)));
                }
            }
            return sprites;
        }

        public void DrawGems(GameTime gameTime)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (board[x, y].jewel != null)
                        spriteBatch.Draw(board[x, y].jewel.sprite, new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight), Color.White);
                }
            }
        }

        private void DrawBoard(GameTime gameTime)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    spriteBatch.Draw(board[x, y].GetSprite(), new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight), Color.White);
                }
            }

            foreach (var i in selectedTiles)
                spriteBatch.Draw(board[i.X, i.Y].GetSprite(), new Rectangle(i.X * tileWidth, i.Y * tileHeight, tileWidth, tileHeight), Color.Red);
        }
        
        public bool UserInputUpdate(GameTime gameTime)
        {
            if (renderTexture.HasPress())
            {
                var vector = renderTexture.EarliestPress();
                vector *= new Vector2(board.GetLength(0), board.GetLength(1));
                selectedTiles.Add(vector.ToPoint());
            }
            if(selectedTiles.Count == 2)
            {
                if(Math.Abs((selectedTiles[0] - selectedTiles[1]).X) + Math.Abs((selectedTiles[0] - selectedTiles[1]).Y) == 1)
                {
                    return true;
                }
                selectedTiles.Clear();
            }
            return false;
        }

        public bool DropCalculationUpdate(GameTime gameTime, List<IAnimation> addAnimationsTo)
        {
            bool madeChange = false;
            for (int y = board.GetLength(1)-1; y >= 0; y--)
            {
                for (int x = 0; x < board.GetLength(0); x++)
                {
                    if(board[x,y].jewel == null)
                    {
                        var animation = board[x, y].GetJewelFromPreviousTile(new Point(x, y), gameTime, new Point(tileWidth, tileHeight));
                        if(animation != null)
                        {
                            madeChange = true;
                            addAnimationsTo.Add(animation);
                        }
                    }
                    else
                    {
                        var gemSize = new Point(tileWidth, tileHeight);
                        addAnimationsTo.Add(new GemMovementAnimation(new Point(x, y) * gemSize, new Point(x, y) * gemSize, board[x, y].jewel.sprite, gemSize, gameTime));
                    }
                }
            }
            return madeChange;
        }

        public ITile GetTile(Point coordinates)
        {
            return board[coordinates.X, coordinates.Y];
        }

        public void Draw(GameTime gameTime, IEnumerable<IAnimation> animations)
        {
            var originalRendertargets = graphicsDevice.GetRenderTargets();
            graphicsDevice.SetRenderTarget(renderTexture.texture);

            spriteBatch.Begin();
            //DrawBoard(gameTime);
            foreach(var i in animations)
            {
                i.Draw(gameTime, spriteBatch);
            }
            spriteBatch.End();

            graphicsDevice.SetRenderTargets(originalRendertargets);
        }

        public List<List<Point>> ClearUpdate(GameTime gameTime)
        {
            List<List<Point>> AllCollections = new List<List<Point>>();
            for (int y = 0; y < board.GetLength(1); y++)//horizontal clearing
            {
                for (int x = 0; x < board.GetLength(0); x++)
                {
                    var i = FindHorizontalClear(new Point(x, y));
                    if (i != null)
                    {
                        AllCollections.Add(i);
                        x = i.Last().X;
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
                        y = i.Last().Y;
                    }
                }
            }
            return AllCollections;
        }

        private List<Point> FindHorizontalClear(Point index)
        {
            var original = index;
            var list = new List<Point>();
            while (index.X < board.GetLength(0) && GetTile(index).jewel.CanClearWith(GetTile(original).jewel))
            {
                list.Add(index);
                index = new Point(index.X + 1, index.Y);
            }
            if (list.Count > 2)
                return list;
            return null;
        }
        private List<Point> FindVerticalClear(Point index)
        {
            var original = index;
            var list = new List<Point>();
            while (index.Y < board.GetLength(1) && GetTile(index).jewel.CanClearWith(GetTile(original).jewel))
            {
                list.Add(index);
                index = new Point(index.X, index.Y + 1);
            }
            if (list.Count > 2)
                return list;
            return null;
        }

        public Tuple<Point, Point> GetSelectedTiles()
        {
            if (selectedTiles.Count == 2)
            {
                var i = new Tuple<Point, Point>(selectedTiles[0], selectedTiles[1]);
                selectedTiles.Clear();
                return i;
            }
            return null;
        }
    }
}
