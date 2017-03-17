using AutoMapper;
using GigHubApp.Controllers.Apis;
using GigHubApp.Dtos;
using GigHubApp.Models;

namespace GigHubApp.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<Gig, GigDto>();
            CreateMap<Notification, NotificationDto>();
        }
    }
}