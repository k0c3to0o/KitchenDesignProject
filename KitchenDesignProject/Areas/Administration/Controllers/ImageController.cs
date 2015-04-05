namespace KitchenDesignProject.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using KitchenDesignProject.Areas.Administration.Models;
    using KitchenDesignProject.Data;
    public class ImageController : AdminController
    {
        public ImageController(IKitchenDesignData data)
            : base(data)
        {
        }
        public ActionResult GetImage(int id)
        {
            var image = this.Data.Images.GetById(id);

            if (image == null && image.FileExtension == null)
            {
                throw new HttpException(404, "Image not Found");
            }

            return File(image.Content, "image/" + image.FileExtension);
        }

        [HttpGet]
        public ActionResult DeleteImage(int id)
        {
            if (ModelState.IsValid)
            {
                var image = this.Data.Images.All().Where(i => i.Id == id).FirstOrDefault();
                if (image != null)
                {
                    var prod = image.Product;
                    this.Data.Images.Delete(image);
                    this.Data.SaveChanges();

                    List<ImageModel> mImages = Mapper.Map<List<ImageModel>>(prod.Images);
                    ProductModel mProduct = Mapper.Map<ProductModel>(prod);
                    mProduct.Images = mImages;

                    return PartialView("_ImagesPartial", mProduct);
                }
            }

            return PartialView("_CommentPartial");
        }
    }
}