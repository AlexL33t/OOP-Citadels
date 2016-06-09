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
        static void Main(string[] args)
        {
            new CitadelsConsoleUI().Run();

            //var pl = new List<Player>() { new Player("1", "John"), new Player("2", "Bruce") };
            //var game = new Game(pl);

            //for (int i = 0; i < pl.Count; i++)
            //{
            //    Console.WriteLine(game.CurrentPlayerName);
            //    var pa = game.GetPossibleAction();
            //    foreach (var e in pa) Console.WriteLine(e.Name);
            //    game.ChooseAction(i);
            //    foreach (var e in game.Parameters) Console.WriteLine(e);
            //    game.AddChoice(new int[] { i });
            //}

            //for (int i = 0; i < pl.Count + 1; i++)
            //{
            //    Console.WriteLine(game.CurrentPlayerName);
            //    var a = game.GetPossibleAction();
            //    foreach (var j in a) Console.WriteLine(j.Name);
            //    game.ChooseAction(1 - i);
            //    var p = game.Parameters;
            //    if (null != p)
            //        foreach (var s in p) Console.WriteLine(s);
            //    game.AddChoice(new int[] { 0 });
            //}

            //foreach (var e in game.Parameters)
            //    Console.WriteLine(e);
        }
    }
}