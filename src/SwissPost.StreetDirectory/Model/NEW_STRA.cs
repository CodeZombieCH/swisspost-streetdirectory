using CsvHelper.Configuration.Attributes;

namespace SwissPost.StreetDirectory.Model
{
    /// <summary>
    /// Logical alternative or foreign language street name for the official street name.
    /// Building names without street/house number, area, plot or hamlet names are handled in the same way as street names.
    /// </summary>
    public class NEW_STRA
    {
        /// <summary>
        /// Record type
        /// </summary>
        /// <remarks>
        /// See "2.2 Record types"
        /// </remarks>
        public const string RecordType = "05";

        [Index(0)]
        public string REC_ART { get; set; }

        /// <summary>
        /// Primary key for alternative street names
        /// </summary>
        [Index(1)]
        public int STRID_ALT { get; set; }

        /// <summary>
        /// Foreign key for street names
        /// </summary>
        [Index(2)]
        public int STRID { get; set; }

        /// <summary>
        /// Street type
        /// </summary>
        [Index(3)]
        public int STRTYP { get; set; }

        /// <summary>
        /// Alternative street name (abbreviated or foreign language)
        /// </summary>
        [Index(4)]
        public string STRBEZAK { get; set; }

        /// <summary>
        /// Alternative street name
        /// </summary>
        [Index(5)]
        public string STRBEZAL { get; set; }

        /// <summary>
        /// Reorganized alternative street name (abbreviated or foreign language)
        /// </summary>
        [Index(6)]
        public string STRBEZA2K { get; set; }

        /// <summary>
        /// Reorganized alternative street name
        /// </summary>
        [Index(7)]
        public string STRBEZA2L { get; set; }

        /// <summary>
        /// Street location type
        /// </summary>
        [Index(8)]
        public int STR_LOK_TYP { get; set; }

        /// <summary>
        /// Street language
        /// </summary>
        [Index(9)]
        public LanguageCode STRBEZ_SPC { get; set; }
    }
}
