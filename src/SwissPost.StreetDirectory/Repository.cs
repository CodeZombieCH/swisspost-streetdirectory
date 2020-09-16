using SwissPost.StreetDirectory.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwissPost.StreetDirectory
{
    public class Repository
    {
        public NEW_HEA NEW_HEA { get; set; }
        public List<NEW_BOT_B> NEW_BOT_Bs { get; } = new List<NEW_BOT_B>();
        public Dictionary<int, NEW_COM> NEW_COMs { get; } = new Dictionary<int, NEW_COM>();
        public Dictionary<int, NEW_GEB> NEW_GEBs { get; } = new Dictionary<int, NEW_GEB>();
        public List<NEW_GEB_COM> NEW_GEB_COMs { get; } = new List<NEW_GEB_COM>();
        public Dictionary<int, NEW_GEBA> NEW_GEBAs { get; } = new Dictionary<int, NEW_GEBA>();
        public Dictionary<int, NEW_PLZ1> NEW_PLZ1s { get; } = new Dictionary<int, NEW_PLZ1>();
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// No primary key field, could be combined from ONRP and LAUFNUMMER
        /// </remarks>
        public List<NEW_PLZ2> NEW_PLZ2s { get; } = new List<NEW_PLZ2>();
        public Dictionary<int, NEW_STR> NEW_STRs { get; } = new Dictionary<int, NEW_STR>();
        public Dictionary<int, NEW_STRA> NEW_STRAs { get; } = new Dictionary<int, NEW_STRA>();
    }
}
