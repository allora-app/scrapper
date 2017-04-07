namespace Blinnikov.Scrapper.Services
{
    public class RecordNormalizer : IRecordNormalizer
    {
        public string Normalize(string record)
        {
            return record
                    .Replace("io ", string.Empty)
                    .Replace("tu ", string.Empty)
                    .Replace("lui/lei ", string.Empty)
                    .Replace("noi ", string.Empty)
                    .Replace("voi ", string.Empty)
                    .Replace("loro ", string.Empty)
                    .Replace("che ", string.Empty)
                    .Replace("<b>Presente:</b> ", string.Empty)
                    .Replace("<b>Passato:</b> &nbsp; ", string.Empty);
        }
    }
}
