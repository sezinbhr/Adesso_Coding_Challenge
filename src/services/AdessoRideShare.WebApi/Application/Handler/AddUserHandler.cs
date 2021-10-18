using AdessoRideShare.Repository.DataAccess.Interfaces;
using AdessoRideShare.Repository.EntityModel.Concrete;
using AdessoRideShare.API.Application.Command;
using AdessoRideShare.API.Models;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoRideShare.API.Application.Handler
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, UserModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AddUserHandler(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserModel> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user=_mapper.Map<User>(request);
            var resp=await _userRepository.AddAsync(user);
            return _mapper.Map<UserModel>(resp);
        }
    }
}
