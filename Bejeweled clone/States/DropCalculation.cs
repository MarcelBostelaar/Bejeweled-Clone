using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Bejeweled_clone.Model;
using Bejeweled_clone.Animation;

namespace Bejeweled_clone.States
{
    class DropCalculation : AbstractState
    {
        IPlayBoard playBoard;
        public DropCalculation(IPlayBoard playBoard, StateManager ownManager, ClickableTextureTargetWrapper wrapper) : base(ownManager, wrapper)
        {
            this.playBoard = playBoard;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
        }

        public override void OnPush(GameTime gameTime)
        {
            List<IAnimation> list = new List<IAnimation>();
            if (!playBoard.DropCalculationUpdate(gameTime, list))
            {
                stateManager.ChangeState(new CalculateClearingState(playBoard, stateManager, wrapper), gameTime);
            }
            else
            {
                stateManager.ChangeState(new AnimationState(playBoard, stateManager, wrapper, list, this), gameTime);
            }
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
