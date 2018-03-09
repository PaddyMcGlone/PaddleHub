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
        public IHttpActionResult Attend(int paddleId)
        {
            var gig = _context.Paddles.Find(paddleId);

            return Ok(200);
        };

        #endregion
    }
}
