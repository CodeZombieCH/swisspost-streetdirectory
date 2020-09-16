using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace SwissPost.StreetDirectory.Converter
{
    internal class BooleanConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (text == "J" || text == "j")
            {
                return true;
            }

            if (text == "N" || text == "n")
            {
                return false;
            }

            return base.ConvertFromString(text, row, memberMapData);
        }
    }
}
