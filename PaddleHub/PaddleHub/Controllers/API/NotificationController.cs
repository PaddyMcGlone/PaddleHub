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
        #region Fields
        private ApplicationDbContext context;
        #endregion

        #region Constructor
        public NotificationController(ApplicationDbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Methods
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();

            var notifications = context.UserNotifcations
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Paddle.Paddler)
                .ToList();

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }
        #endregion
    }
}
