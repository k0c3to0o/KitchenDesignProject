using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using KitchenDesignProject.Areas.Administration.Models;
using KitchenDesignProject.Models;

namespace KitchenDesignProject.Helpers
{
    public class DatabaseFileHelper
    {
        public static List<ImageModel> GetImages(List<HttpPostedFileBase> files, string fileName)
        {
            List<ImageModel> images = new List<ImageModel>();
            foreach (HttpPostedFileBase file in files)
            {
                if (file != null)
                {
                    var extention = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                    ImageModel image = CreateDbFile(file, fileName, extention);
                    images.Add(image);
                }

            }

            return images;
        }
        private static ImageModel CreateDbFile(HttpPostedFileBase file, string fileName, string extention)
        {
            var images = new ImageModel()
            {
                FileExtension = extention
            };

            using (var memoryStream = new MemoryStream())
            {
                file.InputStream.CopyTo(memoryStream);
                images.Content = memoryStream.ToArray();
            }

            return images;
        }
    }
}