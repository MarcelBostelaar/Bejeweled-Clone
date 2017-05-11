using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bejeweled_clone_0_2.Board.Jewels;
using Bejeweled_clone_0_2.Graphics.Animation;
using Microsoft.Xna.Framework;

namespace Bejeweled_clone_0_2.Board.Tiles
{
    class NormalTile : ITile
    {
        public Jewel jewel { get; set; }
        private IPlayBoard board;

        public NormalTile(IPlayBoard board)
        {
            this.board = board;
        }

        public IAnimation GetAnimation()
        {
            throw new NotImplementedException();
        }

        public void GetJewelPreviousTile(Point ownIndex)
        {
            if (ownIndex.Y == 0)
                return;
            var otherTile = board.GetTile(ownIndex - new Point(0, 1));
            jewel = otherTile.jewel;
            otherTile.jewel = null;
        }
    }
}
