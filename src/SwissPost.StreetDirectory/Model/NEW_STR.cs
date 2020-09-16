using CsvHelper.Configuration.Attributes;

namespace SwissPost.StreetDirectory.Model
{
    /// <summary>
    /// Contains all the street names of every locality in Switzerland and the Principality of Liechtenstein.
    /// </summary>
    public class NEW_STR
    {
        /// <summary>
        /// Record type
        /// </summary>
        /// <remarks>
        /// See "2.2 Record types"
        /// </remarks>
        public const string RecordType = "04";

        [Index(0)]
        public string REC_ART { get; set; }

        /// <summary>
        /// Street name (primary key)
        /// </summary>
        [Index(1)]
        public int STRID { get; set; }

        /// <summary>
        /// Swiss Post classification number (primary key)
        /// </summary>
        [Index(2)]
        public int ONRP { get; set; }

        /// <summary>
        /// Abbreviated street name
        /// </summary>
        [Index(3)]
        public string STRBEZK { get; set; }

        /// <summary>
        /// Full street name
        /// </summary>
        [Index(4)]
        public string STRBEZL { get; set; }

        /// <summary>
        /// Abbreviated reorganized street name
        /// </summary>
        [Index(5)]
        public string STRBEZ2K { get; set; }

        /// <summary>
        /// Reorganized street name
        /// </summary>
        [Index(6)]
        public string STRBEZ2L { get; set; }

        /// <summary>
        /// Street location type
        /// </summary>
        [Index(7)]
        public StreetLocationType STR_LOK_TYP { get; set; }

        /// <summary>
        /// Street language
        /// </summary>
        [Index(8)]
        public LanguageCode STRBEZ_SPC { get; set; }

        /// <summary>
        /// Shows whether a name is officially recognized, i.e. by the political municipality.
        /// </summary>
        [Index(9)]
        public bool STRBEZ_COFF { get; set; }

        /// <summary>
        /// Complete address
        /// </summary>
        [Index(10)]
        public bool? STR_GANZFACH { get; set; }

        /// <summary>
        /// ONRP of the P.O. Box office
        /// </summary>
        [Index(11)]
        public int? STR_FACH_ONRP { get; set; }
    }
}
