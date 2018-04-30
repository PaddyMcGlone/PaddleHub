using AutoMapper;
using Microsoft.AspNet.Identity;
using PaddleHub.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace PaddleHub.Controllers.API
{
    [Authorize]
    public class NotificationController : ApiController
    {
        private ApplicationDbContext context;

        public NotificationController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = context.UserNotifcations
                .Where(un => un.UserId == userId)
                .Select(un => un.Notification)
                .Include(n => n.Paddle.Paddler)
                .ToList();

            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<PaddleType, PaddleTypeDto>();
            Mapper.CreateMap<Paddle, PaddleDto>();
            Mapper.CreateMap<Notification, NotificationDto>();

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }
    }
}
