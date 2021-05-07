using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourWebVanzonokRV.Models
{
    public class TourModelVanzonokRV
    {
        public int tourID { get; set; }
        public string title { get; set; }
        public int totalSum { get; set; }
        public string description { get; set; }
        public int transportID { get; set; }
        public int countryID { get; set; }
    }
}
