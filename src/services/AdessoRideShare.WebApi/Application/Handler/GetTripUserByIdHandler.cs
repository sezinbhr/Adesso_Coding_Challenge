using AdessoRideShare.Repository.DataAccess.Interfaces;
using AdessoRideShare.API.Application.Query;
using AdessoRideShare.API.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoRideShare.API.Application.Handler
{
    public class GetTripUserByIdHandler : IRequestHandler<GetTripUserByIdQuery, TripUserModel>
    {
        private readonly ITripUserRepository _travelPlanUserRepository;
        private readonly IMapper _mapper;
        public GetTripUserByIdHandler(IMapper mapper, ITripUserRepository travelPlanUserRepository)
        {
            _travelPlanUserRepository = travelPlanUserRepository;
            _mapper = mapper;
        }
        public async Task<TripUserModel> Handle(GetTripUserByIdQuery request, CancellationToken cancellationToken)
        {
            var resp =await _travelPlanUserRepository.GetAsync(x => x.Id == request.Id);
            return _mapper.Map<TripUserModel>(resp);
        }
    }
}
