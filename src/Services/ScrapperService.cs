using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Blinnikov.Scrapper.Services 
{
    public class ScrapperService : IScrapperService
    {
        private const int MaxWordId = 12330;
        private readonly IRecordsLoader _recordsLoader;
        private readonly IRecordNormalizer _normalizer;
        private readonly IVerbBuilder _verbBuilder;

        public ScrapperService()
        {
            this._recordsLoader = new RecordsLoader();
            this._normalizer = new RecordNormalizer();
            this._verbBuilder = new VerbBuilder();
        }

        public async Task<string> Run()
        {
            var fare = 3832;
            var vedere = 12107;
            var records = await this._recordsLoader.Load(vedere);
            var verb = this._verbBuilder.Build(records);

            var json = JsonConvert.SerializeObject(verb, Formatting.Indented);
            Console.WriteLine("Built Verb:");
            Console.WriteLine(json);

            var i = 0;
            var lines = records.Select(el => $"{++i}. {this._normalizer.Normalize(el)}");
            return string.Join(Environment.NewLine, lines);
        }
    }
}
