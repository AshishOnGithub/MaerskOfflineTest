using System;
using System.Net.Http;
using System.Threading;

namespace BackgroundJob
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("DataSortProcessor started");
            while(true)
            {
                Console.WriteLine("DataSortProcessor Working...");
                HttpClient client = new HttpClient();
                await client.GetAsync("https://localhost:44338/sort/DataSortProcessor");
                Thread.Sleep(5000);
            }
            //
        }
    }
}
