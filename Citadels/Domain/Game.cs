using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Citadels.Domain
{
    public enum State { InitRound, PlayingRound }

    public class Game
    {
        public bool Finished { get; set; }
        public IEnumerable<Player> Players { get; private set; }
        
        List<Person> persons;
        GameField gameField;
        private List<Round> rounds;
        private int currentRound;
        
        public State State;
        public Info InfoAboutCP { 
            get 
            {
                return new Info() { }; 
            } 
        }

        public bool IsFinished { get { return rounds[currentRound].Finished; } }
        
        public Game(List<Player> players, List<Person> persons, bool extended=false)
        {
            rounds = new List<Round>();
            Players = players;
            persons = new List<Person>();
            persons.Add(new Assassin());
        }

        public bool AddChoice(Choice choice)
        {
            if (Finished)
                throw new Exception("");
            
            switch (State)
            {
                case State.InitRound: CreateRound(); break;
                case State.PlayingRound: AddChoiceInRound(choice); break;

            }
        }
        
        private void CreateRound()
        {
            var round = new Round(gameField, null);
            rounds.Add(round);
            var state = State.InitRound;
        }



        private void AddChoiceInRound(Choice choice)
        {
            rounds[currentRound].AddChoice(choice);
            if (rounds[currentRound].Finished)
                State = State.InitRound;
        }

        public bool GetPossibleAction()
        {
            rounds[currentRound].GetPossibleAction();
            return true;
        }
    }
}
