using Blinnikov.Scrapper.Models;

namespace Blinnikov.Scrapper.Services
{
    public interface IVerbBuilder
    {
        Verb Build(string[] tenses);
    }
}
