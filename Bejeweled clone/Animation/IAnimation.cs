using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone.Animation
{
    interface IAnimation
    {
        bool Done(GameTime gameTime);
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        long animationTimeSpanTicks { get; }
    }
}
