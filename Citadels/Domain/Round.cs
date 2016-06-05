using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Round
    {   
        //public Player HasCrown = null;//
        //public Person Killed = null;//
        
        public bool Finished;
        public bool IsInited { get { return gameField.Players.Count == playerToPerson.Count; } }
        

        private Dictionary<Player, Person> playerToPerson;//
        
        private GameField gameField;
        
        private List<Person> persons;
        private int indexPlayer;
        private List<PlayerAction> playerActions;

        public Round(GameField gameField, Player hasCrown)
        {
            this.gameField = gameField;
            Finished = false;
            persons = new List<Person>(gameField.Persons);
            var i = gameField.Players.IndexOf(gameField.HasCrown);
            indexPlayer = i == -1 ? 0 : i;
        }

        public Person GetPersonOfPlayer(Player player)
        {
            return playerToPerson[player];
        }

        public void CharacterSelection(Player currentPlayer, Choice choice)
        {
            persons.Remove(choice.Person);
            playerToPerson.Add(currentPlayer, choice.Person);
        }

        private void Sorting()
        {
            int index = gameField.Players.IndexOf(gameField.HasCrown);
            gameField.Players.Sort(delegate(Player x, Player y)
            {
                return playerToPerson[x].Rank.CompareTo(playerToPerson[y].Rank);
            });
        }

        public void AddChoice(Choice choice)
        {
            var currentPlayer = gameField.Players[indexPlayer];
            if (!IsInited)
            {
                if (indexPlayer < gameField.Players.Count)
                {
                    CharacterSelection(currentPlayer, choice);
                    indexPlayer += 1;
                }
                else
                {
                    Sorting();
                    indexPlayer = 0;
                }
            }
            else
            {
                playerActions[indexPlayer].AddChoice(choice, this);
                if (playerActions[indexPlayer].Finished)
                {
                    indexPlayer += 0;
                    playerActions.Add(new PlayerAction());
                }
                if (indexPlayer > gameField.Players.Count)
                    Finished = true;
            }
        }

        public bool GetPossibleAction()
        {
            return playerActions[indexPlayer].GetPossibleAction(this); // stub
        }

        public List<Action<Player, Choice>> DoMainAction()
        {
            return new List<Action<Player, Choice>>() { };
        }

        /*void Play()
        {
            var currentPlayer = new Player();
            var person = PlayerToPerson[currentPlayer]; // Военный

            var done = false;
            done = wer(currentPlayer);

            var act = Act.TakeMoney; // Cпросить какое действие совершить
            switch (act)
            {
                case Act.TakeMoney: GetMoneyFromBank(currentPlayer); break;
                case Act.TakeQuarter: GetQuarter(currentPlayer); break;
            }
            if (!done)
                done = wer(currentPlayer);
            var money = bank[currentPlayer];
            
            if (Quarters.Where(q => q.Cost < money).Count() > 0)
                wer2(currentPlayer, "", BuyQuater);
            qwe(currentPlayer);*/
    }
}
