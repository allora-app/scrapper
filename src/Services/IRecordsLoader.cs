using System.Threading.Tasks;

namespace Blinnikov.Scrapper.Services
{
    public interface IRecordsLoader
    {
        Task<string[]> Load(int wordId);
    }
}
