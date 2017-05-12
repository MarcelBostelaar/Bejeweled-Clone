using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Bejeweled_clone_0_2.Board;
using Bejeweled_clone_0_2.Graphics;

namespace Bejeweled_clone_0_2.States
{
    class DroppingCalculationState : AbstractState
    {
        public DroppingCalculationState(IPlayBoard playBoard, RelativeRenderTarget playboardRenderTarget, StateManager stateManager) : base(playBoard, playboardRenderTarget, stateManager)
        {

        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
        }

        public override void OnPush(GameTime gameTime)
        {
            var i = playBoard.DropCalculationUpdate();
            if(i.Count() > 0)
            {
                //animation state
            }
            else
            {
                //clearing state
            }
        }
    }
}
