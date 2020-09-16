using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader
{
    internal class NEW_BOT_B_Reader : IReader
    {
        public string ForType { get; } = NEW_BOT_B.RecordType;

        public void Read(CsvReader csvReader, Repository repository)
        {
            var record = csvReader.GetRecord<NEW_BOT_B>();
            repository.NEW_BOT_Bs.Add(record);
        }
    }
}
