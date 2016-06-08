using System;
using System.Collections.Generic;
using System.Linq;

namespace Citadels.Domain
{
    public class Round
    {
        public bool Finished { get { return gameField.Players.Count == pl.Count && pl.Last().Finished; } }
        public bool IsInited { get { return gameField.Players.Count == playerToPerson.Count; } }
        public string CurrentPlayerName { get { return players[indexPlayer].Name; } }

        private Dictionary<Player, Person> playerToPerson;

        private GameField gameField;

        private List<Person> persons;
        private List<Player> players;
        private int indexPlayer;
        private List<PlayerAction> pl;

        public Round(GameField gameField)
        {
            this.gameField = gameField;
            pl = new List<PlayerAction>();
            playerToPerson = new Dictionary<Player, Person>();
            persons = new List<Person>(gameField.Persons);
            indexPlayer = 0;
            var i = gameField.Players.IndexOf(gameField.HasCrown);
            players = (i != -1) ? GetPlayers(players, i) : new List<Player>(gameField.Players);
        }

        private List<Player> GetPlayers(List<Player> players, int i)
        {
            var pl = new List<Player>();
            for (int j = 0; j < gameField.Players.Count; j++)
            {
                pl.Add(players[i]);
                i = (i + 1) % players.Count;
            }
            return pl;
        }

        public void CharacterSelection(Player currentPlayer, int[] choice)
        {
            if (choice.Length > 1)
                throw new Exception("");

            playerToPerson.Add(currentPlayer, persons[choice[0]]);
            persons.RemoveAt(choice[0]);
        }

        private void Sorting()
        {
            int index = gameField.Players.IndexOf(gameField.HasCrown);
            players.Sort(delegate(Player x, Player y)
            {
                return playerToPerson[x].Rank.CompareTo(playerToPerson[y].Rank);
            });

            foreach (var e in players)
                pl.Add(new PlayerAction(e, playerToPerson[e], gameField));
            indexPlayer = 0;
        }

        public void AddChoice(int[] choice)
        {
            var currentPlayer = gameField.Players[indexPlayer];

            if (!IsInited)
            {
                CharacterSelection(currentPlayer, choice);
                indexPlayer += 1;
                if (indexPlayer == gameField.Players.Count)
                    Sorting();
            }
            else
            {
                pl[indexPlayer].AddChoice(choice);
                if (pl[indexPlayer].Finished && !Finished) indexPlayer++;
            }
        }

        public List<InfoAct> GetPossibleAction()
        {
            if (Finished)
                throw new Exception("");
            if (!IsInited)
                return new List<InfoAct>() { new InfoAct() { Name = "Выбирите персонажа" } };
            return pl[indexPlayer].GetPossibleActions();
        }

        public List<object> Param
        {
            get
            {
                if (!IsInited)
                    return new List<object>(persons);
                return pl[indexPlayer].GetParam();
            }
        }

        public void ChoiseAction(int i)
        {
            if (IsInited)
                pl[indexPlayer].ChoiseAction(i);
        }
    }
}
