using CsvHelper.Configuration.Attributes;

namespace SwissPost.StreetDirectory.Model
{
    /// <summary>
    /// Contains alternative locality and area names for each postcode.
    /// </summary>
    public class NEW_PLZ2
    {
        /// <summary>
        /// Record type
        /// </summary>
        /// <remarks>
        /// See "2.2 Record types"
        /// </remarks>
        public const string RecordType = "02";

        [Index(0)]
        public string REC_ART { get; set; }

        /// <summary>
        /// Swiss Post classification number (primary key)
        /// </summary>
        [Index(1)]
        public int ONRP { get; set; }

        /// <summary>
        /// Sequence number within an ONRP
        /// </summary>
        [Index(2)]
        public int LAUFNUMMER { get; set; }

        /// <summary>
        /// Designation types
        /// </summary>
        [Index(3)]
        public int BEZTYP { get; set; }

        /// <summary>
        /// Language code
        /// </summary>
        [Index(4)]
        public LanguageCode SPRACHCODE { get; set; }

        /// <summary>
        /// 18-character locality name
        /// </summary>
        [Index(5)]
        public string ORTBEZ18 { get; set; }

        /// <summary>
        /// 27-character locality name
        /// </summary>
        [Index(6)]
        public string ORTBEZ27 { get; set; }
    }
}
