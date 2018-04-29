using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using PaddleHub.Models;

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

        public List<Notification> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = context.UserNotifcations
                .Where(un => un.UserId == userId)
                .Select(un => un.Notification)
                .Include(n => n.Paddle.Paddler)
                .ToList();

            return notifications;
        }
    }
}
