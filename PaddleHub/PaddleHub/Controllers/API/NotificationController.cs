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
        public NotificationController()
        {
            context = new ApplicationDbContext();
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
                .Include(n => n.Paddle.Paddler.UserDetails)
                .ToList();

            var result  = notifications.Select(Mapper.Map<Notification, NotificationDto>);
            return result;
        }
        #endregion
    }
}
