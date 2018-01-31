using PaddleHub.Models;
using PaddleHub.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace PaddleHub.Controllers
{
    public class PaddleController : Controller
    {
        private ApplicationDbContext context;

        public PaddleController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Gigs
        public ActionResult Create()
        {
            var viewModel = new PaddleFormViewModel
            {
                PaddleTypes = context.PaddleTypes.ToList()
            };

            return View(viewModel);
        }
    }
}