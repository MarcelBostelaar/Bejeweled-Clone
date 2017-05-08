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
    class CalculateClearingState : AbstractState
    {
        IPlayBoard playBoard;
        public CalculateClearingState(IPlayBoard playBoard, StateManager ownManager, ClickableTextureTargetWrapper wrapper) : base(ownManager, wrapper)
        {
            this.playBoard = playBoard;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
        }

        public override void OnPush(GameTime gameTime)
        {
            var collections = playBoard.ClearUpdate(gameTime);
            //do points
            HashSet<Point> allpoints = new HashSet<Point>();
            foreach (var set in collections)
            {
                foreach (var i in set)
                {
                    allpoints.Add(i);
                    playBoard.GetTile(i).jewel = null;
                }
            }
            List<IAnimation> animations = new List<IAnimation>();
            foreach (var i in allpoints)
            {
                animations.Add(new ClearingAnimation(i * playBoard.TileSize, playBoard.TileSize, gameTime));
            }
            if (animations.Count == 0)
            {
                stateManager.ChangeState(new BoardUserInputState(playBoard, stateManager, wrapper, gameTime), gameTime);
            }
            else {
                var alljewels = playBoard.GetAllJewels(ClearingAnimation.Duration, gameTime);
                foreach (var i in alljewels)
                    animations.Add(i.Item2);
                stateManager.ChangeState(new AnimationState(playBoard, stateManager, wrapper, animations, new DropCalculation(playBoard, stateManager, wrapper)), gameTime);
            }
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
