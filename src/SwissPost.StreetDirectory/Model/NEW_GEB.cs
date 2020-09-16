using CsvHelper.Configuration.Attributes;

namespace SwissPost.StreetDirectory.Model
{
    /// <summary>
    /// Contains house numbers and house keys.
    /// </summary>
    public class NEW_GEB
    {
        /// <summary>
        /// Record type
        /// </summary>
        /// <remarks>
        /// See "2.2 Record types"
        /// </remarks>
        public const string RecordType = "06";

        [Index(0)]
        public string REC_ART { get; set; }

        /// <summary>
        /// House key
        /// </summary>
        [Index(1)]
        public int HOUSEKEY { get; set; }

        /// <summary>
        /// Foreign key for street names (refers to NEW_STR).
        /// </summary>
        [Index(2)]
        public int STRID { get; set; }

        /// <summary>
        /// House number
        /// </summary>
        [Index(3)]
        public int? HNR { get; set; }

        /// <summary>
        /// Alphanumerical part of the house number
        /// </summary>
        [Index(4)]
        public string HNRA { get; set; }

        /// <summary>
        /// House number status
        /// </summary>
        [Index(5)]
        public bool HNR_COFF { get; set; }

        /// <summary>
        /// Complete house number
        /// </summary>
        [Index(6)]
        public bool? GANZFACH { get; set; }

        /// <summary>
        /// ONRP of the P.O. Box office for complete addresses
        /// </summary>
        [Index(7)]
        public int? FACH_ONRP { get; set; }
    }
}
