using Microsoft.AspNet.Identity;
using PaddleHub.DTOs;
using PaddleHub.Models;
using System.Linq;
using System.Web.Http;

namespace PaddleHub.Controllers.API
{
    [Authorize]
    public class AttendancesController : ApiController
    {       
        private ApplicationDbContext _context;

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Attend method
        /// </summary>        
        /// <param name="dto"></param>
        /// <returns></returns>        
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDTO dto)
        {
            var userId = User.Identity.GetUserId();
            var alreadyAttending = _context.Attendances.Any(a => a.AttendeeId == userId && a.PaddleID == dto.PaddleId);
            if (alreadyAttending) return BadRequest("Already attending this event");

            var attendance = new Attendance
            {
                AttendeeId = userId,
                PaddleID   = dto.PaddleId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok(200);
        }

        /// <summary>
        /// Remove an attendance
        /// </summary>
        /// <param name="id">The Paddle id</param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            var attendance = _context.Attendances
                .SingleOrDefault(a => a.PaddleID == id && a.AttendeeId == userId);
            
            if (attendance == null) return BadRequest("No attendance recorded for this event");

            _context.Attendances.Remove(attendance);
            _context.SaveChanges();
            return Ok(200);
        }

        #endregion
    }
}
