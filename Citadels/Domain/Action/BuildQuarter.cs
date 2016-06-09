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

        public override void Do(int[] indices, List<object> answ, Flags flags)
        {
            if (person.MaxCountOfTakenQuartersFromDeck < indices.Length)
                throw new Exception("");

            var quarter = field.TakeSeveralQuartersFromHand(player, indices);
            var sum = quarter
                .Select(q => q.Cost)
                .Sum();
            if (sum > field.ShowBankState(player))
                throw new Exception("");
            field.TakeMoneyFromBank(player, sum);
            quarter.ForEach(q => field.BuildQuarterInCity(player, q));
            flags.BuildedQuarter = true;

        }

        public override List<object> GetParameters()
        {
            return new List<object>(field.ShowQuarterOnHand(player));
        }

        public override InfoAct Info
        {
            get { return new InfoAct() { Name = "Построить квартал" }; }
        }
    }
}