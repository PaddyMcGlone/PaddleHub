using Microsoft.AspNet.Identity;
using PaddleHub.Models;
using PaddleHub.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace PaddleHub.Controllers
{
    public class PaddleController : Controller
    {
        private readonly ApplicationDbContext context;

        public PaddleController()
        {
            context = new ApplicationDbContext();
        }
        
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new PaddleFormViewModel
            {
                PaddleTypes = context.PaddleTypes.ToList()
            };

            return View(viewModel);
        }

        [HttpPost, Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaddleFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {             
                viewModel.PaddleTypes = context.PaddleTypes.ToList();
                return View("Create", viewModel);
            }
            
            var paddle = MapPaddle(viewModel);

            context.Paddles.Add(paddle);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();

            // command selects a list of paddles from the attendance object
            var paddles = context.Attendances              
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Paddle)       
                .Include(g => g.Paddler.UserDetails)
                .Include(g => g.PaddleType)
                .ToList();

            var viewModel = new PaddleViewModel
            {
                UpcomingPaddles = paddles,
                UserAuthorised  = User.Identity.IsAuthenticated,
                Heading         = "Paddles Im Attending" 
            };

            return View("Paddle", viewModel);
        }
        #region Helper methods

        /// <summary>
        /// Mapping helper method - will be moved out in future work.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        private Paddle MapPaddle(PaddleFormViewModel viewModel)
        {
            return new Paddle
            {
                PaddlerId    = User.Identity.GetUserId(),
                PaddleTypeId = viewModel.PaddleType,
                DateTime     = viewModel.PaddleDateTime(),
                Location     = viewModel.Location,
            };
        }

        #endregion
    }
}