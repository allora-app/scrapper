namespace Blinnikov.Scrapper.Models
{
    public class Verb
    {
        // it: Presente
        public FiniteForm Present { get; set; }
        // it: Passato Prossimo
        public FiniteForm PresentPerfect { get; set; }
        // it: Passato Remoto
        public FiniteForm AbsolutePast { get; set; }
        // it: Imperfetto
        public FiniteForm Imperfect { get; set; }
        // it: Trapassato Remoto
        public FiniteForm PreteritePerfect { get; set; }
        // Past Perfect;
        // it: Trapassato Prossimo
        public FiniteForm Pluperfect { get; set; }
        // it: Futuro Semplice
        public FiniteForm Future { get; set;}
        // it: Futuro Anteriore
        public FiniteForm FuturePerfect { get; set; }
        // it: Congiuntivo Presente
        public FiniteForm SubjunctivePresent { get; set; }
        // it: Congiuntivo Imperfetto
        public FiniteForm SubjunctiveImperfect { get; set; }
        // it: Congiuntivo Passato
        public FiniteForm SubjunctivePerfect { get; set; }
        // it: Congiuntivo Trapassato
        public FiniteForm SubjunctivePluperfect { get; set; }
        // it: Condizionale Presente
        public FiniteForm ConditionalPresent { get; set; }
        // it: Condizionale Passato
        public FiniteForm ConditionalPerfect { get; set; }
        // it: Imperativo Present
        public FiniteForm ImperativePresent { get; set; }
        // it: Infinitivo
        public NonFiniteForm Infinite { get; set; }
        // it: Participio
        public NonFiniteForm Participle { get; set; }
        // it: Gerundio
        public NonFiniteForm Gerund { get; set; }
    }
}
