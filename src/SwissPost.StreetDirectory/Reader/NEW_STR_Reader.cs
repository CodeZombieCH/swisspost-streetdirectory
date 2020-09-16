using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader
{
    internal class NEW_STR_Reader : IReader
    {
        public string ForType { get; } = NEW_STR.RecordType;

        public void Read(CsvReader csvReader, Repository repository)
        {
            var record = csvReader.GetRecord<NEW_STR>();
            repository.NEW_STRs.Add(record.STRID, record);
        }
    }
}
