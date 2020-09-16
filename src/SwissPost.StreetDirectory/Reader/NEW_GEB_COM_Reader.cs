using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader
{
    internal class NEW_GEB_COM_Reader : IReader
    {
        public string ForType { get; } = NEW_GEB_COM.RecordType;

        public void Read(CsvReader csvReader, Repository repository)
        {
            var record = csvReader.GetRecord<NEW_GEB_COM>();
            repository.NEW_GEB_COMs.Add(record);
        }
    }
}
