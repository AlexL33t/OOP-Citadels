using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Architect: Person
    {
        public Architect()
        {
            Rank = 6;
        }

        [InfoAct(Name="", Time = 6)]
        void GetQuartersForArchitect(Player architect, GameField field)
        {
            var quarters = field.TakeQuartersFromDeck(2);
            field.TakeQuartersOnHand(architect, quarters);
        }
    }
}
