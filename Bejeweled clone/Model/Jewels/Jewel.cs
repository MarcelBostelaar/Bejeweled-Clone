using Bejeweled_clone.Model.Jewels.SpecialPowers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone.Model.Jewels
{
    partial class Jewel
    {
        public Texture2D sprite { get; private set; }
        private Jewel(int points, ColourGroup colourGroup, SpecialPower specialPower, Texture2D sprite)
        {
            this.sprite = sprite;
            this.colourGroup = colourGroup;
            this.specialPower = specialPower;
            this.points = points;
        }
        public int points { get; private set; }
        ColourGroup colourGroup;
        SpecialPower specialPower;
        /// <summary>
        /// Test if two swapped jewels can do a special action together.
        /// </summary>
        /// <param name="jewel"></param>
        /// <returns>A boolean indicating if these two jewels can do a special action together.</returns>
        public bool CanDoSpecialActionWith(Jewel jewel)
        {
            if (specialPower.CanDoSpecialActionWith(jewel) || jewel.specialPower.CanDoSpecialActionWith(this))
                return true;
            return false;
        }
        /// <summary>
        /// Returns a function of this jewels special action that can be excecuted on the board, in relation to another jewel it interacts with.
        /// </summary>
        /// <param name="jewel"></param>
        /// <param name="position"></param>
        /// <returns>A function of this jewels special action that can be excecuted on the board.</returns>
        Func<Jewel, Point, bool> ReturnSpecialActionWith(Jewel jewel, Point ownPosition)
        {
            return specialPower.ReturnSpecialActionWith(jewel, ownPosition);
        }
        /// <summary>
        /// Returns a function of this jewels special power for being cleared.
        /// </summary>
        /// <param name="position"></param>
        /// <returns>A function of this jewels special power for being cleared.</returns>
        Func<Jewel, Point, bool> ReturnClearAction(Point ownPosition)
        {
            return specialPower.ReturnClearAction(ownPosition);
        }
        /// <summary>
        /// Tests if two jewels could clear together.
        /// </summary>
        /// <param name="jewel"></param>
        /// <returns>A boolean indicating if these two jewels could clear together</returns>
        public bool CanClearWith(Jewel jewel)
        {
            if(colourGroup == jewel.colourGroup)
                return true;
            if (specialPower.CanClearWith(jewel) || jewel.specialPower.CanClearWith(this))
                return true;
            return false;
        }
        public void Clear()
        {
            
        }
    }
}
