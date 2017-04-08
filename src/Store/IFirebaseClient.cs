using System.Threading.Tasks;

namespace Blinnikov.Scrapper.Store
{
    public interface IFirebaseClient
    {
        Task<T> Save<T>(string key, T item);
    }
}
