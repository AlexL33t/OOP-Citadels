using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class King : Person
    {
        public King()
        {
            Rank = 4;
            Color = QuarterColor.Yellow;
        }

        void Сoronation(Player king, GameField field)
        {
            field.Crown(king);
        }
    }
}
