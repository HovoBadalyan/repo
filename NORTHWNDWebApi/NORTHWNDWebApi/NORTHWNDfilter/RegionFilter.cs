using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NORTHWNDWebApi.NORTHWNDfilter
{
    public class RegionFilter
    {
        public int? RegionId { get; set; }
        public string RegionDescription { get; set; }
        public int? Skip { get; set; }
        public int Take { get; set; }
    }
}
