using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.App
{
    public interface IConsoleCommand
    {
        string Title { get; }
        char Symbol { get; }
        void Execute();
    }
}
