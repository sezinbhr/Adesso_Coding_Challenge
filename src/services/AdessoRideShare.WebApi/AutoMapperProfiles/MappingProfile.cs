using AdessoRideShare.Repository.EntityModel.Concrete;
using AdessoRideShare.API.Application.Command;
using AdessoRideShare.API.Models;
using AutoMapper;

namespace AdessoRideShare.API.AutoMapperProfiles
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Trip, TripModel>().ReverseMap();
            CreateMap<Location, LocationModel>().ReverseMap();
            CreateMap<User,UserModel >().ReverseMap();
            CreateMap<AddUserTripCommand, TripUsers>().ReverseMap();
            CreateMap<TripUserModel, TripUsers>().ReverseMap();
            CreateMap<UpdateUserTripCommand, TripUsers>().ReverseMap();
            CreateMap<User, AddUserCommand>().ReverseMap();
        }
    }
}
