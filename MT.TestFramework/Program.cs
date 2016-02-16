using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.TestFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            var task = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task");
            });

            task.Wait();

            Console.WriteLine("abcd");
        }
    }
}
