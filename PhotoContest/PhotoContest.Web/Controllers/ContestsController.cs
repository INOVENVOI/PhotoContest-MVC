using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoContest.Web.Controllers
{
    using System.Net;
    using Data.UnitOfWork;
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
    }
}