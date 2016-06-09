using System;
using System.Collections.Generic;
using System.Linq;

namespace Citadels.Domain
{
    public class Game
    {
        private GameField gameField;
        private List<Round> rounds;
        public int CurrentRound { get; private set; }

        public string CurrentPlayerName { get { return rounds[CurrentRound].CurrentPlayerName; } }

        public bool Finished
        {
            get
            {
                return gameField
                    .Players
                    .Select(player => gameField.ShowCity(player).Count)
                    .Any(c => c == 8);
            }
        }

        public bool RoundFinished
        {
            get { return rounds[CurrentRound].Finished; }
        }

        public Game(List<Player> players, bool extended = false)
        {
            CurrentRound = 0;
            List<Person> persons = GetPersons();
            List<Quarter> quarters = GetQuarters();
            gameField = new GameField(players, persons, quarters);
            rounds = new List<Round>();
            rounds.Add(new Round(gameField));
        }

        private List<Quarter> GetQuarters()
        {
            return typeof(Quarter)
                .Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Quarter)) && !t.IsAbstract)
                .Select(t => (Quarter)Activator.CreateInstance(t))
                .ToList();
        }

        public void AddChoice(int[] choice)
        {
            if (Finished)
                throw new Exception("");

            rounds[CurrentRound].AddChoice(choice);

            if (RoundFinished && !Finished)
            {
                rounds.Add(new Round(gameField));
                CurrentRound++;
            }
        }

        public List<InfoAct> GetPossibleAction()
        {
            return rounds[CurrentRound].GetPossibleAction();
        }

        public List<object> Parameters
        {
            get { return rounds[CurrentRound].Parameters; }
        }

        public void ChooseAction(int i)
        {
            rounds[CurrentRound].ChooseAction(i);
        }

        private List<Person> GetPersons()
        {
            var persons = new List<Person>();
            persons.Add(new Architect());
            persons.Add(new Assassin());
            //persons.Add(new Bishop());
            persons.Add(new King());
            persons.Add(new Magician());
            persons.Add(new Merchant());
            //persons.Add(new Thief());
            //persons.Add(new Warlord());
            return persons;
            //return typeof(Person)
            //    .Assembly.GetTypes()
            //    .Where(t => t.IsSubclassOf(typeof(Person)) && !t.IsAbstract)
            //    .Select(t => (Person)Activator.CreateInstance(t))
            //    .ToList();
        }
    }
}
