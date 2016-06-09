using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Bishop : Person
    {
        public Bishop()
        {
            Rank = 5;
            Color = QuarterColor.Blue;
        }

        public override List<Act> GetPossibleActons(Player player, Person person, Flags flags, GameField field)
        {
            return new List<Act>();
        }
    }
}
