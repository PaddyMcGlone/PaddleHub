using Microsoft.AspNet.Identity;
using PaddleHub.Models;
using PaddleHub.ViewModels;
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
            if (!ModelState.IsValid) return View("Create", viewModel);
            
            var paddle = MapPaddle(viewModel);

            context.Paddles.Add(paddle);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        #region Helper methods

        /// <summary>
        /// Mapping helper method - will be moved out in future work.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        private Paddle MapPaddle(PaddleFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var user = context.Users.Single(u => u.Id == userId);
            var type = context.PaddleTypes.Single(t => t.Id == viewModel.PaddleType);

            return new Paddle
            {
                Paddler    = user,
                DateTime   = viewModel.PaddleDateTime(),
                Location   = viewModel.Location,
                PaddleType = type
            };
        }

        #endregion
    }
}