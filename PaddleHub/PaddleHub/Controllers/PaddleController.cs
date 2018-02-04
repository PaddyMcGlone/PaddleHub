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

        [Authorize]
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
            return new Paddle
            {
                Paddler = new ApplicationUser { Id = User.Identity.GetUserId() },
                DateTime = viewModel.PaddleDateTime(),
                Location = viewModel.Location,
                PaddleType = new PaddleType { Id = viewModel.PaddleType }
            };
        }

        #endregion
    }
}