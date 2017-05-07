using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bejeweled_clone.Model.Jewels;

namespace Bejeweled_clone.Model.RandomJewelGenerators
{
    class SimpleJewelGenerator : RandomJewelGenerator
    {
        Random rng = new Random((int)DateTime.Now.Ticks);
        public SimpleJewelGenerator()
        {
        }

        public Jewel NextRandom
        {
            get
            {
                switch (rng.Next(0, 6))
                {
                    case 0:
                        return Jewel.GetJewel(Jewel.FactoryJewels.NormalBlue);
                    case 1:
                        return Jewel.GetJewel(Jewel.FactoryJewels.NormalRed);
                    case 2:
                        return Jewel.GetJewel(Jewel.FactoryJewels.NormalYellow);
                    case 3:
                        return Jewel.GetJewel(Jewel.FactoryJewels.NormalPurple);
                    case 4:
                        return Jewel.GetJewel(Jewel.FactoryJewels.NormalGreen);
                    case 5:
                        return Jewel.GetJewel(Jewel.FactoryJewels.NormalOrange);
                }
                return null;
            }
        }
    }
}
