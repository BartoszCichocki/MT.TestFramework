using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MT.TestFramework.Flow;

namespace MT.TestFramework
{
    class Program
    {
        static void Main(string[] args)
        {


            var runner = new FlowRunner();
            runner.dddd = 12;

 Console.WriteLine(runner.dddd);

            var task = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task");
            });

            task.Wait();

            Console.WriteLine("abcd");
        }
    }
}
