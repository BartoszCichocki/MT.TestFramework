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
                
                .Validate(() => true)
                    .Condition("StepName", () => expression())
                    .That()
                        .If()
                            .ExecuteInLessThan(5)
                            .And()
                            .Return(ConditionState.True)
                        .Then()
                            .ReportSuccess()
                        .Else()
                            .ReportFailure()
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
