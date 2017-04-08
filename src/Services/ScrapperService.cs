using System;
using System.Threading.Tasks;
using Blinnikov.Scrapper.Models;
using Blinnikov.Scrapper.Services.Rating;
using Blinnikov.Scrapper.Store;
using Newtonsoft.Json;

namespace Blinnikov.Scrapper.Services 
{
    public class ScrapperService : IScrapperService
    {
        private const int MaxWordId = 12330;
        private const int MaxPage = 247;
        private readonly IRecordsLoader _recordsLoader;
        private readonly IRatingLoader _ratingLoader;
        private readonly IRecordNormalizer _normalizer;
        private readonly IVerbBuilder _verbBuilder;
        private readonly IFirebaseClient _firebaseClient;

        public ScrapperService()
        {
            this._recordsLoader = new RecordsLoader();
            this._ratingLoader = new RatingLoader();
            this._normalizer = new RecordNormalizer();
            this._verbBuilder = new VerbBuilder();
            this._firebaseClient = new FirebaseClient("allora-conjugator");
        }

        public async Task Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            await ScrapeVerbs();
        }

        private async Task ScrapeVerbs()
        {
            var vedere = 12107;
            var records = await this._recordsLoader.Load(vedere);
            
            var verb = this._verbBuilder.Build(records);
            string key = verb.Infinite.Present;
            var savedVerb = await this._firebaseClient.Save<Verb>(key, verb);

            var json = JsonConvert.SerializeObject(verb, Formatting.Indented);
            Console.WriteLine("Built Verb:");
            Console.WriteLine(json);
        }

        private async Task ScrapeRating()
        {
            for(var page = 1; page <= MaxPage; page++)
            {
                var records = await this._ratingLoader.Load(page);
                foreach(var rating in records)
                {
                    await this._firebaseClient.Save<int>(rating.Verb, rating.Searches);
                    Console.WriteLine($"Saved: {rating.Order}. {rating.Verb}");
                }
            }
        }
    }
}
