using Blinnikov.Scrapper.Models;

namespace Blinnikov.Scrapper.Services
{
    public class VerbBuilder : IVerbBuilder
    {
        private readonly IRecordNormalizer _normalizer;

        public VerbBuilder()
        {
            this._normalizer = new RecordNormalizer();
        }

        public Verb Build(string[] tenses)
        {
            var finiteForm = new Verb
            {
                Present = this.ParseFiniteForm(tenses, 1),
                Imperfect = this.ParseFiniteForm(tenses, 8),
                AbsolutePast = this.ParseFiniteForm(tenses, 15),
                Future = this.ParseFiniteForm(tenses, 22),
                PresentPerfect = this.ParseFiniteForm(tenses, 29),
                Pluperfect = this.ParseFiniteForm(tenses, 36),
                PreteritePerfect = this.ParseFiniteForm(tenses, 43),
                FuturePerfect = this.ParseFiniteForm(tenses, 50),
                SubjunctivePresent = this.ParseFiniteForm(tenses, 57),
                SubjunctiveImperfect = this.ParseFiniteForm(tenses, 64),
                SubjunctivePerfect = this.ParseFiniteForm(tenses, 71),
                SubjunctivePluperfect = this.ParseFiniteForm(tenses, 78),
                ConditionalPresent = this.ParseFiniteForm(tenses, 85),
                ConditionalPerfect = this.ParseFiniteForm(tenses, 92),
                ImperativePresent = this.ParseFiniteForm(tenses, 100),
                Infinite = this.ParseNonFiniteFrom(tenses, 107),
                Participle = this.ParseNonFiniteFrom(tenses, 110),
                Gerund = this.ParseNonFiniteFrom(tenses, 113)
            };

            return finiteForm;
        }

        private FiniteForm ParseFiniteForm(string[] records, int offset = 0)
        {
            var result = new FiniteForm
            {
                FirstSingular = this._normalizer.Normalize(records[offset + 0]),
                SecondSingular = this._normalizer.Normalize(records[offset + 1]),
                ThirdSingular = this._normalizer.Normalize(records[offset + 2]),
                FirstPlural = this._normalizer.Normalize(records[offset + 3]),
                SecondPlural = this._normalizer.Normalize(records[offset + 4]),
                ThirdPlural = this._normalizer.Normalize(records[offset + 5])
            };
            return result;
        }

        private NonFiniteForm ParseNonFiniteFrom(string[] records, int offset)
        {
            var result = new NonFiniteForm
            {
                Present = this._normalizer.Normalize(records[offset + 0]),
                Past = this._normalizer.Normalize(records[offset + 1])
            };
            return result;
        }
    }
}