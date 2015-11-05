namespace PhotoContest.Web.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Microsoft.AspNet.Identity;
    using Models.ViewModels;
    using PagedList;
    using PhotoContext.Models;

    public class ContestsController : BaseController
    {
        public ContestsController(IPhotoContestData data)
            : base(data)
        {
        }

        // GET: Contests
        [HttpGet]
        public ActionResult Index(int page = 1, int pageSize = 5)
        {

            var contests = this.Data.Contests.All()
                .OrderBy(c => c.ContestStatus)
                .ThenByDescending(c => c.StartDate)
                .ThenBy(c => c.EndDate)
                .Select(ContestDetailsViewModel.Create);

            var pagedContests = new PagedList<ContestDetailsViewModel>(contests, page, pageSize);

            return View(pagedContests);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contest = this.Data.Contests.All()
                .Where(c => c.Id == id)
                .Select(ContestDetailsViewModel.Create);

            if (contest == null)
            {
                return HttpNotFound();
            }

            return View(contest);
        }

        public ActionResult Submit(Contest contest)
        {
            User user = Data.Users.Find(this.User.Identity.GetUserId());

            contest.OrganizerId = user.Id;
            contest.Organizer = user;

            user.OrganizedContests.Add(contest);
            Data.Contests.Add(contest);
            Data.SaveChanges();

            return Redirect("/Contests");
        }

        public ActionResult Create()
        {
            return PartialView("~/Views/Contests/_CreateContest.cshtml");
        }
    }
}