using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using KitchenDesignProject.Areas.Administration.Models;
using KitchenDesignProject.Common;

namespace KitchenDesignProject.Helpers
{
    public class UploadHelper
    {
        //public static string UploadPictureToServer(HttpPostedFileBase file, string fileName, ProductModel product)
        //{
        //    var extention = file.FileName.Substring(file.FileName.LastIndexOf('.'));
        //    if (!GlobalConstants.AllowedPictureExtentions.Contains(extention))
        //    {
        //        throw new ArgumentException("Incorrect file extention type.");
        //    }

        //    var directoryName = "~/Files/" + product.Title;
        //    if (string.IsNullOrWhiteSpace(product.Title))
        //    {
        //        if (Directory.Exists(HttpContext.Current.Server.MapPath("~/Files/" + product.Title)))
        //        {
        //            var i = 0;
        //            while (Directory.Exists(HttpContext.Current.Server.MapPath("~/Files/" + product.Title + "." + i)))
        //            {
        //                i++;
        //            }

        //            directoryName = "~/Files/" + product.Title + "." + i;
        //        }
        //    }
        //    else
        //    {
        //        directoryName = product.Title;
        //    }

        //    product.Title = directoryName;
        //    var mappedDirectoryName = HttpContext.Current.Server.MapPath(directoryName);
        //    Directory.CreateDirectory(mappedDirectoryName);

        //    var exactFilePathAndName = mappedDirectoryName + "/" + fileName + extention;

        //    if (File.Exists(exactFilePathAndName))
        //    {
        //        File.Delete(exactFilePathAndName);
        //    }

        //    file.SaveAs(exactFilePathAndName);

        //    return directoryName.Substring(1) + "/" + fileName + extention;
        //}
    }
}