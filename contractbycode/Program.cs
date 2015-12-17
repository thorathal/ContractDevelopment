using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contractbycode
{
    class Program
    {
        static void Main(string[] args)
        {
            Account ac = new Account(10000);
            ac.deposit(-10);
            Console.WriteLine(ac.Balance);

            ac.withdraw(20000);
            Console.WriteLine(ac.Balance);

            ac.deposit(12);
            Console.WriteLine(ac.Balance);

            ac.withdraw(10);
            Console.WriteLine(ac.Balance);

            Console.ReadLine();
        }

    }
}
