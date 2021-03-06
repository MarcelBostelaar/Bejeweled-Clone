﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone.States
{
    class StateManager
    {
        List<IState> CurrentStates = new List<IState>();
        public IState ChangeState(IState newState)
        {
            var i = PopState();
            PushState(newState);
            return i;
        }
        public IState PopState()
        {
            if(CurrentStates.Count > 0)
            {
                var i = CurrentStates.Last();
                CurrentStates.RemoveAt(CurrentStates.Count - 1);
                return i;
            }
            return null;
        }

        public void PushState(IState newState)
        {
            CurrentStates.Add(newState);
        }

        public IState GetTopState()
        {
            if (CurrentStates.Count > 0)
                return CurrentStates[CurrentStates.Count - 1];
            return null;
        }

        public void Update(GameTime gameTime)
        {
            var state = GetTopState();
            state?.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            var state = GetTopState();
            state?.Draw(gameTime, spriteBatch, graphicsDevice);
        }
    }
}
