using Bejeweled_clone_0_2.Graphics.Animation;
using Bejeweled_clone_0_2.Graphics.Animation.SpriteCycles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone_0_2.Board.Jewels
{
    class Jewel
    {
        /// <summary>
        /// The number of of points this jewel is worth.
        /// </summary>
        public int points { get; private set; }
        /// <summary>
        /// The IAnimation of this jewel.
        /// </summary>
        public ISpriteCycle animation { get; private set; }

        ColourGroup colourGroup;
        ISpecialPower specialPower;

        /// <summary>
        /// Creates a new Jewel instance.
        /// </summary>
        /// <param name="points">The amounts of points that this jewel is worth.</param>
        /// <param name="colourGroup">The colourgroup of this jewel.</param>
        /// <param name="specialPower">The special power of this jewel.</param>
        /// <param name="animation">The Ianimation that this jewel has.</param>
        public Jewel(int points, ColourGroup colourGroup, ISpecialPower specialPower, ISpriteCycle animation)
        {
            this.animation = animation;
            this.points = points;
            this.colourGroup = colourGroup;
            this.specialPower = specialPower;
        }

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
        /// Tests if two jewels could clear together.
        /// </summary>
        /// <param name="jewel"></param>
        /// <returns>A boolean indicating if these two jewels could clear together</returns>
        public bool CanClearWith(Jewel jewel)
        {
            if (colourGroup == jewel.colourGroup)
                return true;
            if (specialPower.CanClearWith(jewel) || jewel.specialPower.CanClearWith(this))
                return true;
            return false;
        }
    }
}
