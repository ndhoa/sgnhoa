using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TESTHANNMCAPI.Models
{
    public class AirShopRequest
    {
        [StringLength(2)]  //TripType chi chua ky tu "OW" hay "RT"
        public string TripType { get; set; }

        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }

        [StringLength(3)] //DepartureCity la ma thanh pho chi dai 3 ky tu
        public string DepartureCity { get; set; }

        [StringLength(3)]
        public string ArrivalCity { get; set; }
        public string ClassOfServices { get; set; }
        public string FlightType { get; set; }
        public int NumberOfAdt { get; set; }
        public int NumberOfChd { get; set; }
        public int NumberOfInf { get; set; }
    }
}
