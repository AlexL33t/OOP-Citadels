using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public abstract class Person
    {
        public int Rank;
        public QuarterColor Color = QuarterColor.None;
        public int MaxCountOfTakenQuartersFromDeck = 1;

        public abstract List<Act> GetPossibleActons(Player player, Person person, Flags flags, GameField field);
        
        #region equals, gethashcode, tostring
        protected bool Equals(Person other)
        {
            return Rank == other.Rank && (int)Color == (int)other.Color;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Person)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Rank ^ (int)Color + 123;
            }
        }

        public override string ToString()
        {
            return GetType().Name;
        }
        #endregion
    }
}