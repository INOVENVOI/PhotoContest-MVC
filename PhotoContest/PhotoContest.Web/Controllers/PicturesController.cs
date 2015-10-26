using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhotoContest.Data;
using PhotoContext.Models;

namespace PhotoContest.Web.Controllers
{
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
       
    }
}
