using System.Threading.Tasks;

namespace Blinnikov.Scrapper.Services.Rating
{
    public interface IRatingLoader
    {
        Task<Models.Rating[]> Load(int page);
    }
}
