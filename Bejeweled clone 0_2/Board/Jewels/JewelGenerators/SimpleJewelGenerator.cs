using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone_0_2.Board.Jewels.JewelGenerators
{
    class SimpleJewelGenerator : IJewelGenerator
    {
        Random rng;
        public SimpleJewelGenerator()
        {
            rng = new Random((int)DateTime.Now.Ticks);
        }

        public Jewel Next
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
