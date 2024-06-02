using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTripLLD.Logger
{
    
    internal interface ILogger
    {
        public void Log(string message);
        public void Log(string message, Exception exception);
    }
    internal class Logger:ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("***********");
            Console.WriteLine(message);
            Console.WriteLine("***********");
        }
        public void Log(string message, Exception exception)
        {
            Console.WriteLine("***********");
            Console.WriteLine(message);
            Console.Write(exception.ToString());
            Console.WriteLine("***********");
        }
    }
}
