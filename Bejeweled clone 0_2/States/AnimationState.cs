using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Bejeweled_clone_0_2.Graphics;
using Bejeweled_clone_0_2.Board;

namespace Bejeweled_clone_0_2.States
{
    class AnimationState : IState
    {
        Func<IState> nextState;
        RelativeRenderTarget playboardRenderTarget;
        StateManager stateManager;

        /// <summary>
        /// Creates a new animationstate that will transition to the new state that results from the func once all the amount of animations in the rendertarget is 0.
        /// </summary>
        /// <param name="relativeRenderTarget">The relative render target which it animates.</param>
        /// <param name="stateManager">The state manager which to transition to.</param>
        /// <param name="nextState">The func that gives the next state.</param>
        public AnimationState(RelativeRenderTarget relativeRenderTarget, StateManager stateManager, Func<IState> nextState)
        {
            this.nextState = nextState;
        }

        public void OnPush(GameTime gameTime)
        {
        }

        public void Update(GameTime gameTime)
        {
            if (playboardRenderTarget.animations.Count() == 0)
                stateManager.ChangeState(nextState(), gameTime);
        }
    }
}
