using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader
{
    internal class NEW_GEBA_Reader : IReader
    {
        public string ForType { get; } = NEW_GEBA.RecordType;

        public void Read(CsvReader csvReader, Repository repository)
        {
            var record = csvReader.GetRecord<NEW_GEBA>();
            repository.NEW_GEBAs.Add(record.HAUSKEY_ALT, record);
        }
    }
}
