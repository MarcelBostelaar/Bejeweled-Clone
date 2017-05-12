using Bejeweled_clone_0_2.Graphics.Animation;
using Bejeweled_clone_0_2.Graphics.Animation.SpriteCycles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone_0_2.Board.Jewels
{
    static class JewelFactory
    {
        public enum Jewels
        {
            NormalRed,
            NormalBlue,
            NormalYellow,
            NormalGreen,
            NormalPurple,
            NormalOrange
        }
        private const int defaultPoints = 10;
        public static void Intitialize()
        {
            SetColourGroup(Jewels.NormalBlue, ColourGroup.Blue);
            SetColourGroup(Jewels.NormalGreen, ColourGroup.Green);
            SetColourGroup(Jewels.NormalOrange, ColourGroup.Orange);
            SetColourGroup(Jewels.NormalPurple, ColourGroup.Purple);
            SetColourGroup(Jewels.NormalRed, ColourGroup.Red);
            SetColourGroup(Jewels.NormalYellow, ColourGroup.Yellow);

            SetPoints(Jewels.NormalBlue, defaultPoints);
            SetPoints(Jewels.NormalGreen, defaultPoints);
            SetPoints(Jewels.NormalOrange, defaultPoints);
            SetPoints(Jewels.NormalPurple, defaultPoints);
            SetPoints(Jewels.NormalRed, defaultPoints);
            SetPoints(Jewels.NormalYellow, defaultPoints);

            SetSpecialPower(Jewels.NormalBlue, new NoSpecialPower());
            SetSpecialPower(Jewels.NormalGreen, new NoSpecialPower());
            SetSpecialPower(Jewels.NormalOrange, new NoSpecialPower());
            SetSpecialPower(Jewels.NormalPurple, new NoSpecialPower());
            SetSpecialPower(Jewels.NormalRed, new NoSpecialPower());
            SetSpecialPower(Jewels.NormalYellow, new NoSpecialPower());
        }

        private static ISpriteCycle[] spriteCycles = new ISpriteCycle[Enum.GetNames(typeof(Jewels)).Length];
        private static ColourGroup[] colourGroups = new ColourGroup[Enum.GetNames(typeof(Jewels)).Length];
        private static ISpecialPower[] specialPowers = new ISpecialPower[Enum.GetNames(typeof(Jewels)).Length];
        private static int[] points = new int[Enum.GetNames(typeof(Jewels)).Length];

        public static Jewel GetJewel(Jewels type)
        {
            return new Jewel(points[(int)type], colourGroups[(int)type], specialPowers[(int)type], spriteCycles[(int)type]);
        }

        public static void SetAnimation(Jewels jewelType, ISpriteCycle animation)
        {
            spriteCycles[(int)jewelType] = animation;
        }
        public static ISpriteCycle GetAnimation(Jewels jewelType)
        {
            return spriteCycles[(int)jewelType];
        }

        private static void SetSpecialPower(Jewels jewelType, ISpecialPower power)
        {
            specialPowers[(int)jewelType] = power;
        }

        private static void SetColourGroup(Jewels jewelType, ColourGroup colourGroup)
        {
            colourGroups[(int)jewelType] = colourGroup;
        }

        private static void SetPoints(Jewels jewelType, int points)
        {
            JewelFactory.points[(int)jewelType] = points;
        }
    }
}
