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
                    .Where(p => p.DateTime > DateTime.Now 
                                && !p.IsCancelled);

            var viewModel = new PaddleViewModel
            {
                UpcomingPaddles = upcomingPaddles,
                UserAuthorised  = User.Identity.IsAuthenticated,
                Heading         = "Upcoming paddles" 
            };

            return View("Paddle", viewModel);
        }
        #endregion
        
    }
}