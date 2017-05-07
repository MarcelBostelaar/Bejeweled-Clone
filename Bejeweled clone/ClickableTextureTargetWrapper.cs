using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Bejeweled_clone.Input;

namespace Bejeweled_clone
{
    class ClickableTextureTargetWrapper : Interfaces.ISimpleDraw
    {
        public ClickableTextureTargetWrapper(ClickableTextureTarget texture)
        {
            childTexture = texture;
        }
        ClickableTextureTarget childTexture;
        public int drawHeight { get; set; }
        public Point drawPosition { get; set; }
        public int drawWidth { get; set; }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var rect = new Rectangle(drawPosition, new Point(drawWidth, drawHeight));
            spriteBatch.Draw(childTexture.texture, rect, Color.White);
        }

        public void DetectMouseClick()
        {
            if (MouseUtils.WentDown(MouseUtils.MouseButtons.Left))
            {
                var position = MouseUtils.GetCurrentPosition().ToVector2();
                position -= drawPosition.ToVector2();
                position /= new Vector2(drawWidth, drawHeight);
                if (position.X >= 0 && position.X < 1 && position.Y >= 0 && position.Y < 1)
                {
                    childTexture.AddClick(position);
                }
            }
        }
    }
}
