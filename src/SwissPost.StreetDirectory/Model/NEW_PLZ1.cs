using CsvHelper.Configuration.Attributes;
using System;

namespace SwissPost.StreetDirectory.Model
{
    /// <summary>
    /// Contains all postcodes valid for addresses in Switzerland and the Principality of Liechtenstein.
    /// </summary>
    public class NEW_PLZ1
    {
        /// <summary>
        /// Record type
        /// </summary>
        /// <remarks>
        /// See "2.2 Record types"
        /// </remarks>
        public const string RecordType = "01";

        [Index(0)]
        public string REC_ART { get; set; }

        /// <summary>
        /// Swiss Post classification number (primary key)
        /// </summary>
        [Index(1)]
        public int ONRP { get; set; }

        /// <summary>
        /// Foreign key for BFSNR (refers to NEW_COM)
        /// </summary>
        [Index(2)]
        public int BFSNR { get; set; }

        /// <summary>
        /// Postcode type
        /// </summary>
        [Index(3)]
        public int PLZ_TYP { get; set; }

        /// <summary>
        /// Address postcode
        /// </summary>
        [Index(4)]
        public int POSTCODE { get; set; }

        /// <summary>
        /// Additional postcode number
        /// </summary>
        [Index(5)]
        public string PLZ_ZZ { get; set; }

        /// <summary>
        /// Basic postcode
        /// </summary>
        [Index(6)]
        public int GPLZ { get; set; }

        /// <summary>
        /// 18-character locality name
        /// </summary>
        [Index(7)]
        public string ORTBEZ18 { get; set; }

        /// <summary>
        /// 27-character locality name
        /// </summary>
        [Index(8)]
        public string ORTBEZ27 { get; set; }

        /// <summary>
        /// Canton
        /// </summary>
        [Index(9)]
        public string CANTON { get; set; }

        /// <summary>
        /// Language code
        /// </summary>
        [Index(10)]
        public LanguageCode LANGUAGECODE { get; set; }

        /// <summary>
        /// Different language code
        /// </summary>
        [Index(11)]
        public LanguageCode? SPRACHCODE_ABW { get; set; }

        /// <summary>
        /// Delivery office
        /// </summary>
        [Index(12)]
        public int? BRIEFZ_DURCH { get; set; }

        /// <summary>
        /// Valid as of
        /// </summary>
        [Index(13)]
        public DateTime GILT_AB_DAT { get; set; }

        /// <summary>
        /// Delivery office postcode
        /// </summary>
        [Index(14)]
        public int PLZ_BRIEFZUST { get; set; }

        [Index(15)]
        public bool? PLZ_COFF { get; set; }
    }
}
