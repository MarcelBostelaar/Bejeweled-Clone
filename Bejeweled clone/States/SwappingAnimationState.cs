using Bejeweled_clone.Animation;
using Bejeweled_clone.Model;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone.States
{
    class SwappingAnimationState : AnimationState
    {
        readonly static long Duration = GemMovementAnimation.duration;
        public SwappingAnimationState(Point first, Point second, IPlayBoard playBoard, StateManager ownManager, ClickableTextureTargetWrapper wrapper, IState nextState, GameTime gameTime) : base(playBoard, ownManager, wrapper, SwappingAnimationState.GetConstructorAnimations(first, second, playBoard, gameTime), nextState)
        {
            var firstjewel = playBoard.GetTile(first).jewel;
            playBoard.GetTile(first).jewel = playBoard.GetTile(second).jewel;
            playBoard.GetTile(second).jewel = firstjewel;
        }

        private static List<IAnimation> GetConstructorAnimations(Point first, Point second, IPlayBoard playBoard, GameTime gameTime)
        {
            var alljewels = playBoard.GetAllJewels(Duration, gameTime);
            List<IAnimation> animations = new List<IAnimation>();
            foreach (var i in alljewels)
                if (i.Item1 != first && i.Item1 != second)
                    animations.Add(i.Item2);
            animations.Add(new GemMovementAnimation(first * playBoard.TileSize, second * playBoard.TileSize, playBoard.GetTile(first).jewel.sprite, playBoard.TileSize, gameTime));
            animations.Add(new GemMovementAnimation(second * playBoard.TileSize, first * playBoard.TileSize, playBoard.GetTile(second).jewel.sprite, playBoard.TileSize, gameTime));
            return animations;
        }
    }
}
