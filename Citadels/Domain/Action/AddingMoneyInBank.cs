using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    class AddingMoneyInBank : Act
    {
        public AddingMoneyInBank(Player player, Person person, GameField field) :
            base(player, person, field) { }

        public override void Do(int[] choice, List<object> answ, Flags flags)
        {
            field.AddMoneyInBank(player, 2);
            flags.MainActionDone = true;
        }

        public override List<object> GetParam()
        {
            return null;
        }

        public override InfoAct Info
        {
            get { return new InfoAct() { Name = "" }; }
        }
    }
}
