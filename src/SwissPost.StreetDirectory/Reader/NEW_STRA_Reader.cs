using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader
{
    internal class NEW_STRA_Reader : IReader
    {
        public string ForType { get; } = NEW_STRA.RecordType;

        public void Read(CsvReader csvReader, Repository repository)
        {
            var record = csvReader.GetRecord<NEW_STRA>();
            repository.NEW_STRAs.Add(record.STRID_ALT, record);
        }
    }
}
