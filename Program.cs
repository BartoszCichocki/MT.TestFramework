using System;
using System.Linq;
using MT.TestFrameWork.Core.Flow;

namespace MT.TestFrameWork
{
    public class Program
    {
        public static void Main(string[] args)
        {    
            
            
            Thread th = System.Threading.Thread.CurrentThread;
         th.Name = "MainThread";
         Console.WriteLine("This is {0}", th.Name);
            
            var runner = new FlowRunner();
            runner.run = "asdasda";
            
            Console.WriteLine(runner.run);
             
            var col = new string[]{"2","3"} ;
        	foreach (var item in col)
            {
                Console.WriteLine(item);
            }
            
            (from x in col select x).ToList()
            .ForEach(x=> Console.WriteLine(x));
            
            Console.WriteLine("Hello World!");
        }
    }
}
