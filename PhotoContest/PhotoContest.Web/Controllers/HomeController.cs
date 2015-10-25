using System.Web.Mvc;

namespace PhotoContest.Web.Controllers
{
    using System.Linq;
    using Data.UnitOfWork;

    public class HomeController : BaseController
    {
        public HomeController(IPhotoContestData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var pictures = this.Data.Pictures.All()
                .OrderBy(p => p.Votes.Count);
            return View(pictures);
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