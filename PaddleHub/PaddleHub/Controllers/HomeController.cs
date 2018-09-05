using Microsoft.AspNet.Identity;
using PaddleHub.Models;
using PaddleHub.Repositories;
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
        public AttendanceRepository AttendanceRepository;

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public HomeController()
        {
            _context = new ApplicationDbContext();
            AttendanceRepository = new AttendanceRepository(_context);
        }

        #endregion        

        #region Methods        
        
        [HttpPost]
        public ActionResult Search(PaddleViewModel viewModel)
        {
            return RedirectToAction("Index", "Home", new { Query = viewModel.SearchTerm });
        }

        /// <summary>
        /// Index - returns the home view
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string query = null)
        {
            var upcomingPaddles = _context.Paddles
                    .Include(p => p.Paddler)
                    .Include(p => p.Paddler.UserDetails)
                    .Include(p => p.PaddleType)
                    .Where(p => p.DateTime > DateTime.Now);

            upcomingPaddles = FilterUpcomingPaddles(query, upcomingPaddles);

            var attendances = AttendanceRepository
                .GetFutureAttendances(User.Identity.GetUserId())
                .ToLookup(a => a.PaddleID);

            var viewModel = new PaddleViewModel
            {
                UpcomingPaddles = upcomingPaddles,
                UserAuthorised  = User.Identity.IsAuthenticated,
                Heading         = "Upcoming paddles",
                SearchTerm      = query,
                Attendances     = attendances
            };

            return View("Paddle", viewModel);
        }        

        #endregion

        #region Helper methods

        /// <summary>
        /// A small method to allow upcoming paddles to be filtered
        /// </summary>
        /// <param name="query"></param>
        /// <param name="upcomingPaddles"></param>
        /// <returns></returns>
        private IQueryable<Paddle> FilterUpcomingPaddles(string query, IQueryable<Paddle> upcomingPaddles)
        {
            if (!string.IsNullOrWhiteSpace(query))
            {
                upcomingPaddles = upcomingPaddles
                    .Where(p =>
                        p.Paddler.UserDetails.FirstName.Contains(query) ||
                        p.Location.Contains(query) ||
                        p.PaddleType.Name.Contains(query));
            }

            return upcomingPaddles;
        }

        #endregion

    }
}