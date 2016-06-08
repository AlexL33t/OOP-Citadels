using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    class BuildQuarter : Act
    {
        public BuildQuarter(Player player, Person person, GameField field) :
            base(player, person, field) { }
        public override void Do(int[] indexs, List<object> answ, Flags flags)
        {
            if (person.MaxCountOfTakenQuartersFromDeck < indexs.Length)
                throw new Exception("");

            var quarter = field.TakeQuartersFromHand(player, indexs);
            var sum = quarter.Select(q => q.Cost).Sum();
            if (sum > field.ShowBankState(player))
                throw new Exception("");
            field.TakeMoneyFromBank(player, sum);
            quarter.ForEach(q => field.BuildQuarterInCity(player, q));
            flags.BuildedQuarter = true;

        }

        public override List<object> GetParam()
        {
            return new List<object>(field.ShowQuarterInHand(player));
        }

        public override InfoAct Info
        {
            get { return new InfoAct() { Name = "" }; }
        }
    }
}
