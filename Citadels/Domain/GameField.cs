using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class GameField
    {
        public List<Player> Players;
        public List<Person> Persons;

        public Player HasCrown = null;
        public Person Killed = null;

        private int income = 1;
        private Queue<Quarter> freeQuarters;
        private Dictionary<Player, List<Quarter>> cities;
        private Dictionary<Player, List<Quarter>> onHand;
        private Dictionary<Player, int> bank;

        public GameField(Queue<Quarter> freeQuarters)
        {
            this.freeQuarters = freeQuarters;
            InitializeField();
        }

        private void InitializeField()
        {
            cities = new Dictionary<Player,List<Quarter>>();
            onHand = new Dictionary<Player,List<Quarter>>();
            bank = new Dictionary<Player,int>();
        }

        #region Show
        public IReadOnlyList<Quarter> ShowQuarterOnHand(Player player)
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

        public int ShowIncome {get {return income;}}
        #endregion

        # region Bank
        public void AddMoneyToBank(Player currentPlayer, int count)
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

        public List<Quarter> TakeSeveralQuartersFromHand(Player player, int[] i)
        {
            var quarters = new List<Quarter>();
            foreach (var e in i)
            {
                quarters.Add(onHand[player][e]);
                onHand[player].Remove(onHand[player][e]);
            }
            return quarters;
        }

        public Quarter TakeOneQuarterFromHand(Player player, int index)
        {
            var quarter = onHand[player][index];
            onHand[player].RemoveAt(index);
            return quarter;
        }

        public void TakeQuartersOnHand(Player player, List<Quarter> quarters)
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

        public void PutQuartersOnDeck(Player player, List<Quarter> quarters)
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

        public void DestroyQuarterInCity(Player player, int index)
        {
            var quarter = cities[player][index];
            cities[player].RemoveAt(index);
        }
        #endregion

        public void KillPerson(Person person)
        {
            Killed = person;
        }

        public void Crown(Player player)
        {
            HasCrown = player;
        }
    }
}
