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
        const int DefaultValue = 10;

        public static Texture2D NormalRedGem, NormalBlueGem, NormalYellowGem, NormalGreenGem, NormalPurpleGem, NormalOrangeGem;

        public enum FactoryJewels
        {
            NormalRed,
            NormalBlue,
            NormalYellow,
            NormalGreen,
            NormalPurple,
            NormalOrange
        }

        public static Jewel GetJewel(FactoryJewels jeweltype)
        {
            switch (jeweltype)
            {
                case FactoryJewels.NormalBlue:
                    return new Jewel(DefaultValue, ColourGroup.Blue, new SpecialPowers.NoSpecialPower(), NormalBlueGem);
                case FactoryJewels.NormalRed:
                    return new Jewel(DefaultValue, ColourGroup.Red, new SpecialPowers.NoSpecialPower(), NormalRedGem);
                case FactoryJewels.NormalYellow:
                    return new Jewel(DefaultValue, ColourGroup.Yellow, new SpecialPowers.NoSpecialPower(), NormalYellowGem);
                case FactoryJewels.NormalPurple:
                    return new Jewel(DefaultValue, ColourGroup.Purple, new SpecialPowers.NoSpecialPower(), NormalPurpleGem);
                case FactoryJewels.NormalGreen:
                    return new Jewel(DefaultValue, ColourGroup.Green, new SpecialPowers.NoSpecialPower(), NormalGreenGem);
                case FactoryJewels.NormalOrange:
                    return new Jewel(DefaultValue, ColourGroup.Orange, new SpecialPowers.NoSpecialPower(), NormalOrangeGem);
            }
            throw new NotImplementedException();
        }
    }
}
