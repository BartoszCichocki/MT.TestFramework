using System;
using System.Threading.Tasks;

namespace MT.TestFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var act1 = new BoolCondition(() => { Console.WriteLine("task1"); return true; });
            
            var act2 = new VoidCondition(() => { Console.WriteLine("task2"); });
            
            Console.WriteLine("before");
            
            foreach (var task in new ICondition[] {act1, act2})
            {
                Execute(task);
            }     

            Console.WriteLine("after");
        }
        
        private static void Execute(ICondition cdn){
           
            Console.WriteLine( cdn.Name);
            
            var result = cdn.Execute();
            
            Console.WriteLine("result: {0}", result);
        }
    }

    public interface ICondition
    {
        string Name { get; set; }
        bool Execute();
    }

    public class BoolCondition : Task<bool>, ICondition
    {
        public string Name { get; set; }

        public BoolCondition(Func<bool> acc) : base(acc) { }
        
        public bool Execute(){
            return this.Result;
        }
    }
    
    public class VoidCondition : Task, ICondition {
        public string Name { get; set; }

        public VoidCondition(Action acc) : base(acc) { }
        
        public bool Execute(){
            this.Start();
            this.Wait();
            return this.Exception != null;
        }
    }
}
