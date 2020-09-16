using CsvHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwissPost.StreetDirectory.Reader
{
    internal interface IReader
    {
        string ForType { get; }
        void Read(CsvReader csvReader, Repository repository);
    }
}
