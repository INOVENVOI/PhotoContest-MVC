using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoContest.Web.Helpers
{
    using System.IO;
    using System.Web.Hosting;

    public static class UploadFiles
    {
        internal static List<string> UploadImage(HttpPostedFileBase upload, bool isProfile)
        {
            var basePath = HostingEnvironment.ApplicationPhysicalPath;
            var path = new List<string>();

            using (FileStream file = new FileStream(basePath + "\\images\\temp.jpg", FileMode.Open))
            {
                path.Add(DropBox.Upload(upload.FileName, file));
            }

            return path;
        }
    }
}