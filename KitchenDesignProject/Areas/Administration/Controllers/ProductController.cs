namespace KitchenDesignProject.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using KitchenDesignProject.Models;
    using KitchenDesignProject.Data;
    using KitchenDesignProject.Areas.Administration.Models;
    using AutoMapper.QueryableExtensions;
    using KitchenDesignProject.Common;
    using KitchenDesignProject.Helpers;
    using AutoMapper;

    public class ProductController : AdminController
    {
        public ProductController(IKitchenDesignData data)
            : base(data)
        {
        }

        //GET: /Administration/Product/
        public ActionResult Index()
        {
            var products = this.Data.Products.All()
                 .Where(p => p.ProductLangs.FirstOrDefault(l => l.LangCode == GlobalConstants.Lang) != null)
                .Include(p => p.Author)
                .Include(p => p.Category)
                .Include(p => p.ProductLangs)
                .Project().To<ProductModel>();

            return View(products.ToList());
        }


        // GET: /Administration/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = this.Data.Products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: /Administration/Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(this.Data.Categories.All(), "Id", "Title");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel newProduct, List<HttpPostedFileBase> uploadedImages)
        {
            if (ModelState.IsValid)
            {
                List<ImageModel> images = DatabaseFileHelper.GetImages(uploadedImages, "Images");

                string bg = GlobalConstants.Langues[0].ToString();
                string en = GlobalConstants.Langues[1].ToString();
                string ru = GlobalConstants.Langues[2].ToString();

                Product productModel = new Product();
                productModel.CreatedDate = DateTime.Now.Date;
                productModel.CategoryId = newProduct.CategoryId;
                productModel.CreatedDate = newProduct.CreatedDate;
                productModel.Author = this.UserProfile;

                List<Image> dbImages = Mapper.Map<List<Image>>(images);
                productModel.Images = dbImages;

                ProductLangs productBg = new ProductLangs() { Title = newProduct.TitleBg, Description = newProduct.DescriptionBg, LangCode = bg };
                ProductLangs productEn = new ProductLangs() { Title = newProduct.TitleEn, Description = newProduct.DescriptionEn, LangCode = en };
                ProductLangs productRu = new ProductLangs() { Title = newProduct.TitleRu, Description = newProduct.DescriptionRu, LangCode = ru };
                productModel.ProductLangs.Add(productBg);
                productModel.ProductLangs.Add(productEn);
                productModel.ProductLangs.Add(productRu);

                this.Data.Products.Add(productModel);
                this.Data.SaveChanges();

                return RedirectToAction("Index");
            }


            ViewBag.CategoryId = new SelectList(this.Data.Categories.All(), "Id", "Title", newProduct.CategoryId);
            return View();
        }

        // GET: /Administration/Product/Edit/5
        public ActionResult Edit(int? id, string langCode)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductModel product = this.Data.Products.All().Where(x => x.Id == id).Project().To<ProductModel>().FirstOrDefault();

            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(this.Data.Categories.All(), "Id", "Title", product.CategoryId);

            return View(product);
        }

        // POST: /Administration/Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductModel updatedProduct, List<HttpPostedFileBase> uploadedImages)
        {
            var product = this.Data.Products.GetById(updatedProduct.Id);
            if (product != null)
            {
                List<ImageModel> images = DatabaseFileHelper.GetImages(uploadedImages, "Images");
                List<Image> dbImages = Mapper.Map<List<Image>>(images);
                product.Images = dbImages;

                product.CategoryId = updatedProduct.CategoryId;
                product.CreatedDate = updatedProduct.CreatedDate;

                string bg = GlobalConstants.Langues[0].ToString();
                string en = GlobalConstants.Langues[1].ToString();
                string ru = GlobalConstants.Langues[2].ToString();

                foreach (ProductLangs productLang in product.ProductLangs)
                {
                    if (productLang.LangCode == bg)
                    {
                        productLang.Title = updatedProduct.TitleBg;
                        productLang.Description = updatedProduct.TitleBg;
                    }
                    if (productLang.LangCode == en)
                    {
                        productLang.Title = updatedProduct.TitleEn;
                        productLang.Description = updatedProduct.TitleEn;
                    }
                    if (productLang.LangCode == ru)
                    {
                        productLang.Title = updatedProduct.TitleRu;
                        productLang.Description = updatedProduct.TitleRu;
                    }
                }

                this.Data.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(this.Data.Categories.All(), "Id", "Title", product.CategoryId);
            return View(product);
        }

        // GET: /Administration/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = this.Data.Products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Administration/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = this.Data.Products.GetById(id);
            this.Data.Products.Delete(product);
            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Data.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
