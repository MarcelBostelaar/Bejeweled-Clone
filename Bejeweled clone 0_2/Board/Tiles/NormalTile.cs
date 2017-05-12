using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bejeweled_clone_0_2.Board.Jewels;
using Bejeweled_clone_0_2.Graphics.Animation;
using Bejeweled_clone_0_2.Graphics.Animation.SpriteCycles;
using Microsoft.Xna.Framework;

namespace Bejeweled_clone_0_2.Board.Tiles
{
    class NormalTile : ITile
    {
        public static ISpriteCycle spriteCycle;

        public Jewel jewel { get; set; }
        private IPlayBoard board;

        public NormalTile(IPlayBoard board)
        {
            this.board = board;
        }

        public Tuple<Point, Point, Jewel> GetJewelPreviousTile(Point ownIndex)
        {
            if (ownIndex.Y == 0)
                return null;
            var otherTile = board.GetTile(ownIndex - new Point(0, 1));
            if (otherTile.jewel != null)
            {
                jewel = otherTile.jewel;
                otherTile.jewel = null;
                return new Tuple<Point, Point, Jewel>(ownIndex - new Point(0, 1), ownIndex, jewel);
            }
            return null;
        }

        public ISpriteCycle GetSpriteCycle()
        {
            return spriteCycle;
        }
    }
}
