using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Bejeweled_clone_0_2.Board;
using Bejeweled_clone_0_2.Graphics;
using Bejeweled_clone_0_2.Graphics.Animation;
using Bejeweled_clone_0_2.Board.Jewels;

namespace Bejeweled_clone_0_2.States
{
    class DroppingCalculationState : AbstractState
    {
        const long animationDuration = 50000000;
        public DroppingCalculationState(IPlayBoard playBoard, RelativeRenderTarget playboardRenderTarget, StateManager stateManager) : base(playBoard, playboardRenderTarget, stateManager)
        {

        }

        public override void Update(GameTime gameTime)
        {
        }
        
        public override void OnPush(GameTime gameTime)
        {
            var i = playBoard.DropCalculationUpdate();
            if(i.Any())
            {
                List<IAnimation> FinalAnimations = new List<IAnimation>();

                var allTiles = playBoard.GetAllTiles();
                foreach (var tile in allTiles)
                {
                    FinalAnimations.Add(new LimitedTimeAnimation(new NonMovingAnimation(tile.Item2.GetSpriteCycle(), 1, (playBoard.boardSize.ToVector2() * tile.Item1.ToVector2()), new Vector2(1) / playBoard.boardSize.ToVector2()), animationDuration, gameTime));
                }
                
                                //jewels

                var allJewels = playBoard.GetAllJewels();
                var unmovedJewels = new List<Tuple<Point, Jewel>>();
                
                HashSet<Point> movedJewels = new HashSet<Point>();
                foreach (var movement in i)
                    movedJewels.Add(movement.Item2);
                foreach(var jewel in allJewels)
                {
                    if (!movedJewels.Contains(jewel.Item1))
                        unmovedJewels.Add(jewel);
                }
                    
                foreach(var jewel in unmovedJewels)
                {
                    FinalAnimations.Add(new LimitedTimeAnimation(new NonMovingAnimation(jewel.Item2.animation, 5, (playBoard.boardSize.ToVector2() * jewel.Item1.ToVector2()), new Vector2(1) / playBoard.boardSize.ToVector2()), animationDuration, gameTime));
                }

                //add jewel movement animations


                FinalAnimations.Sort();
                playboardRenderTarget.animations = FinalAnimations;

                stateManager.ChangeState(new AnimationState(playboardRenderTarget, stateManager, () => this), gameTime);
            }
            else
            {
                //clearing state
                Console.WriteLine("Clearing state");
            }
        }
    }
}
