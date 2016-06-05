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
    }
}
