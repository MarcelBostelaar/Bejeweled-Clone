using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone.Model.Jewels.SpecialPowers
{
    interface SpecialPower
    {
        bool CanClearWith(Jewel jewel);
        Func<Jewel, Point, bool> ReturnSpecialActionWith(Jewel jewel, Point ownPosition);
        Func<Jewel, Point, bool> ReturnClearAction(Point OwnPosition);
        bool CanDoSpecialActionWith(Jewel jewel);
    }
}
