using System.Web.Mvc;

namespace PhotoContest.Web.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using AppLimit.CloudComputing.SharpBox;
    using AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox;
    using AutoMapper;
    using Data.UnitOfWork;
    using Helpers;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;
    using PagedList;
    using PhotoContext.Models;
  

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


        // GET: Pictures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var picture = this.Data.Pictures.All()
                .Where(p => p.Id == id)
                .Select(PictureDetailsViewModel.Create);

            //var picture = this.Data.Pictures.All()
            //    .Where(p => p.Id == id);
            //var picModels = Mapper.Map<IEnumerable<Picture>, IEnumerable<PictureDetailsViewModel>>(picture);   
            //return View(picModels);

            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }


        // POST: Pictures/Vote/5
        public ActionResult Vote(int id)
        {
            var picture = this.Data.Pictures.Find(id);
            var currentUserId = this.User.Identity.GetUserId();
            var vote = new Vote
            {
                VoterId = currentUserId,
                PictureId = id,
                ContestId = 1
            };

            picture.Votes.Add(vote);
            this.Data.Votes.Add(vote);
            this.Data.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        
        // GET: Tweets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var picture = this.Data.Pictures.Remove(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var picture = this.Data.Pictures.Find(id);
            this.Data.Pictures.Remove(picture);
            this.Data.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        
        [HttpPost]
        //[Route("Pictures/Upload/{contestId}")]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            var currentUserId = this.User.Identity.GetUserId();
            //var contest = this.Data.Contests.All()
            //   .FirstOrDefault(c => c.Id == contestId);

            try
            {
                /*Geting the file name*/
                string filename = System.IO.Path.GetFileName(file.FileName);

                /*Saving the file in server folder*/
                file.SaveAs(Server.MapPath("~/Images/" + filename));

                /*Saving the fileURL in database*/
                var picture = new Picture
                {
                    ImageURL = filename,
                    OwnerId = currentUserId,
                    //Contests = new List<Contest>{contest}
                };

                this.Data.Pictures.Add(picture);
                this.Data.SaveChanges();

                ViewBag.Message = "File Uploaded successfully.";
            }
            catch
            {
                ViewBag.Message = "Error while uploading the files.";
            }
            return View();
        }
        
        

        public ActionResult GetByVote(int contestId, int page = 1, int pageSize = 10)
        {
            var contest = this.Data.Contests.All()
                .FirstOrDefault(c => c.Id == contestId);
            
            var pictures = this.Data.Pictures.All()
                .OrderByDescending(p => p.Votes.Count)
                .ThenBy(p => p.Id)
                .Where(p => p.Contests.Contains(contest))
                .Select(PictureDetailsViewModel.Create);

            var pagedPictures = new PagedList<PictureDetailsViewModel>(pictures, page, pageSize);

            return View(pagedPictures);
        }


        public ActionResult GetByUploadDate(int contestId, int page = 1, int pageSize = 10)
        {
            var contest = this.Data.Contests.All()
                .FirstOrDefault(c => c.Id == contestId);

            var pictures = this.Data.Pictures.All()
                .OrderByDescending(p => p.Id)
                .Where(p => p.Contests.Contains(contest))
                .Select(PictureDetailsViewModel.Create);

            var pagedPictures = new PagedList<PictureDetailsViewModel>(pictures, page, pageSize);

            return View(pagedPictures);
        }


        [HttpPost]
        [Authorize]
        public ActionResult UploadFile(PhotoBindingModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Upload != null)
                {
                    var paths = Helpers.UploadFiles.UploadImage(model.Upload, false);

                    var photo = new Picture
                    {
                        ImageURL = DropBox.Download(paths[0]),
                        Owner = this.UserProfile
                    };

                    this.UserProfile.Pictures.Add(photo);
                    this.Data.SaveChanges();
                    this.TempData["Success"] = new[] { "Edit successfull" };
                }

                return this.View();

            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid model");
        }
       
    }
}
