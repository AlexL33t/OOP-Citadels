using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    class AddingMoneyToBank : Act
    {
        public AddingMoneyToBank(Player player, Person person, GameField field) :
            base(player, person, field) { }

        public override void Do(int[] choice, List<object> answ, Flags flags)
        {
            field.AddMoneyToBank(player, 2);
            flags.MainActionDone = true;
        }

        public override List<object> GetParameters()
        {
            return null;
        }

        public override InfoAct Info
        {
            get { return new InfoAct() { Name = "Взять два золотых из банка" }; }
        }
    }
}