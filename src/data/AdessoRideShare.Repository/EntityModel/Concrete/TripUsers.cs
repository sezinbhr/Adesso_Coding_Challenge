using System;
using System.Collections.Generic;
using System.Text;

namespace AdessoRideShare.Repository.EntityModel.Concrete
{
    public class TripUsers : BaseEntityModel
    {
        public Trip TravelPlan { get; set; }
        public int TravelPlanId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public int SeatCount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
