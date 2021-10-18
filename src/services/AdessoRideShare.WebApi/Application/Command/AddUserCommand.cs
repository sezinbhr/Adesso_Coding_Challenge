using AdessoRideShare.API.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShare.API.Application.Command
{
    public class AddUserCommand : IRequest<UserModel>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
