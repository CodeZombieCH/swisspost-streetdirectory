using CsvHelper.Configuration.Attributes;

namespace SwissPost.StreetDirectory.Model
{
    /// <summary>
    /// Contains mail carrier information at house number level (letter delivery).
    /// </summary>
    public class NEW_BOT_B
    {
        /// <summary>
        /// Record type
        /// </summary>
        /// <remarks>
        /// See "2.2 Record types"
        /// </remarks>
        public const string RecordType = "08";

        [Index(0)]
        public string REC_ART { get; set; }

        /// <summary>
        /// Foreign address key (house, house entrance). Refers to NEW_GEB.
        /// </summary>
        [Index(1)]
        public int HAUSKEY { get; set; }

        /// <summary>
        /// Address postcode
        /// </summary>
        [Index(2)]
        public int APLZ { get; set; }

        /// <summary>
        /// Postcode of the mail carrier district for letter delivery, for complete address, postcode of the P.O. Box office.
        /// </summary>
        [Index(3)]
        public int BBZPLZ { get; set; }

        [Index(4)]
        public int BOTENBEZ { get; set; }

        /// <summary>
        /// Sequence in district. Always 0 for complete addresses.
        /// </summary>
        [Index(5)]
        public int ETAPPENNR { get; set; }

        /// <summary>
        /// Sequence at stage. Always 0 for complete addresses.
        /// </summary>
        [Index(6)]
        public int LAUFNR { get; set; }

        /// <summary>
        /// Reloading depot
        /// </summary>
        [Index(7)]
        public string NDEPOT { get; set; }
    }
}
