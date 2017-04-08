using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Parser.Html;

namespace Blinnikov.Scrapper.Services.Rating
{
    public class RatingLoader : IRatingLoader
    {
        private readonly HttpClient _httpClient;

        public RatingLoader()
        {
            var handler = new HttpClientHandler 
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            this._httpClient = new HttpClient(handler);
        }

        public async Task<Models.Rating[]> Load(int page)
        {
            var url = this.GetUrl(page);
            var webPage = await this._httpClient.GetAsync(url);
            var ratings = await this.ParseWebPage(webPage.Content);

            return ratings;
        }

        private string GetUrl(int page)
        {
            return $"http://www.italian-verbs.com/verbi-italiani/verbi-italiani-top.php?pg={page}";
        }

        private async Task<Models.Rating[]> ParseWebPage(HttpContent content) 
        {
            var parser = new HtmlParser();
            var page = await content.ReadAsStringAsync();
            var document = await parser.ParseAsync(page);

            var records = document.QuerySelectorAll("#zebra tr")
                        .Where(el => el.ChildElementCount == 3)
                        .Select(ParseTr)
                        .ToArray();

            return records;
        }

        private Models.Rating ParseTr(IElement el)
        {
            var order = int.Parse(el.Children[0].InnerHtml.Replace("&nbsp;", string.Empty));
            var verb = el.Children[1].Children[0].InnerHtml;
            var searchesStr = el.Children[2].InnerHtml
                                .Replace("&nbsp;", string.Empty)
                                .Replace(".", string.Empty);
            var searches = int.Parse(searchesStr);

            return new Models.Rating { Order = order, Searches = searches, Verb = verb };
        }
    }
}