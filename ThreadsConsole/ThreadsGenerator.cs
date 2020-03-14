using System;
using System.Linq;
using System.Net.Http;
using System.Threading;

namespace ThreadsConsole
{
    static class ThreadsGenerator
    {
        internal static void Generate(int? amount)
        {
            int val = amount <= 0 ? 1000 : amount ?? 1000;

            Enumerable.Range(0, val).ToList().ForEach(f =>
            {
                new Thread(() => {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} ended");
                }).Start();
            });
        }

        internal static void GeneratePool(int? amount)
        {
            int val = amount <= 0 ? 1000 : amount ?? 1000;

            Enumerable.Range(0, val).ToList().ForEach(f =>
            {
                ThreadPool.QueueUserWorkItem((o) => {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} ended");
                });
            });
        }

        internal static void ThreadDownload()
        {
            var thread = ThreadDownloadCode();

            thread.Start();
        }

        internal static void ThreadDownload(bool stopCallerThread)
        {
            var thread = ThreadDownloadCode();

            thread.Start();

            if (stopCallerThread)
            {
                thread.Join();
            }
        }

        private static Thread ThreadDownloadCode()
        {
            var thread = new Thread(() => {
                Console.WriteLine("Start download...");
                var webClient = new HttpClient();
                var html = webClient.GetStringAsync("http://derldalfor.co.uk/");
                Console.WriteLine("Done downloading");
            });

            return thread;
        }
    }
}
