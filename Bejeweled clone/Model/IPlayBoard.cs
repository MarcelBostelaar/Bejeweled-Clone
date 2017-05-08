using Bejeweled_clone.Animation;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone.Model
{
    interface IPlayBoard
    {
        bool CanSwap(Point FirstTile, Point SecondTile);
        Tuple<Point, Point> GetSelectedTiles();
        bool UserInputUpdate(GameTime gameTime);
        /// <summary>
        /// Calculates the dropping down of the jewels.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <returns>Boolean indicating if it made a change or not.</returns>
        bool DropCalculationUpdate(GameTime gameTime, List<IAnimation> addAnimationsTo);
        void Draw(GameTime gameTime);
        void Draw(GameTime gameTime, IEnumerable<IAnimation> animations);
        Point TileSize { get; }
        List<List<Point>> ClearUpdate(GameTime gameTime);
        ITile GetTile(Point coordinates);
        ClickableTextureTarget BoardTexture { get; }
        void DrawGems(GameTime gameTime);
        List<Tuple<Point, IAnimation>> GetAllJewels(long duration, GameTime gameTime);
        List<Tuple<Point, IAnimation>> GetAllTiles(long duration, GameTime gameTime);
    }
}
