using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bejeweled_clone.States
{
    abstract class AbstractState : IState
    {
        protected StateManager stateManager;
        protected ClickableTextureTargetWrapper wrapper;
        public AbstractState(StateManager ownManager, ClickableTextureTargetWrapper wrapper)
        {
            stateManager = ownManager;
            this.wrapper = wrapper;
        }
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice);
        public abstract void Update(GameTime gameTime);
    }
}
