namespace PhotoContest.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Models.ViewModels;
    using PagedList;
    using PhotoContext.Models;

    public class HomeController : BaseController
    {
        public HomeController(IPhotoContestData data)
            : base(data)
        {
        }


        [HttpGet]
        public ActionResult Index(int page = 1, int pageSize = 5)
        {

            var contests = this.Data.Contests.All()
                .Where(c => c.ContestStatus == ContestStatus.Active)
                .OrderByDescending(c => c.StartDate)
                .ThenBy(c => c.EndDate)
                .Select(ContestSummaryViewModel.Create);

            var pagedContests = new PagedList<ContestSummaryViewModel>(contests, page, pageSize);

            return View(pagedContests);
        }


        [HttpGet]
        public ActionResult Archive(int page = 1, int pageSize = 5)
        {

            var contests = this.Data.Contests.All()
                .Where(c => c.ContestStatus == ContestStatus.Finished)
                .OrderByDescending(c => c.StartDate)
                .ThenBy(c => c.EndDate)
                .Select(ContestSummaryViewModel.Create);

            var pagedContests = new PagedList<ContestSummaryViewModel>(contests, page, pageSize);

            return View(pagedContests);
        }
    }
}