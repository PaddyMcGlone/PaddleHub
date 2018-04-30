using AutoMapper;
using PaddleHub.Models;

namespace PaddleHub.App_Start
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// AutoMapper profile constructor
        /// </summary>
        public MappingProfile()
        {
            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<PaddleType, PaddleTypeDto>();
            Mapper.CreateMap<Paddle, PaddleDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
        }
    }
}