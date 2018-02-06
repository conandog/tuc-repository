using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LinearRegression
{
    class Program
    {
        static void Main(string[] args)
        {
            HandleArgs(ref args);
            Console.WriteLine("Please wait a second...");
            Controller controller = new Controller();
            controller.CalculatePredictedRateForTomorrow(args[0], args[1]);
        }

        private static void HandleArgs(ref string[] args)
        {
            if (args.Length != 2)
            {
                args = new string[2];
                Console.Write(Constants.GET_FROM_CURRENCY);
                args[0] = Console.ReadLine();
                Console.Write(Constants.GET_TO_CURRENCY);
                args[1] = Console.ReadLine();
            }
        }
    }
}
