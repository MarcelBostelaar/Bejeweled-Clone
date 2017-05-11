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
        bool CanSwap(Point FirstTile, Point SecondTile);//done
        Tuple<Point, Point> GetSelectedTiles(); //done
        bool UserInputUpdate(GameTime gameTime);//done
        /// <summary>
        /// Calculates the dropping down of the jewels.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <returns>Boolean indicating if it made a change or not.</returns>
        bool DropCalculationUpdate(GameTime gameTime, List<IAnimation> addAnimationsTo);//done
        void Draw(GameTime gameTime);//not neccecary
        void Draw(GameTime gameTime, IEnumerable<IAnimation> animations);//not neccecary
        Point TileSize { get; }//not neccecary
        List<List<Point>> ClearUpdate(GameTime gameTime);//done
        ITile GetTile(Point coordinates); //notneccecary
        ClickableTextureTarget BoardTexture { get; }//not neccecary
        void DrawGems(GameTime gameTime);//not neccecary
        List<Tuple<Point, IAnimation>> GetAllJewels(long duration, GameTime gameTime); //done
        List<Tuple<Point, IAnimation>> GetAllTiles(long duration, GameTime gameTime); //done
    }
}
