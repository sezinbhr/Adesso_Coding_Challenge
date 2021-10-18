using AdessoRideShare.Repository.DataAccess.Interfaces;
using AdessoRideShare.Repository.EntityModel.Concrete;
using AdessoRideShare.API.Application.Command;
using AdessoRideShare.API.Models;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoRideShare.API.Application.Handler
{
    public class UpdateUserTripHandler : IRequestHandler<UpdateUserTripCommand, TripUserModel>
    {
        private readonly ITripUserRepository _travelPlanUserRepository;
        private readonly IMapper _mapper;
        public UpdateUserTripHandler(IMapper mapper, ITripUserRepository travelPlanUserRepository)
        {
            _travelPlanUserRepository = travelPlanUserRepository;
            _mapper = mapper;
        }
        public async Task<TripUserModel> Handle(UpdateUserTripCommand request, CancellationToken cancellationToken)
        {
            var entity=_mapper.Map<TripUsers>(request);
            var updatedEntity=await _travelPlanUserRepository.UpdateAsync(entity);
            return _mapper.Map<TripUserModel>(updatedEntity);
        }
    }
}
