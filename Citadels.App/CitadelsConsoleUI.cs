//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Citadels.Domain;

//namespace Citadels.App
//{
//    public class CitadelsConsoleUI
//    {
//        private Dictionary<Player, PlayerAction> playerToPlAction;

//        private List<string> getParametersGame()
//        {
//            return new List<string>();
//        }

//        public void Run()
//        {
//            var names = getParametersGame();
//            var players = new List<Player>();

//            for (var i = 0; i < names.Count; i++)
//                players.Add(new Player(i.ToString(), names[i]));

//            foreach (var pl in players)
//                playerToPlAction.Add(pl, new PlayerAction());

//            var game = new Game(players);

//            while (!game.Finished)
//            {
//                ShowInfo(game);
//                var choice = Prompt();
//                game.AddChoice(choice);
//            }
            
//        }

//        private void ShowInfo(Game game)
//        {
//            var state = game.State;
//            var info = game.InfoAboutCP;
//            var finished = game.IsFinished;
//            var posibleAction = game.GetPossibleAction();
//        }

            
//        private Choice Prompt()
//        {
//            return new Choice(new Assassin(), new Player("123", "Alex"));
//        }

//        private PlayerAction getAction(Game game)
//        {
//            //game.Get
//            return new PlayerAction();
//        }
//        /* 1
//         * 
//         * 
//         * 2 СП Д СП Д СП
//         * 
//         * 
//         */

//    }
//}
