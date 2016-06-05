using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Warlord : Person
    {
        public Warlord()
        {
            Rank = 8;
        }

        void DestroyQuarter(Player warlord, Choice choice, GameField field)
        {
            if (choice.Quarters[0].Cost > field.ShowBankState(warlord) + 1)
                throw new Exception("");

            field.TakeMoneyFromBank(warlord, choice.Quarters[0].Cost - 1);
            var destroyedQuarter = field.DestroyQuarterInCity(choice.Player, choice.i);
            //???
        }
    }
}
