using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bejeweled_clone_0_2.Graphics.Animation.SpriteCycles
{
    class ContinuousMultiTextureCycle : ISpriteCycle
    {
        long totalTime = 0;
        List<Texture2D> textures;
        List<long> timespans;
        /// <summary>
        /// Creates a new continuous multi texture sycle
        /// </summary>
        /// <param name="spritesAndTime">Ordered enumerable of tuples. The long is the time in ticks (100 nanometers) that this sprite should last.</param>
        public ContinuousMultiTextureCycle(IEnumerable<Tuple<Texture2D, long>> spritesAndTime)
        {
            textures = new List<Texture2D>();
            timespans = new List<long>();
            foreach (var item in spritesAndTime)
            {
                totalTime += item.Item2;
                timespans.Add(totalTime);
                textures.Add(item.Item1);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Rectangle drawRectangle)
        {
            long normalizedTimeSpan = gameTime.TotalGameTime.Ticks % totalTime;
            int index = 0;
            while (timespans[index] < normalizedTimeSpan)
                index++;
            Texture2D texture = textures[index];

            spriteBatch.Draw(texture, drawRectangle, Color.White);
        }
    }
}
