using CsvHelper.Configuration.Attributes;
using System;

namespace SwissPost.StreetDirectory.Model
{
    /// <summary>
    /// Contains the version date and a unique random code.
    /// </summary>
    public class NEW_HEA
    {
        /// <summary>
        /// Record type
        /// </summary>
        /// <remarks>
        /// See "2.2 Record types"
        /// </remarks>
        public const string RecordType = "00";

        [Index(0)]
        public string REC_ART { get; set; }
        /// <summary>
        /// Date of implementation
        /// </summary>
        [Index(1)]
        public DateTime VDAT { get; set; }
        /// <summary>
        /// Randomly generated code
        /// </summary>
        [Index(2)]
        public string ZCODE { get; set; }
    }
}
