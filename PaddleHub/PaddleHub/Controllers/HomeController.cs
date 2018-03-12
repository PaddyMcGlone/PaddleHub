using Microsoft.AspNet.Identity;
using PaddleHub.Models;
using PaddleHub.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace PaddleHub.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext _context;

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        #endregion        

        #region Methods
        
        /// <summary>
        /// Index - returns the home view
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var upcomingPaddles = _context.Paddles
                    .Include(p => p.Paddler)
                    .Include(p => p.Paddler.UserDetails)
                    .Include(p => p.PaddleType)
                    .Where(p => p.DateTime > DateTime.Now);

            var viewModel = new HomeViewModel
            {
                UpcomingPaddles = upcomingPaddles,
                UserAuthorised = User.Identity.IsAuthenticated
            };

            return View(viewModel);
        }

        /// <summary>
        /// Attendance - returns an attendance view
        /// </summary>
        /// <returns></returns>
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var attending = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Paddle)
                .ToList();

            return View(attending);
        }       

        #endregion
    }
}