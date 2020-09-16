using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader
{
    internal class NEW_HEA_Reader : IReader
    {
        public string ForType { get; } = NEW_HEA.RecordType;

        public void Read(CsvReader csvReader, Repository repository)
        {
            var record = csvReader.GetRecord<NEW_HEA>();
            repository.NEW_HEA = record;
        }
    }
}
