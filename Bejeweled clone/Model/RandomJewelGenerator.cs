using Bejeweled_clone.Model.Jewels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone.Model
{
    interface RandomJewelGenerator
    {
        Jewel NextRandom { get; }
    }
}
