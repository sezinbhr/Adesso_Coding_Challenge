using AdessoRideShare.API.Models;
using MediatR;
using System;

namespace AdessoRideShare.API.Application.Command
{
    public class AddUserTripCommand : IRequest<TripUserModel>
    {
        public TripModel model { get; set; }

    }
}
