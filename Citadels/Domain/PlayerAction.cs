using System;
using System.Collections.Generic;
using System.Linq;

namespace Citadels.Domain
{
    public class PlayerAction
    {
        #region

        private Player player;
        private Person person;
        private GameField field;
        Flags flags; 

        private List<object> answ;
        private int runningAction = -1;

        private List<Act> actions;

        public bool Finished { get { return actions.Count == 0; } }

        public PlayerAction(Player player, Person person, GameField field)
        {
            this.person = person;
            this.player = player;
            this.field = field;
            flags = new Flags();
            actions = GetActions();
        }
        #endregion

        public void AddChoice(int[] choice)
        {
            if (Finished) throw new Exception("");
            if (runningAction == -1) throw new Exception("");
            actions[runningAction].Do(choice, answ, flags);
            runningAction = -1;
            actions = GetActions();
        }

        public void ChoiseAction(int i)
        {
            if (Finished) throw new Exception("");
            runningAction = i;
        }

        public List<object> GetParam()
        {
            if (Finished) throw new Exception("");
            if (runningAction == -1) throw new Exception("");
            answ = actions[runningAction].GetParam();
            return answ;
        }

        public List<InfoAct> GetPossibleActions()
        {
            if (Finished)
                throw new Exception("");
            return actions.Select(a => a.Info).ToList();
        }

       
        private List<Act> GetActions()
        {
            actions = new List<Act>();
            if (!flags.MainActionDone)
            {
                actions.Add(new AddingMoneyInBank(player, person, field));
                if (field.CountQuartersInDeck >= 2) actions.Add(new ChooseQuarter(player, person, field));
            }
            else
            {
                int money = field.ShowBankState(player);
                if (!flags.BuildedQuarter && field.ShowQuarterInHand(player).Any(q => q.Cost <= money))
                    actions.Add(new BuildQuarter(player, person, field));
                if (!flags.IncomeTaken && field.ShowCity(player).Any(q => q.Color == person.Color))
                    actions.Add(new GetMoneyFromQuarters(player, person, field));
            }
            if (!flags.AddActionDone)
                person
                    .GetPossibleActons(player, person, flags, field)
                    .ForEach(e => actions.Add(e));

            return actions;
        }
    }
}
