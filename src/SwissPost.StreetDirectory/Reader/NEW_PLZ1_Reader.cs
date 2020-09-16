using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader
{
    internal class NEW_PLZ1_Reader : IReader
    {
        public string ForType { get; } = NEW_PLZ1.RecordType;

        public void Read(CsvReader csvReader, Repository repository)
        {
            var record = csvReader.GetRecord<NEW_PLZ1>();
            repository.NEW_PLZ1s.Add(record.ONRP, record);
        }
    }
}
