using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader
{
    internal class NEW_PLZ2_Reader : IReader
    {
        public string ForType { get; } = NEW_PLZ2.RecordType;

        public void Read(CsvReader csvReader, Repository repository)
        {
            var record = csvReader.GetRecord<NEW_PLZ2>();
            repository.NEW_PLZ2s.Add(record);
        }
    }
}
