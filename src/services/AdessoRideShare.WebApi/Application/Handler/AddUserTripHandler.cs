using AdessoRideShare.Repository.DataAccess.Interfaces;
using AdessoRideShare.Repository.EntityModel.Concrete;
using AdessoRideShare.API.Application.Command;
using AdessoRideShare.API.Enums;
using AdessoRideShare.API.Models;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoRideShare.API.Application.Handler
{
    public class AddUserTripHandler : IRequestHandler<AddUserTripCommand, TripUserModel>
    {
        private readonly ITripUserRepository _travelPlanUserRepository;
        private readonly IMapper _mapper;
        public AddUserTripHandler(IMapper mapper, ITripUserRepository travelPlanUserRepository)
        {
            _travelPlanUserRepository = travelPlanUserRepository;
            _mapper = mapper;
        }
        public async Task<TripUserModel> Handle(AddUserTripCommand request, CancellationToken cancellationToken)
        {
            var travelPlanUser=_mapper.Map<TripUsers>(request);
            travelPlanUser.Status = (int)Status.Active;
            var resp =await _travelPlanUserRepository.AddAsync(travelPlanUser);

            return _mapper.Map<TripUserModel>(resp);
        }
    }
}
