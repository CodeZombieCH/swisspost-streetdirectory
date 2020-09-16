using CsvHelper.Configuration.Attributes;
using System;

namespace SwissPost.StreetDirectory.Model
{
    /// <summary>
    /// Link between building and municipality information.
    /// </summary>
    public class NEW_GEB_COM
    {
        /// <summary>
        /// Record type
        /// </summary>
        /// <remarks>
        /// See "2.2 Record types"
        /// </remarks>
        public const string RecordType = "12";

        [Index(0)]
        public string REC_ART { get; set; }

        /// <summary>
        /// House key
        /// </summary>
        [Index(1)]
        public int HOUSEKEY { get; set; }

        /// <summary>
        /// Foreign key to NEW_COM table that includes all municipalities.
        /// </summary>
        [Index(2)]
        public int BFSNR { get; set; }

        /// <summary>
        /// Valid as of
        /// </summary>
        [Index(3)]
        public DateTime GILT_AB { get; set; }
    }
}
