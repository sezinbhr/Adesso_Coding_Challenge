using AdessoRideShare.API.Models;
using MediatR;
using System;

namespace AdessoRideShare.API.Application.Command
{
    public class UpdateUserTripCommand : IRequest<TripUserModel>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TravelPlanId { get; set; }
        public string Description { get; set; }
        public int SeatCount { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
    }
}
