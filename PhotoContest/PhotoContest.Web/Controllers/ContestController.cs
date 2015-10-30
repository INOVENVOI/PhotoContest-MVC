namespace PhotoContest.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Models.ViewModels;
    using PagedList;

    public class ContestController : BaseController
    {
        public ContestController(IPhotoContestData data)
           : base(data)
        {
        }

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var contests = this.Data.Contests.All()
                .OrderByDescending(c => c.Id)
                .Select(ContestDetailsViewModel.Create);

            var pagedContests = new PagedList<ContestDetailsViewModel>(contests, page, pageSize);

            return View(pagedContests);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}