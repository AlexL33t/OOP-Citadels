using System.Collections.Generic;

namespace Citadels.Domain
{
    public class GameField
    {
        public readonly List<Player> Players;
        public readonly List<Person> Persons;

        public Player HasCrown = null;
        public Person Killed = null;

        private static int income = 1;
        private Queue<Quarter> freeQuarters;
        private Dictionary<Player, List<Quarter>> cities;
        private Dictionary<Player, List<Quarter>> onHand;
        private Dictionary<Player, int> bank;

        public int CountQuartersInDeck { get { return freeQuarters.Count; } }

        public GameField(List<Player> players, List<Person> persons, List<Quarter> freeQuarters)
        {
            this.freeQuarters = new Queue<Quarter>(freeQuarters);
            Players = players;
            Persons = persons;
            cities = new Dictionary<Player, List<Quarter>>();
            onHand = new Dictionary<Player, List<Quarter>>();
            bank = new Dictionary<Player, int>();
            foreach (var e in players)
            {
                cities.Add(e, new List<Quarter>());
                onHand.Add(e, new List<Quarter>());
                bank.Add(e, 0);
            }
        }


        public int ShowIncome {get {return income;}}

        public void KillPerson(Person person)
        {
            Killed = person;
        }

        public void Crown(Player player)
        {
            HasCrown = player;
        }

        #region Show
        public IReadOnlyList<Quarter> ShowQuarterInHand(Player player)
        {
            return onHand[player].AsReadOnly();
        }

        public int ShowBankState(Player player)
        {
            return bank[player];
        }

        public IReadOnlyList<Quarter> ShowCity(Player player)
        {
            return cities[player].AsReadOnly();
        }
        #endregion

        # region Bank
        public void AddMoneyInBank(Player currentPlayer, int count)
        {
            bank[currentPlayer] += count;
        }

        public void TakeMoneyFromBank(Player currentPlayer, int count)
        {
            bank[currentPlayer] -= count;
        }
        #endregion

        #region Quarters On Hand
        public List<Quarter> TakeAllQuartersFromHand(Player player)
        {
            var quarters = onHand[player];
            onHand[player] = new List<Quarter>();
            return quarters;
        }

        public List<Quarter> TakeQuartersFromHand(Player player, int[] i)
        {
            return new List<Quarter>();
        }

        public Quarter TakeQuarterFromHand(Player player, int index)
        {
            var quarter = onHand[player][index];
            onHand[player].RemoveAt(index);
            return quarter;
        }

        public void PutQuartersInHand(Player player, List<Quarter> quarters)
        {
            onHand[player].AddRange(quarters);
        }
        #endregion

        #region Deck
        public List<Quarter> TakeQuartersFromDeck(int count)
        {
            var quarters = new List<Quarter>();
            for (int i = 0; i < count; i++)
                quarters.Add(freeQuarters.Dequeue());
            return quarters;
        }

        public void PutQuartersOnDeck(List<Quarter> quarters)
        {
            foreach (var i in quarters)
                freeQuarters.Enqueue(i);
        }
        #endregion

        #region City
        public void BuildQuarterInCity(Player player, Quarter quarter)
        {
            cities[player].Add(quarter);
        }

        public Quarter DestroyQuarterInCity(Player player, int index)
        {
            var quarter = cities[player][index];
            cities[player].RemoveAt(index);
            return quarter;
        }
        #endregion
    }
}
