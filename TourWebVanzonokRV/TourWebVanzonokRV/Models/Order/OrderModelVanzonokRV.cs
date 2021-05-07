using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourWebVanzonokRV.Models
{
    public class OrderModelVanzonokRV
    {
        public int orderID { get; set; }
        public string status { get; set; }
        public int tourID { get; set; }
        public string userName { get; set; }
        public string userLastName { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }
        public string title { get; set; }
        public string totalSum { get; set; }
    }
}
