using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Citadels.Domain;

namespace Citadels.App
{
    public class StartNewGameCommand : IConsoleCommand
    {
        private ConsoleUI ui;

        public StartNewGameCommand(ConsoleUI ui)
        {
            this.ui = ui;
        }

        public string Title { get { return "Начать новую игру"; } }
        public char Symbol { get { return 'S'; } }

        public void Execute()
        {
            var playersNumber = ui.PromptInt("Введите количество игроков от 2 до 6", "2");
            var players = new List<Player>();
            for (var i = 0; i < playersNumber; i++)
            {
                var name = ui.Prompt("Введите имя игрока");
                players.Add(new Player(i.ToString(), name));
            }
            var game = new Game(players);
            Console.WriteLine("Игра началась");
            Console.WriteLine();
            while (!game.Finished)
            {
                Console.WriteLine("Раунд {0}.", game.CurrentRound);
                ChoosePersons(game, players);
                Console.WriteLine();
                MakeMoves(game, players);
            }
        }

        private void ChoosePersons(Game game, List<Player> players)
        {
            Console.WriteLine("Выбор персонажей");
            for (var i = 0; i < players.Count; i++)
            {
                Console.WriteLine("Выбирает игрок {0}", game.CurrentPlayerName);
                Console.WriteLine("Доступные персонажи:");
                var possibleActions = game.GetPossibleAction();
                game.ChooseAction(0);
                for (var j = 0; j < game.Parameters.Count; j++)
                    Console.WriteLine("{0}. {1}", j, game.Parameters[j]);
                var choice = ui.PromptInt("Введите номер персонажа", "0");
                if (choice >= game.Parameters.Count)
                    throw new Exception("");
                game.AddChoice(new int[] { choice });
            }
        }

        private void MakeMoves(Game game, List<Player> players)
        {
            Console.WriteLine("Ходы игроков");
            for (int i = 0; i < players.Count + 1; i++)
            {
                Console.WriteLine("Ход игрока {0}", game.CurrentPlayerName);
                Console.WriteLine("Доступные действия:");
                var possibleActions = game.GetPossibleAction();
                for (var j = 0; j < possibleActions.Count; j++)
                    Console.WriteLine("{0}. {1}", j, possibleActions[j].Name);
                var choice = ui.PromptInt("Введите номер действия", "0");
                if (choice >= possibleActions.Count)
                    throw new Exception("");
                game.ChooseAction(choice);
                game.AddChoice(new int[] { choice });
            }
        }
    }
}
