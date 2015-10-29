namespace PhotoContest.Web.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;

    public class PicturesController : BaseController
    {
        public PicturesController(IPhotoContestData data)
            : base(data)
        {
        }
        

        public ActionResult UploadImage()
        {
           return View();
        }


        public ActionResult Thumbnail()
        {
            return View();
        }
        
        public ActionResult GetAll()
        {
            var pictures = this.Data.Pictures.All()
                .OrderBy(p => p.Votes.Count);
            return View(pictures);
        }

       
    }
}
