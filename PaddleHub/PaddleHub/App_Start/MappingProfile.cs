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
            Mapper.CreateMap<ApplicationUser, UserDto>()
                .ForMember(d => d.Name, opts => opts.MapFrom(s => s.UserDetails.Name()));
            Mapper.CreateMap<PaddleType, PaddleTypeDto>();
            Mapper.CreateMap<Paddle, PaddleDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
        }
    }
}