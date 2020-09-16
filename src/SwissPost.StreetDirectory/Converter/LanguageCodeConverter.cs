using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Converter
{
    internal class LanguageCodeConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return (LanguageCode)int.Parse(text);
            }

            return base.ConvertFromString(text, row, memberMapData);
        }
    }
}
