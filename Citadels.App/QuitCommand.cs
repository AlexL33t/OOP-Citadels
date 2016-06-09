using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.App
{
    public class QuitCommand : IConsoleCommand
    {
        public string Title { get { return "Выйти из игры"; } }
        public char Symbol { get { return 'Q'; } }

        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
