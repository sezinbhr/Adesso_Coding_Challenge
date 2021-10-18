using AdessoRideShare.Repository.EntityModel.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShare.API.Models
{
    public class TripUserModel
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public int SeatCount { get; set; }
        public string Description { get; set; }


    }
}
