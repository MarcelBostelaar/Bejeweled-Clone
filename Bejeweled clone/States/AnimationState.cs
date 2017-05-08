using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Bejeweled_clone.Animation;
using Bejeweled_clone.Model;

namespace Bejeweled_clone.States
{
    class AnimationState : AbstractState
    {
        public AnimationState(IPlayBoard playBoard, StateManager ownManager, ClickableTextureTargetWrapper wrapper, List<IAnimation> animations, IState nextState) : base(ownManager, wrapper)
        {
            this.animations = animations;
            this.playBoard = playBoard;
            this.nextState = nextState;
        }
        IState nextState;
        List<IAnimation> animations;
        IPlayBoard playBoard;
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            playBoard.Draw(gameTime, animations);
            graphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            wrapper.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            var newlist = new List<IAnimation>();
            foreach(var i in animations)
            {
                if (!i.Done(gameTime))
                    newlist.Add(i);
            }
            if (newlist.Count == 0)
                stateManager.ChangeState(nextState,gameTime);
            animations = newlist;
        }

        public override void OnPush(GameTime gameTime)
        {
        }
    }
}
