using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Citadels.Domain;

namespace Citadels.App
{
    class Program
    {
        static void Main2(string[] args)
        {
            //new CitadelsConsoleUI().Run();

            var pl = new List<Player>(){new Player(){Name = "qwe"}, new Player() {Name="asd"}};
            var game = new Game(pl);

            for (int i = 0; i < pl.Count; i++)
            {
                Console.WriteLine(game.CurrentPlayerName);
                var pa = game.GetPossibleAction();
                foreach (var e in pa) Console.WriteLine(e.Name);
                game.ChoiseAction(0);
                foreach (var e in game.Param) Console.WriteLine(e);
                game.AddChoice(new int[] {0});
            }

            for (int i = 0; i < pl.Count+1; i++)
            {
                Console.WriteLine(game.CurrentPlayerName);
                var a = game.GetPossibleAction();
                foreach (var j in a) Console.WriteLine(j.Name);
                game.ChoiseAction(1-i);
                var p = game.Param;
                if (null != p)
                    foreach (var s in p) Console.WriteLine(s);
                game.AddChoice(new int[] {0});
            }

            foreach (var e in game.Param)
                Console.WriteLine(e);
        }
    }
}
