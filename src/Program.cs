using Blinnikov.Scrapper.Services;

namespace Blinnikov.Scrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var scrapper = new ScrapperService();
            scrapper.Run().Wait();
        }
    }
}
