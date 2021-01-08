using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebTool_V1.Models
{
    public class GratefulnessUnit
    {
        public int GratefulnessUnitID { get; set; }
        public string Main { get; set; }
        public string Details { get; set; }

        public int GratefulnessEntryID { get; set; }
        public GratefulnessEntry GratefulnessEntry { get; set; }
    }
}
