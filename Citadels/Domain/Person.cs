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
        public QuarterColor Color;
        public List<Action<Player, Choice, GameField>> PersonActions;
        /* ассасин
         * вор
         * маг
         * король(желтый)
         * епископ(синий)
         * купец(зеленый) "2" сп
         * зодчий
         * военный(красный) '2' способности 
         */
        #region equals, gethashcode
        protected bool Equals(Person other)
        {
            return Rank == other.Rank && (int)Color == (int)other.Color;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Choice)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Rank ^ (int)Color + 123;
            }
        }
        #endregion
    }
}
