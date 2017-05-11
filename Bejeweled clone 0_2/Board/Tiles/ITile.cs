using Bejeweled_clone_0_2.Graphics.Animation;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone_0_2.Board.Tiles
{
    interface ITile
    {
        Jewels.Jewel jewel { get; set; }
        IAnimation GetAnimation(GameTime gameTime, long duration);
        void GetJewelPreviousTile(Point ownIndex); //need the index for non-directly connected tiles.
    }
}
