using Microsoft.AspNet.Identity;
using PaddleHub.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace PaddleHub.Controllers
{
    public class UserController : Controller
    {
        #region Properties        
        private ApplicationDbContext _context;
        #endregion

        #region Constructor

        /// <summary>
        /// The default constructor
        /// </summary>
        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        #endregion

        /// <summary>
        /// The index action
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return RedirectToAction("Following");
        }

        /// <summary>
        /// The following or who am i following action
        /// </summary>
        /// <returns></returns>
        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();

            var following = _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(u => u.Followee)
                .Include(u => u.UserDetails)
                .ToList();

            return View(following);

        }
    }
}