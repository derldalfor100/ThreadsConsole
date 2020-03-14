using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ThreadsConsole
{
    static class TaskGenerator
    {
        internal static void Generate()
        {
            GenerateTask(0);
        }

        internal static void Generate(int time)
        {
            GenerateTask(time);
        }

        internal static async Task GenerateAwait()
        {
            await GenerateTaskAwait(0);
        }

        internal static async Task GenerateAwait(int time)
        {
            await GenerateTaskAwait(time);
        }

        private static void GenerateTask(int time) // not working, nobody awaits the method
        {
            Task.Run(async () =>
            {
                await Task.Delay(time);
                Console.WriteLine("Start download...");
                var webClient = new HttpClient();
                var html = await webClient.GetStringAsync("http://derldalfor.co.uk/");
                Console.WriteLine(html);
                Console.WriteLine("Done downloading");
            });
        }

        private static Task GenerateTaskAwait(int time)
        {
            return Task.Run(async () =>
            {
                await Task.Delay(time);
                Console.WriteLine("Start download...");
                var webClient = new HttpClient();
                var html = await webClient.GetStringAsync("http://derldalfor.co.uk/");
                Console.WriteLine(html);
                Console.WriteLine("Done downloading");
            });
        }
    }
}
