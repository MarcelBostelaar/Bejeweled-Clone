using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone.Model
{
    interface ITileVisitor
    {
        void visit(EmptyTile tile);
        void visit(NormalTile tile);
        void visit(JewelGeneratingTile tile);
    }
}
