using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    class GetMoneyFromQuarters : Act
    {
        public GetMoneyFromQuarters(Player player, Person person, GameField field) :
            base(player, person, field) { }

        public override void Do(int[] choice, List<object> answ, Flags flags)
        {
            var money = field
                .ShowCity(player)
                .Where(quarter => quarter.Color == person.Color)
                .Count() * field.ShowIncome;
            field.AddMoneyToBank(player, money);
            flags.IncomeTaken = true;
        }

        public override List<object> GetParameters()
        {
            return null;
        }

        public override InfoAct Info
        {
            get { return new InfoAct() { Name = "Получить доход с кварталов" }; }
        }
    }
}