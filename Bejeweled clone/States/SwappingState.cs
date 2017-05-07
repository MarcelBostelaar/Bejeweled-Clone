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
        List<IAnimation> animations;
        public SwappingState(IPlayBoard playBoard, StateManager ownManager, ClickableTextureTargetWrapper wrapper, Point first, Point second, GameTime gameTime) : base(ownManager, wrapper)
        {
            this.playBoard = playBoard;
            this.first = first;
            this.second = second;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            if(animations == null)
            {
                var i = playBoard.GetAllJewels(long.MaxValue / 2, gameTime);
                animations = new List<IAnimation>();
                foreach (var j in i)
                {
                    animations.Add(j.Item2);
                }
            }
            playBoard.Draw(gameTime, animations);
            graphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            wrapper.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            if(playBoard.CanSwap(first, second))
            {
                throw new NotImplementedException();
                //Go to special state, then from that to clearing state
            }
            else
            {
                if(playBoard.ClearUpdate(gameTime).Count > 0)
                {
                    stateManager.ChangeState(new CalculateClearingState(playBoard, stateManager, wrapper));
                }
                else
                {
                    stateManager.ChangeState(new SwappingAnimationState(first, second, playBoard, stateManager, wrapper, new BoardUserInputState(playBoard, stateManager, wrapper), gameTime));
                }
            }
        }
    }
}
