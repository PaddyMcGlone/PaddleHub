using PaddleHub.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using PaddleHub.ViewModels;

namespace PaddleHub.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}