using System;
using System.Threading.Tasks;

namespace Module_5_Task_1
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var starter = new Starter();
            await starter.Run();
        }
    }
}
