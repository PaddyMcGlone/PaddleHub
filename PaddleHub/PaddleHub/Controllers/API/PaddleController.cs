using Microsoft.AspNet.Identity;
using PaddleHub.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace PaddleHub.Controllers.API
{
    [Authorize]
    public class PaddleController : ApiController
    {
        #region Properties
        private ApplicationDbContext _context;
        #endregion

        #region Constructor
        public PaddleController()
        {
            _context = new ApplicationDbContext();
        }
        #endregion

        #region Methods
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var paddle = _context.Paddles.SingleOrDefault(p => p.Id == id && p.PaddlerId == userId);
            if (paddle == null || paddle.IsCancelled) return NotFound();

            paddle.IsCancelled = true;
            _context.SaveChanges();

            var notification = new Notification
            {
                DateTime         = DateTime.Now,
                Paddle           = paddle,
                NotificationType = NotificationType.Cancelled
            };

            var attendees = _context.Attendances
                .Where(a => a.PaddleID == id)
                .Select(a => a.Attendee).ToList();

            foreach (var attendee in attendees)
            {
                attendee.Notify(notification);                
            }

            _context.SaveChanges();

            return Ok(id.ToString());
        }
        #endregion
    }
}
