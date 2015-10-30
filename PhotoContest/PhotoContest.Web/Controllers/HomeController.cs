namespace PhotoContest.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Models.ViewModels;
    using PagedList;

    public class HomeController : BaseController
    {
        public HomeController(IPhotoContestData data)
            : base(data)
        {
        }

        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var pictures = this.Data.Pictures.All()
                .OrderByDescending(p => p.Votes.Count)
                .ThenBy(p => p.Id)
                .Select(PictureDetailsViewModel.Create);

            var pagedPictures = new PagedList<PictureDetailsViewModel>(pictures, page, pageSize);

            return View(pagedPictures);
        }
    }
}