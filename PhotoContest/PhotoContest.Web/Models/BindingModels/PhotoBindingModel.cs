using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoContest.Web.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class PhotoBindingModel
    {
        [Required]
        public string AuthorId { get; set; }
       
        public HttpPostedFileBase Upload { get; set; } 
    }
}