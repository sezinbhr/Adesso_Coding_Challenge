using AdessoRideShare.API.Models;
using MediatR;

namespace AdessoRideShare.API.Application.Query
{
    public class GetTripUserByIdQuery:IRequest<TripUserModel>
    {
        public int Id { get; set; }
    }
}
