using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShare.API.Models
{
    public class TripModel
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int MaxSeat { get; set; }
        public LocationModel From { get; set; }
        public LocationModel To { get; set; }
        public int AvailableSeat { get { return MaxSeat - TotalPassenger; } }
        public int TotalPassenger { get; set; }
        public int Status { get; set; }



    }
}
