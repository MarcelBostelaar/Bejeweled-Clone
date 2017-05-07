using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Bejeweled_clone.Model.Jewels;
using Microsoft.Xna.Framework.Graphics;
using Bejeweled_clone.Animation;

namespace Bejeweled_clone.Model
{
    class NormalTile : ITile
    {
        public static Texture2D Sprite { get; set; }
        IPlayBoard board;
        public NormalTile(List<Point> previousTiles, IPlayBoard board)
        {
            this.board = board;
            PreviousTilesCycleIndex = new LimitedInt(0, previousTiles.Count-1);
            this.previousTiles = previousTiles;
        }


        List<Point> previousTiles;
        LimitedInt PreviousTilesCycleIndex;

        public Jewel jewel{ get; set; }

        public void Accept(ITileVisitor visitor)
        {
            visitor.visit(this);
        }

        public void Clear()
        {
            jewel?.Clear();
            jewel = null;
        }

        public Texture2D GetSprite()
        {
            return Sprite;
        }

        public IAnimation GetJewelFromPreviousTile(Point ownIndex, GameTime gameTime, Point gemSize)
        {
            if(jewel != null)
            {
                return null;
            }
            var startindex = PreviousTilesCycleIndex.Value;
            var prevtile = board.GetTile(previousTiles[PreviousTilesCycleIndex.Value]);
            Point prevTileIndex = previousTiles[PreviousTilesCycleIndex.Value];
            PreviousTilesCycleIndex++;
            while (prevtile.jewel == null && startindex != PreviousTilesCycleIndex.Value)
            {
                prevtile = board.GetTile(previousTiles[PreviousTilesCycleIndex.Value]);
                prevTileIndex = previousTiles[PreviousTilesCycleIndex.Value];
                PreviousTilesCycleIndex++;
            }
            if (prevtile.jewel == null)
                return null;
            jewel = prevtile.jewel;
            prevtile.jewel = null;
            return new GemMovementAnimation(prevTileIndex*gemSize, ownIndex*gemSize, jewel.sprite, gemSize, gameTime);
        }
    }
}
