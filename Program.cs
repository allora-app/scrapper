using System;

namespace scrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var scrapper = new Scrapper();
            var text = scrapper.Run().Result;

            Console.WriteLine(text);
        }
    }
}
