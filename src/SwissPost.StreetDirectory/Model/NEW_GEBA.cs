using CsvHelper.Configuration.Attributes;

namespace SwissPost.StreetDirectory.Model
{
    /// <summary>
    /// Contains alternative house names and alternative house keys
    /// </summary>
    public class NEW_GEBA
    {
        /// <summary>
        /// Record type
        /// </summary>
        /// <remarks>
        /// See "2.2 Record types"
        /// </remarks>
        public const string RecordType = "07";

        [Index(0)]
        public string REC_ART { get; set; }

        /// <summary>
        /// House key (primary key)
        /// </summary>
        [Index(1)]
        public int HAUSKEY_ALT { get; set; }

        /// <summary>
        /// Foreign address key (house, house entrance). Refers to NEW_GEB.
        /// </summary>
        [Index(2)]
        public int HAUSKEY { get; set; }

        /// <summary>
        /// Additional building name
        /// </summary>
        [Index(3)]
        public string GEB_BEZ_ALT { get; set; }

        [Index(4)]
        public int GEBTYP { get; set; }
    }
}
