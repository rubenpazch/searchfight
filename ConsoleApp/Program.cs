using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Search s = new Search();
            Console.WriteLine(s.getData());
            Console.ReadLine();
        }
    }
}
