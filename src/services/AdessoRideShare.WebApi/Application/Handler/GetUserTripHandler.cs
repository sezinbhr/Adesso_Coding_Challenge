using AdessoRideShare.Repository.DataAccess.Interfaces;
using AdessoRideShare.Repository.EntityModel.Concrete;
using AdessoRideShare.API.Application.Query;
using AdessoRideShare.API.Models;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoRideShare.API.Application.Handler
{
    public class GetUserTripHandler : IRequestHandler<GetUserTripQuery, List<TripModel>>
    {
        private readonly ITripUserRepository _travelPlanUserRepository;
        private readonly IMapper _mapper;
        public GetUserTripHandler(IMapper mapper, ITripUserRepository travelPlanUserRepository)
        {
            _travelPlanUserRepository = travelPlanUserRepository;
            _mapper = mapper;
        }
        public async Task<List<TripModel>> Handle(GetUserTripQuery request, CancellationToken cancellationToken)
        {
            List<Trip> resp = new List<Trip>();
            if(request.FromId==null || request.ToId==null)
                resp = await _travelPlanUserRepository.GetUserTripPlans(request.UserId);
            else
                resp = await _travelPlanUserRepository.GetUserTripsByFromIdToId(request.UserId,request.FromId.Value,request.ToId.Value);
            
            resp = await _travelPlanUserRepository.GetTripTotalUsers(resp);
            return _mapper.Map<List<TripModel>>(resp);
        }
    }
}
