using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databased
{
    public class HouseDetails
    {
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Bathrooms { get; set; }
        public int Bedrooms { get; set; }
        public decimal Cost { get; set; }
        public short YearBuilt { get; set; }
    }
}
