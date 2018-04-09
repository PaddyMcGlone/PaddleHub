using Microsoft.AspNet.Identity;
using PaddleHub.DTOs;
using PaddleHub.Models;
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
        public IHttpActionResult Cancel(PaddleDTO dto)
        {
            var userId = User.Identity.GetUserId();
            var paddle = _context.Paddles.SingleOrDefault(p => p.Id == dto.Id && p.PaddlerId == userId);
            if (paddle == null) return BadRequest("Unable to retrieve paddle");

            paddle.IsCancelled = true;
            _context.SaveChanges();

            return Ok(dto.Id.ToString());
        }
        #endregion
    }
}
