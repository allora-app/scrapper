using System.Threading.Tasks;

public interface IScrapper {
    Task<string> Run();
}
