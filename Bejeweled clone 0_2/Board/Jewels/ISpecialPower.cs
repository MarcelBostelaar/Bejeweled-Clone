using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone_0_2.Board.Jewels
{
    interface ISpecialPower
    {
        bool CanClearWith(Jewel jewel);
        bool CanDoSpecialActionWith(Jewel jewel);
    }
}
