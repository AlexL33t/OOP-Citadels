using System;
using System.Collections.Generic;
using System.Linq;

namespace Citadels.Domain
{
    public class Round
    {
        public bool Finished { get { return gameField.Players.Count == playerActions.Count && playerActions.Last().Finished; } }
        public bool IsInited { get { return gameField.Players.Count == playerToPerson.Count; } }
        public string CurrentPlayerName { get { return players[indexPlayer].Name; } }

        private Dictionary<Player, Person> playerToPerson;

        private GameField gameField;

        private List<Person> persons;
        private List<Player> players;
        private int indexPlayer;
        private List<PlayerAction> playerActions;

        public Round(GameField gameField)
        {
            this.gameField = gameField;
            playerActions = new List<PlayerAction>();
            playerToPerson = new Dictionary<Player, Person>();
            persons = new List<Person>(gameField.Persons);
            indexPlayer = 0;
            var i = gameField.Players.IndexOf(gameField.HasCrown);
            players = (i != -1) ? GetPlayers(players, i) : new List<Player>(gameField.Players);
        }

        private List<Player> GetPlayers(List<Player> players, int i)
        {
            var newPlayers = new List<Player>();
            for (int j = 0; j < gameField.Players.Count; j++)
            {
                newPlayers.Add(players[i]);
                i = (i + 1) % players.Count;
            }
            return newPlayers;
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
                playerActions.Add(new PlayerAction(e, playerToPerson[e], gameField));
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
                playerActions[indexPlayer].AddChoice(choice);
                if (playerActions[indexPlayer].Finished && !Finished)
                    indexPlayer++;
            }
        }

        public List<InfoAct> GetPossibleAction()
        {
            if (Finished)
                throw new Exception("");
            if (!IsInited)
                return new List<InfoAct>() { new InfoAct() { Name = "Выберите персонажа" } };
            return playerActions[indexPlayer].GetPossibleActions();
        }

        public List<object> Parameters
        {
            get
            {
                if (!IsInited)
                    return new List<object>(persons);
                return playerActions[indexPlayer].GetParameters();
            }
        }

        public void ChooseAction(int i)
        {
            if (IsInited)
                playerActions[indexPlayer].ChooseAction(i);
        }
    }
}