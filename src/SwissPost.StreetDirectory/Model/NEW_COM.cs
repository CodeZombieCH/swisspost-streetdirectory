using CsvHelper.Configuration.Attributes;

namespace SwissPost.StreetDirectory.Model
{
    /// <summary>
    /// Contains the political municipalities in Switzerland and the Principality of Liechtenstein.
    /// These data are taken from the official list of the Swiss Federal Statistical Office (BFS).
    /// </summary>
    public class NEW_COM
    {
        /// <summary>
        /// Record type
        /// </summary>
        /// <remarks>
        /// See "2.2 Record types"
        /// </remarks>
        public const string RecordType = "03";

        [Index(0)]
        public string REC_ART { get; set; }

        /// <summary>
        /// BFS number
        /// </summary>
        [Index(1)]
        public int BFSNR { get; set; }

        /// <summary>
        /// Municipality name
        /// </summary>
        [Index(2)]
        public string GEMEINDENAME { get; set; }

        /// <summary>
        /// Canton
        /// </summary>
        [Index(3)]
        public string KANTON { get; set; }

        /// <summary>
        /// Conurbation number
        /// </summary>
        [Index(4)]
        public int? AGGLONR { get; set; }
    }
}
