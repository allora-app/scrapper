using System;
using Blinnikov.Scrapper.Services;

namespace Blinnikov.Scrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var scrapper = new ScrapperService();
            var text = scrapper.Run().Result;

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(text);
        }
    }
}
