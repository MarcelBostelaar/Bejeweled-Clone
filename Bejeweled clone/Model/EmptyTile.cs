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
    class EmptyTile : ITile
    {
        public void Accept(ITileVisitor visitor)
        {
            visitor.visit(this);
        }
        
        public Texture2D GetSprite()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
        }

        public IAnimation GetJewelFromPreviousTile(Point ownIndex, GameTime gameTime, Point gemSize)
        {
            throw new NotImplementedException();
        }

        public Jewel jewel { get { return null; } set { return; } }
    }
}
