using NUnit.ConsoleRunner;
using NUnit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDebugger
{
    class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            InternalTrace.Initialize("nunit-console_%p.log",InternalTraceLevel.Default);
            return Runner.Main(args);
        }
    }
}
