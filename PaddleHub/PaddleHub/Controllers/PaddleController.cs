using Microsoft.AspNet.Identity;
using PaddleHub.Models;
using PaddleHub.ViewModels;
using System;
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
                Heading = "Create a paddle",
                PaddleTypes = context.PaddleTypes.ToList()
            };

            return View("PaddleForm", viewModel);
        }

        [HttpPost, Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaddleFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {             
                viewModel.PaddleTypes = context.PaddleTypes.ToList();
                return View("PaddleForm", viewModel);
            }
            
            var paddle = MapPaddle(viewModel);

            context.Paddles.Add(paddle);
            context.SaveChanges();

            return RedirectToAction("Mine");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var paddle = context.Paddles.SingleOrDefault(p => p.Id == id && p.PaddlerId == userId);

            var viewModel = new PaddleFormViewModel
            {
                Id          = paddle.Id,
                Heading     = "Edit a paddle",
                PaddleTypes = context.PaddleTypes.ToList(),
                Date        = paddle.DateTime.ToString("d"),
                Time        = paddle.DateTime.ToString("HH:mm"),
                Location    = paddle.Location,
                PaddleType  = paddle.PaddleTypeId
            };

            return View("PaddleForm", viewModel);
        }

        [HttpPost, Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PaddleFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.PaddleTypes = context.PaddleTypes.ToList();
                return View("PaddleForm", viewModel);
            }

            var userId = User.Identity.GetUserId();
            var paddle = context.Paddles.SingleOrDefault(p => p.Id == viewModel.Id && p.PaddlerId == userId);

            if (paddle != null)
            {
                paddle.Location = viewModel.Location;
                paddle.DateTime = viewModel.PaddleDateTime();
                paddle.PaddleTypeId = viewModel.PaddleType;
            }

            context.SaveChanges();

            return RedirectToAction("Mine");
        }

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var paddles = context.Paddles
                .Where(p => p.PaddlerId == userId 
                            && p.DateTime >= DateTime.Now)
                .Include(p => p.PaddleType)
                .ToList();

            return View(paddles);
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