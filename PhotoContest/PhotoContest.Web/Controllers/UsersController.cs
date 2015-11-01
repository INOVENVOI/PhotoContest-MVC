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

    public class UsersController : BaseController
    {
        // GET: Users
        public UsersController(IPhotoContestData data)
            : base(data)
        {
        }

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var users = this.Data.Users.All()
                .OrderByDescending(u => u.UserName)
                .ThenBy(u => u.FullName)
                .Select(UserDetailsViewModel.Create);

            var pagedPictures = new PagedList<UserDetailsViewModel>(users, page, pageSize);

            return View(pagedPictures);
        }


        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = this.Data.Users.All()
                .Where(u => u.Id == id)
                .Select(UserDetailsViewModel.Create);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
    }
}