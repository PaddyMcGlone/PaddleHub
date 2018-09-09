using Microsoft.AspNet.Identity;
using PaddleHub.Models;
using PaddleHub.Repositories;
using PaddleHub.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace PaddleHub.Controllers
{
    public class PaddleController : Controller
    {
        #region Fields
        private readonly ApplicationDbContext context;
        private readonly PaddleRepository paddleRepository;
        private readonly AttendanceRepository attendanceRepository;
        private readonly FollowingRepository followingRepository;
        #endregion

        #region Constructor
        public PaddleController()
        {
            context              = new ApplicationDbContext();
            paddleRepository     = new PaddleRepository(context);
            attendanceRepository = new AttendanceRepository(context);            
            followingRepository  = new FollowingRepository(context);            
        }
        #endregion

        #region Methods
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
            var paddle = paddleRepository.Retrieve(id);

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

            var paddle = paddleRepository.GetPaddleWithAttendees(viewModel.Id);

            if (paddle == null) return HttpNotFound();

            if(paddle.PaddlerId != User.Identity.GetUserId()) 
                return new HttpUnauthorizedResult();

            paddle.UpdateEvent(paddle.DateTime, paddle.Location);

            paddle.Location = viewModel.Location;
            paddle.DateTime = viewModel.PaddleDateTime();
            paddle.PaddleTypeId = viewModel.PaddleType;                           

            context.SaveChanges();

            return RedirectToAction("Mine");
        }

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var paddles = paddleRepository.RetrieveAllFuturePaddles(userId);

            return View(paddles);
        }

        public ActionResult Details(int id)
        {
            var paddle = paddleRepository.Retrieve(id);
            if (paddle == null) return HttpNotFound();

            var viewModel = new PaddleDetailsViewModel
            {
                Paddle = paddle,
                isAuthenticated = User.Identity.IsAuthenticated
            };

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();                
                viewModel.isAttending = attendanceRepository.Retrieve(id, userId) != null;
                viewModel.isFollowing = followingRepository.Retrieve(paddle.PaddlerId, userId) != null;                    
            }            

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();

            var viewModel = new PaddleViewModel
            {
                UpcomingPaddles = paddleRepository.GetPaddlesUserIsAttending(userId),
                UserAuthorised  = User.Identity.IsAuthenticated,
                Heading         = "Paddles Im Attending",
                Attendances     = attendanceRepository.GetFutureAttendances(userId).ToLookup(a => a.PaddleID)
            };

            return View("Paddle", viewModel);
        }
        #endregion

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