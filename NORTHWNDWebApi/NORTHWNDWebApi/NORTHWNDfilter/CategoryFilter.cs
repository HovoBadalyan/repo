using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NORTHWNDWebApi.NORTHWNDfilter
{
    public class CategoryFilter
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
