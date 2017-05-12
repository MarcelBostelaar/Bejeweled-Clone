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
                switch (rng.Next(0, 6))
                {
                    case 0:
                        return JewelFactory.GetJewel(JewelFactory.Jewels.NormalBlue);
                    case 1:
                        return JewelFactory.GetJewel(JewelFactory.Jewels.NormalGreen);
                    case 2:
                        return JewelFactory.GetJewel(JewelFactory.Jewels.NormalOrange);
                    case 3:
                        return JewelFactory.GetJewel(JewelFactory.Jewels.NormalPurple);
                    case 4:
                        return JewelFactory.GetJewel(JewelFactory.Jewels.NormalRed);
                    case 5:
                        return JewelFactory.GetJewel(JewelFactory.Jewels.NormalYellow);
                }
                return null;
            }
        }
    }
}
