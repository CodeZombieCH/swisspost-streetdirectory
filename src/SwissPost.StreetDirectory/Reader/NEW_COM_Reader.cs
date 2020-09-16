using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader
{
    internal class NEW_COM_Reader : IReader
    {
        public string ForType { get; } = NEW_COM.RecordType;

        public void Read(CsvReader csvReader, Repository repository)
        {
            var record = csvReader.GetRecord<NEW_COM>();
            repository.NEW_COMs.Add(record.BFSNR, record);
        }
    }
}
