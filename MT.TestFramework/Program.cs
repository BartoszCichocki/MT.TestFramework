using System;
using System.Diagnostics;
using System.Linq;
using System.Exception;
using System.Threading.Tasks;

namespace MT.TestFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("after");
        }
        
        static void Run(){
            
            var flow = new FlowBuilder();
            
            flow
                
                .ValidateThat(() => true)
                    .Condition(() => expression())
                    .Named("StepName")
                    .Should()
                        .ExecuteInLessThan(5).And().Return(Result.True)
                    .OnSuccess()
                    .OnFailure()
                        .Continiue()
                        .Retry()
                        .WarnAndRetry()
                        .WarnAndContiniue()
                        .Abord()   
                    .OnException().OfType().Continiue()
                    .OnException().Any().Abord()
                 .ValidateThat()          
                 ..... 
               ;             
                        
        }
    }
    
    
}
