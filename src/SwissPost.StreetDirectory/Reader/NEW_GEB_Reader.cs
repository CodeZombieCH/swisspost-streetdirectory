using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader
{
    internal class NEW_GEB_Reader : IReader
    {
        public string ForType { get; } = NEW_GEB.RecordType;

        public void Read(CsvReader csvReader, Repository repository)
        {
            var record = csvReader.GetRecord<NEW_GEB>();
            repository.NEW_GEBs.Add(record.HOUSEKEY, record);
        }
    }
}
