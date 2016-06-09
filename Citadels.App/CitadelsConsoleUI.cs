using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Citadels.Domain;

namespace Citadels.App
{
    public class CitadelsConsoleUI
    {
        private ConsoleUI ui = new ConsoleUI();
        private IConsoleCommand[] commands;

        public CitadelsConsoleUI()
        {
            commands = new IConsoleCommand[]
            {
                new StartNewGameCommand(ui),
                new HelpCommand(),
                new QuitCommand()
            };
        }

        public void Run()
        {
            while (true)
            {
                var cmd = ui.PromptCommand(commands);
                cmd.Execute();
            }
        }
    }
}
