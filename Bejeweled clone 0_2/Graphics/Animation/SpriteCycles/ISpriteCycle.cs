using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone_0_2.Graphics.Animation.SpriteCycles
{
    interface ISpriteCycle
    {
        void Draw(GameTime gameTime, SpriteBatch spriteBatch, Rectangle drawRectangle);
    }
}
