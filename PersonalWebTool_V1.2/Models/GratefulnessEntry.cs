using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebTool_V1.Models
{
    public class GratefulnessEntry
    {
        public int GratefulnessEntryID { get; set; }
        public DateTime DateCreated { get; set; }

        public ICollection<GratefulnessUnit> GratefulnessUnits { get; set; }

        public GratefulnessEntry()  
        {
            DateCreated = DateTime.Now;
        }
    }
}
