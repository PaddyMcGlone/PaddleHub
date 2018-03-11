using Microsoft.AspNet.Identity;
using PaddleHub.DTOs;
using PaddleHub.Models;
using System.Linq;
using System.Web.Http;

namespace PaddleHub.Controllers
{
    //[Authorize]
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
        /// <param name="PaddleId">Paddle identifier</param>
        /// <returns></returns>        
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDTO dto)
        {
            var userId = User.Identity.GetUserId();
            var alreadyAttending = _context.Attendances.Any(a => a.AttendeeId == userId && a.PaddleID == dto.GigId);
            if (alreadyAttending) return BadRequest("Already attending this event");

            var attendance = new Attendance
            {
                AttendeeId = userId,
                PaddleID   = dto.GigId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok(200);
        }

        #endregion
    }
}
