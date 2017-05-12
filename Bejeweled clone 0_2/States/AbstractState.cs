using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Bejeweled_clone_0_2.Board;
using Bejeweled_clone_0_2.Graphics;

namespace Bejeweled_clone_0_2.States
{
    abstract class AbstractState : IState
    {
        protected IPlayBoard playBoard;
        protected RelativeRenderTarget playboardRenderTarget;
        protected StateManager stateManager;
        public AbstractState(IPlayBoard playBoard, RelativeRenderTarget playboardRenderTarget, StateManager stateManager)
        {
            this.playBoard = playBoard;
            this.playboardRenderTarget = playboardRenderTarget;
            this.stateManager = stateManager;
        }
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice);
        public abstract void OnPush(GameTime gameTime);
    }
}
