//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Citadels.Domain
//{
//    public class Thief : Person
//    {
//        public Thief()
//        {
//            Rank = 2;
//        }

//        void TakeMoneyFromPlayer(Player player, Choice choice, GameField field)
//        {
//            if (choice.Person == field.Killed || choice.Person is Assassin)
//                throw new Exception("");

//            var money = field.ShowBankState(choice.Player);
//            field.TakeMoneyFromBank(choice.Player, money);
//            field.AddMoneyToBank(player, money);
//        }

//    }
//}
