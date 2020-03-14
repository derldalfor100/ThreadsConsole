using System;
using System.Threading.Tasks;

namespace ThreadsConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var task = TaskGenerator.GenerateAwait();
            //var task = TaskGenerator.GenerateAwait(10000);

            Console.ReadLine();
            Console.WriteLine("Hello World!");

            var task = TaskGenerator.GenerateAwait();
            //var task = TaskGenerator.GenerateAwait(10000);

            //ThreadsGenerator.Generate(50);

            //ThreadsGenerator.GeneratePool(8);

            //ThreadsGenerator.ThreadDownload();

            //ThreadsGenerator.ThreadDownload(true);

            //TaskGenerator.Generate();

            //TaskGenerator.Generate(10000);

            //await TaskGenerator.GenerateAwait();

            //await TaskGenerator.GenerateAwait(10000);

            await task;

            Console.WriteLine("All done");

            //await task;
        }
    }
}
