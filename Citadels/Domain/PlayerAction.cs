using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class PlayerAction
    {
        List<Choice> choices;

        private bool isMoneyTaken;
        private bool isQuarterTaken;
        private bool isPersonChosen;
        private bool isIncomeTaken;

        public bool Finished = false;

        public PlayerAction()
        {
            isMoneyTaken = false;
            isQuarterTaken = false;
            isPersonChosen = false;
            isIncomeTaken = false;
        }

        public void AddChoice(Choice choice, Round round)
        {
            choices.Add(choice);
        }

        public bool GetPossibleAction(Round round)
        {
            return false;
        }

        void BuildQuarter(GameField field, Player player, int index)
        {
            var quarter = field.TakeOneQuarterFromHand(player, index);
            if (quarter.Cost > field.ShowBankState(player))
                throw new Exception("");
            field.TakeMoneyFromBank(player, quarter.Cost);
            field.BuildQuarterInCity(player, quarter);
        }

        void GetMoneyFromQuarters(Player currentPlayer, Round currentRound, GameField field) // city, income, bank
        {
            var person = currentRound.GetPersonOfPlayer(currentPlayer);
            var money = field
                .ShowCity(currentPlayer)
                .Where(quarter => quarter.Color == person.Color)
                .Count() * field.ShowIncome();
            field.AddMoneyToBank(currentPlayer, money); ///
        }
    }
}
