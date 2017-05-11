using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone_0_2.Board.Jewels
{
    class NoSpecialPower : ISpecialPower
    {
        public bool CanClearWith(Jewel jewel)
        {
            return false;
        }

        public bool CanDoSpecialActionWith(Jewel jewel)
        {
            return false;
        }
    }
}
