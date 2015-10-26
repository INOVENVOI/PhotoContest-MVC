using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoContest.Web.Helpers
{
    using System.Web.Mvc;

    public class HtmlExtensions
    {
        public static MvcHtmlString Image(HtmlHelper helper, string imageUrl, string altText = "")
        {
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", imageUrl);
            imgBuilder.MergeAttribute("alt", altText);

            return new MvcHtmlString(imgBuilder.ToString());
        }
    }
}