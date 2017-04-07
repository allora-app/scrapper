namespace Blinnikov.Scrapper.Models
{
    public class Verb
    {
        public FiniteForm Present { get; set; }
        public FiniteForm PresentPerfect { get; set; }
        public FiniteForm AbsolutePast { get; set; }
        public FiniteForm Imperfect { get; set; }
        // Trapassato Remoto
        public FiniteForm PreteritePerfect { get; set; }
        // Past Perfect - Trapassato Prossimo
        public FiniteForm Pluperfect { get; set; }
        public FiniteForm Future { get; set;}
        public FiniteForm FuturePerfect { get; set; }
        public FiniteForm SubjunctivePresent { get; set; }
        public FiniteForm SubjunctiveImperfect { get; set; }
        public FiniteForm SubjunctivePerfect { get; set; }
        public FiniteForm SubjunctivePluperfect { get; set; }
        public FiniteForm ConditionalPresent { get; set; }
        public FiniteForm ConditionalPerfect { get; set; }
        public FiniteForm ImperativePresent { get; set; }
        public NonFiniteForm Infinite { get; set; }
        public NonFiniteForm Participle { get; set; }
        public NonFiniteForm Gerund { get; set; }
    }
}
