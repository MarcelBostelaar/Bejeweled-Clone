using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone.Animation
{
    class StaticBoardTile : StaticSprite
    {
        public StaticBoardTile(Point coordinates, Texture2D sprite, Point size, GameTime gameTime, long duration) : base(coordinates, sprite, size, gameTime, duration, 1)
        {

        }
    }
}
