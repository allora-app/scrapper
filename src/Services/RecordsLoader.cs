using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Parser.Html;

namespace Blinnikov.Scrapper.Services
{
    public class RecordsLoader : IRecordsLoader
    {
        private readonly HttpClient _httpClient;

        public RecordsLoader()
        {
            var handler = new HttpClientHandler 
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            this._httpClient = new HttpClient(handler);
        }

        public async Task<string[]> Load(int wordId)
        {
            var url = this.GetUrl(wordId);
            var page = await this._httpClient.GetAsync(url);
            var elements = await this.GetDocument(page.Content);

            return elements.Select(el => el.InnerHtml).ToArray();
        }

        private string GetUrl(int wordId) 
        {
            return $"http://www.italian-verbs.com/verbi-italiani/coniugazione.php?verbo={wordId}";
        }

        private async Task<IEnumerable<IElement>> GetDocument(HttpContent content) 
        {
            var parser = new HtmlParser();
            var page = await content.ReadAsStringAsync();
            var document = await parser.ParseAsync(page);

            return document.QuerySelectorAll("div.span_1_of_2 table tr td").Take(115);
        }
    }
}
