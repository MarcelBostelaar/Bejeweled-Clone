using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Bejeweled_clone_0_2.Graphics.Animation.SpriteCycles;

namespace Bejeweled_clone_0_2.Graphics.Animation
{
    class NonMovingAnimation : AbstractAnimation
    {
        ISpriteCycle spriteCycle;

        public NonMovingAnimation(ISpriteCycle spriteCycle, int zIndex, Vector2 position, Vector2 size) : base(zIndex, position, size)
        {
            this.spriteCycle = spriteCycle;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 parentSize)
        {
            spriteCycle.Draw(gameTime, spriteBatch, new Rectangle((position * parentSize).ToPoint(), (size * parentSize).ToPoint()));
        }
    }
}
