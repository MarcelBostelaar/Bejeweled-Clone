using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bejeweled_clone_0_2.Board.Jewels;
using Bejeweled_clone_0_2.Graphics.Animation;
using Microsoft.Xna.Framework;
using Bejeweled_clone_0_2.Board.Jewels.JewelGenerators;
using Bejeweled_clone_0_2.Graphics.Animation.SpriteCycles;

namespace Bejeweled_clone_0_2.Board.Tiles
{
    class JewelGeneratingTile : ITile
    {
        public static ISpriteCycle spriteCycle;

        IJewelGenerator generator;
        public JewelGeneratingTile(IJewelGenerator generator)
        {
            this.generator = generator;
        }

        Jewel _jewel;

        public Jewel jewel
        {
            get
            {
                if (_jewel == null)
                    _jewel = generator.Next;
                return _jewel;
            }
            set
            {
                _jewel = value;
            }
        }

        public Tuple<Point, Point, Jewel> GetJewelPreviousTile(Point ownIndex)
        {
            return null;
        }

        public ISpriteCycle GetSpriteCycle()
        {
            return spriteCycle;
        }
    }
}
