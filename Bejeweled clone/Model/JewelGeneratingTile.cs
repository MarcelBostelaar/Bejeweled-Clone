using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bejeweled_clone.Animation;
using Bejeweled_clone.Model.Jewels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bejeweled_clone.Model
{
    class JewelGeneratingTile : ITile
    {
        public static Texture2D Sprite { get; set; }

        public static RandomJewelGenerator randomJewelGenerator { get; set; }

        private Jewel _jewel;

        public Jewel jewel
        {
            get
            {
                if(_jewel == null)
                {
                    _jewel = randomJewelGenerator.NextRandom;
                }
                return _jewel;
            }
            set
            {
                _jewel = value;
            }
        }

        public void Accept(ITileVisitor visitor)
        {
            visitor.visit(this);
        }

        public void Clear()
        {
            _jewel?.Clear();
            _jewel = null;
        }

        public Texture2D GetSprite()
        {
            return Sprite;
        }

        public IAnimation GetJewelFromPreviousTile(Point ownIndex, GameTime gameTime, Point gemSize)
        {
            return null;
        }
    }
}
