using System;
using System.Collections.Generic;

namespace AdessoRideShare.Repository.EntityModel.Concrete
{
    public class Trip : BaseEntityModel
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int MaxSeat { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public int TotalPassenger{ get; set; }
        public int AvailableSeat { get { return MaxSeat - TotalPassenger; } }
        public int Status { get; set; }
        public virtual Location From { get; set; }
        public virtual Location To { get; set; }

    }
}
