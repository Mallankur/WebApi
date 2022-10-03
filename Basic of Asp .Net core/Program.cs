using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Basic_of_Asp.Net_core
{
    public  class Program
    {
        static void Main(string[] args)
        {
            var demomethod = DemoMethodAsync("Task1");
            Console.WriteLine("cursore Moved to next Line in Main () without waiting forr DemoMethodAsync() compleection");
            var longruningmethod = LongRunningOperationAsync("Task2");
            Console.WriteLine("Now waiting for task to finished");
            Task.WaitAll(longruningmethod,demomethod); // now waiting 
            Console.WriteLine("Exiting Commandline");
            Console.ReadLine(); 
        }

        private static async Task<string>   LongRunningOperationAsync(string  taskName)
        {
            Console.WriteLine( taskName);
            await Task.Delay(5000);
            Console.WriteLine($"longrunning oprstion for {taskName}");
            return "Hello there from long operations";

            
        }

        private static async Task DemoMethodAsync(string  taskname)
        {
            Task<string> longrunningTask = LongRunningOperationAsync(taskname);
            Console.WriteLine("work now excute independly in demo Methodasync()");
            var result = await longrunningTask;
            Console.WriteLine(result);
        }
      
    }
}
