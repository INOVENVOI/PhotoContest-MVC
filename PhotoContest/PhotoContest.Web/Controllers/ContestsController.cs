using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoContest.Web.Controllers
{
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
                .OrderByDescending(c => c.StartDate)
                .ThenBy(c => c.EndDate)
                .Select(ContestDetailsViewModel.Create);

            var pagedContests = new PagedList<ContestDetailsViewModel>(contests, page, pageSize);

            return View(pagedContests);
        }
    }
}