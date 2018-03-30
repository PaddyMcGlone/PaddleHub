using Microsoft.AspNet.Identity;
using PaddleHub.DTOs;
using PaddleHub.Models;
using System.Linq;
using System.Web.Http;

namespace PaddleHub.Controllers
{
    [Authorize]
    public class FollowingController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FollowingController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowDTO dto)
        {
            var userId = User.Identity.GetUserId();
            var alreadyFollowing = _context
                .Users.Single(u => u.Id == userId)
                .Followees.Any(f => f.FolloweeId == dto.FolloweeId);

            if (alreadyFollowing) return BadRequest("Already following");            

            var following = new Following
            {
                FolloweeId = dto.FolloweeId,
                FollowerId = userId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok(200);
        }

    }
}
