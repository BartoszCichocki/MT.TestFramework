using System;
using System.Linq;
using System.Threading;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {    
            Console.WriteLine("Main thread: Start a second thread.");
     
            Thread t = new Thread(new ThreadStart(ThreadProc));

            t.Start();
            
            for (int i = 0; i < 4; i++) {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
            }

            Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.");
            t.Join();
            Console.WriteLine("Main thread: ThreadProc.Join has returned.  Press Enter to end program.");
            Console.ReadLin 
        
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
