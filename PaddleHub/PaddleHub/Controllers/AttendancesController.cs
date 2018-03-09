using Microsoft.AspNet.Identity;
using PaddleHub.Models;
using System.Web.Http;

namespace PaddleHub.Controllers
{
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
        [Authorize]
        public IHttpActionResult Attend(int paddleId)
        {
            var attendance = new Attendance
            {
                AttendeeId = User.Identity.GetUserId(),
                PaddleID = paddleId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok(200);
        }

        #endregion
    }
}
