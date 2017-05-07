using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Bejeweled_clone.Model.Jewels.SpecialPowers
{
    class NoSpecialPower : SpecialPower
    {
        public bool CanClearWith(Jewel jewel)
        {
            return false;
        }

        public bool CanDoSpecialActionWith(Jewel jewel)
        {
            return false;
        }

        public Func<Jewel, Point, bool> ReturnClearAction(Point OwnPosition)
        {
            return (x, y) => { return false; };
        }

        public Func<Jewel, Point, bool> ReturnSpecialActionWith(Jewel jewel, Point ownPosition)
        {
            return (x, y) => { return false; };
        }
    }
}
