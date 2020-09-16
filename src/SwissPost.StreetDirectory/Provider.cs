using CsvHelper;
using SwissPost.StreetDirectory.Converter;
using SwissPost.StreetDirectory.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissPost.StreetDirectory
{
    public class Provider
    {
        private Dictionary<string, Action<CsvReader, Repository>> readers;

        public Provider()
        {
            InitializeMapping();
        }

        private void InitializeMapping()
        {
            // Manually typed mapping
            // Could be automatically mapped by using reflection
            //readingFunctions = new Dictionary<string, Action<CsvReader, Repository>>() {
            //    {
            //        NEW_GEB.RecordType,
            //        (csvReader, repository) => {
            //            var record = csvReader.GetRecord<NEW_GEB>();
            //            repository.NEW_GEBs.Add(record.HOUSEKEY, record);
            //        }
            //    },
            //    {
            //        NEW_PLZ1.RecordType,
            //        (csvReader, repository) => {
            //            var record = csvReader.GetRecord<NEW_PLZ1>();
            //            repository.NEW_PLZ1s.Add(record.ONRP, record);
            //        }
            //    },
            //    {
            //        NEW_STR.RecordType,
            //        (csvReader, repository) => {
            //            var record = csvReader.GetRecord<NEW_STR>();
            //            repository.NEW_STRs.Add(record.STRID, record);
            //        }
            //    }
            //};

            readers = new Dictionary<string, Action<CsvReader, Repository>>();

            var readerInterface = typeof(Reader.IReader);
            var readerTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => readerInterface.IsAssignableFrom(p) && !p.IsInterface);

            foreach (var readerType in readerTypes)
            {
                var reader = (Reader.IReader)Activator.CreateInstance(readerType);
                readers.Add(reader.ForType, reader.Read);
            }
        }

        public async Task<Repository> Read(StreamReader reader)
        {
            var repository = new Repository();

            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csvReader.Configuration.TypeConverterCache.AddConverter<bool>(new BooleanConverter());
                csvReader.Configuration.TypeConverterCache.AddConverter<DateTime>(new DateConverter());
                csvReader.Configuration.TypeConverterCache.AddConverter<LanguageCode>(new LanguageCodeConverter());
                csvReader.Configuration.TypeConverterCache.AddConverter<StreetLocationType>(new StreetLocationTypeConverter());

                // Use semi-colon (";") as described in the official documentation
                csvReader.Configuration.Delimiter = ";";

                // As we have no information about what quote character is used,
                // we use the exotic BELL control character as it should never be present in the document
                csvReader.Configuration.Quote = '\u0007';

                csvReader.Configuration.HasHeaderRecord = false;

                while (await csvReader.ReadAsync())
                {
                    var recordType = csvReader.GetField<string>(0);

                    if (!readers.ContainsKey(recordType))
                    {
                        // TODO: Log unsupported record type
                        continue;
                    }

                    var readingFunction = readers[recordType];
                    readingFunction.Invoke(csvReader, repository);
                }
            }

            return repository;
        }
    }
}
