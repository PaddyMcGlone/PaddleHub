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

            return notifications.Select(n => new NotificationDto
            {
                DateTime = n.DateTime,
                Paddle = new PaddleDto
                {
                    Id = n.Paddle.Id,
                    DateTime = n.Paddle.DateTime,
                    IsCancelled = n.Paddle.IsCancelled,
                    Location = n.Paddle.Location,
                    Paddler = new UserDto
                    {
                        Id = n.Paddle.PaddlerId,
                        Name = n.Paddle.Paddler.UserDetails.Name()
                    },
                    PaddleType = new PaddleTypeDto
                    {
                        Id = n.Paddle.PaddleType.Id,
                        Name = n.Paddle.PaddleType.Name
                    }                                        
                },
                OriginalDateTime = n.OriginalDateTime,
                OriginalLocation = n.OriginalLocation
            });
        }
    }
}
