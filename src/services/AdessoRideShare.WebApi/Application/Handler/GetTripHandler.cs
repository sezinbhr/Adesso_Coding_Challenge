using AdessoRideShare.Repository.DataAccess.Interfaces;
using AdessoRideShare.API.Application.Query;
using AdessoRideShare.API.Models;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoRideShare.API.Application.Handler
{
    public class GetTripHandler : IRequestHandler<GetTripQuery, List<TripModel>>
    {
        private readonly ITripRepository _travelPlanRepository;
        private readonly ITripUserRepository _travelPlanUserRepository;
        private readonly IMapper _mapper;
        public GetTripHandler(ITripRepository travelPlanRepository, IMapper mapper, ITripUserRepository travelPlanUserRepository)
        {
            _travelPlanRepository = travelPlanRepository;
            _travelPlanUserRepository = travelPlanUserRepository;
            _mapper = mapper;
        }
        public async Task<List<TripModel>> Handle(GetTripQuery request, CancellationToken cancellationToken)
        {
             var resp =await _travelPlanRepository.GetTripByFromIdToId(request.FromId,request.ToId);
              resp=await _travelPlanUserRepository.GetTripTotalUsers(resp);
            return  _mapper.Map<List<TripModel>>(resp);
        }
    }
}
