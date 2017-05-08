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
    class BoardUserInputState : AbstractState
    {
        IPlayBoard playBoard;
        AnimationContainer animations;
        public BoardUserInputState(IPlayBoard playBoard,StateManager ownManager, ClickableTextureTargetWrapper wrapper, GameTime gameTime) : base (ownManager, wrapper)
        {
            this.playBoard = playBoard;
            animations = new AnimationContainer();
            animations.AddAnimations(playBoard.GetAllTiles(long.MaxValue / 2, gameTime));
            animations.AddAnimations(playBoard.GetAllJewels(long.MaxValue / 2, gameTime));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            playBoard.Draw(gameTime, animations.Animations);
            animations.Clean(gameTime);
            graphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            wrapper.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }

        public override void OnPush(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            wrapper.DetectMouseClick();
            if (playBoard.UserInputUpdate(gameTime))
            {
                var i = playBoard.GetSelectedTiles();
                if (i == null)
                    throw new Exception();
                stateManager.ChangeState(new SwappingAnimationState(i.Item1, i.Item2, playBoard, stateManager, wrapper, new SwappingState(playBoard, stateManager, wrapper, i.Item1, i.Item2, gameTime), gameTime), gameTime);
            }
        }
    }
}
