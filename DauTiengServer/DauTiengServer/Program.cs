using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DauTiengServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server.StartListening(1234);
        }
    }
}
