using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MT.TestFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var act1 = new BoolCondition(() => { Console.WriteLine("task1 action"); return true; }) { Name = "1" };

            var act2 = new VoidCondition(() => { Console.WriteLine("task2 action"); }) { Name = "2" };

            Console.WriteLine("before");

            new ICondition[] { act1, act2 }.ToList().ForEach(Execute);

            Console.WriteLine("after");
        }

        private static void Execute(ICondition cdn)
        {
            Console.WriteLine(cdn.Name);



            Console.WriteLine("result: {0}", GetResult(cdn));
        }

        private static bool GetResult(ICondition condition)
        {
            var timmer = Stopwatch.StartNew();

            var result = condition.Succeed.Value;

            if (IsTimmerDefined(condition))
                Console.WriteLine("take: {0}", timmer.Elapsed);

            return result;

        }

        public static bool IsTimmerDefined(ICondition condition)
        {
            var attributess = condition.GetType()
            .CustomAttributes.OfType<PrintTimeAttribute>().ToList();
            
            foreach (var item in attributess)
            {
                Console.WriteLine("type: {0}", item.GetType());
                
                Console.WriteLine("type: {0}", item.GetType().DeclaringType);
            }
            
            return attributess.Count == 0 ? false :
             attributess.Any(o => o.GetType()  == typeof(PrintTimeAttribute));
        }
    }

    public interface ICondition
    {
        string Name { get; set; }
        Lazy<bool> Succeed { get; }
    }

    [PrintTime]
    public class BoolCondition : Task<bool>, ICondition
    {
        public string Name { get; set; }

        public BoolCondition(Func<bool> acc) : base(acc) { }

        public Lazy<bool> Succeed
        {

            get
            {
                return new Lazy<bool>(
                    () =>
                    {
                        this.Start();

                        return this.Result;
                    });
            }
        }
    }
    
    //[PrintTime]
    public class VoidCondition : Task, ICondition
    {
        public string Name { get; set; }

        public VoidCondition(Action acc) : base(acc) { }

        public Lazy<bool> Succeed
        {

            get
            {
                return new Lazy<bool>(
                    () =>
                    {
                        this.Start();
                        this.Wait();
                        return this.Exception != null;
                    });
            }
        }
    }

    public class PrintTimeAttribute : Attribute
    {

    }
}
