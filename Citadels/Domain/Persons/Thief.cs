using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Thief : Person
    {
        public Thief()
        {
            Rank = 2;
        }

        public void TakeMoneyFromPerson(Player player, Choice choice, GameField field)
        {
            if (choice.Person == field.Killed || choice.Person is Assassin)
                throw new Exception("");
            var newPlayer = new Player();

            int money = field.ShowBankState(player);
            field.TakeMoneyFromBank(newPlayer, money);
            field.AddMoneyInBank(player, money);
        }

    }
}
