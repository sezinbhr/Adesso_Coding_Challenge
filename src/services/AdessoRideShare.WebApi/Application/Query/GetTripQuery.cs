using AdessoRideShare.API.Models;
using MediatR;
using System.Collections.Generic;

namespace AdessoRideShare.API.Application.Query
{
    public class GetTripQuery : IRequest<List<TripModel>>
    {
        public int FromId { get; set; }
        public int ToId { get; set; }

    }
}
