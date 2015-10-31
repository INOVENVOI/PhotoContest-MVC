using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoContest.Web.Helpers
{
    using System.IO;
    using DropNet;

    public static class DropBox
    {
        private static DropNetClient client;

        static DropBox()
        {
            client = new DropNetClient(AppKeys.DropboxApiKey, AppKeys.DropboxApiSecret, AppKeys.DropboxAccessTDropboxAccessToken);
        }

        internal static string Upload(string fileName, Stream fileStream)
        {
            string fullFileName = "" + fileName + "-"  + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            client.UploadFile("/" + AppKeys.DropboxFolder + "/", fullFileName, fileStream);
            return fullFileName;
        }

        internal static string Upload(string fileName, Stream fileStream, string subFolder)
        {
            string fullFileName = "" + fileName + "-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            client.UploadFile("/" + AppKeys.DropboxFolder + "/" + subFolder + "/", fullFileName, fileStream);
            return fullFileName;
        }

        internal static string Download(string path)
        {
            return client.GetMedia("/" + AppKeys.DropboxFolder + "/" + path).Url;
        }

        internal static string Download(string path, string subFolder)
        {
            string fullPath = "/" + AppKeys.DropboxFolder;

            if (subFolder != null)
            {
                fullPath += "/" + subFolder;
            }

            fullPath += "/" + path;

            return client.GetMedia(fullPath).Url;
        }

        internal static void Delete(string path)
        {
            client.Delete("/" + AppKeys.DropboxFolder + "/" + path);
        }



    }
}