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
    class SwappingState : AbstractState
    {
        IPlayBoard playBoard;
        Point first, second;
        public SwappingState(IPlayBoard playBoard, StateManager ownManager, ClickableTextureTargetWrapper wrapper, Point first, Point second, GameTime gameTime) : base(ownManager, wrapper)
        {
            this.playBoard = playBoard;
            this.first = first;
            this.second = second;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void OnPush(GameTime gameTime)
        {
            if (playBoard.CanSwap(first, second))
            {
                throw new NotImplementedException();
                //Go to special state, then from that to clearing state
            }
            else
            {
                if (playBoard.ClearUpdate(gameTime).Count > 0)
                {
                    stateManager.ChangeState(new CalculateClearingState(playBoard, stateManager, wrapper), gameTime);
                }
                else
                {
                    stateManager.ChangeState(new SwappingAnimationState(first, second, playBoard, stateManager, wrapper, new BoardUserInputState(playBoard, stateManager, wrapper, gameTime), gameTime), gameTime);
                }
            }
        }
    }
}
