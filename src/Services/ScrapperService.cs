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
    public class ScrapperService : IScrapperService
    {
        private readonly HttpClient _httpClient;

        public ScrapperService()
        {
            var handler = new HttpClientHandler 
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            this._httpClient = new HttpClient(handler);
        }

        public async Task<string> Run()
        {
            var fare = 3832;
            var url = this.GetUrl(fare);
            var page = await this._httpClient.GetAsync(url);
            var elements = await this.GetDocument(page.Content);

            var i = 0;
            return string.Join(Environment.NewLine, elements.Select(el => $"{++i}. {el.InnerHtml}"));
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
