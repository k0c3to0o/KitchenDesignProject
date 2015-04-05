namespace KitchenDesignProject.Areas.Administration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using KitchenDesignProject.Infrastructure.Mapping;
    using KitchenDesignProject.Models;
    using KitchenDesignProject.Common;

    public class ProductModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Lang Code")]
        public string LangCode { get; set; }

        [Display(Name = "Title BG")]
        public string TitleBg { get; set; }

        [Display(Name = "Description BG")]
        public string DescriptionBg { get; set; }

        [Display(Name = "Title EN")]
        public string TitleEn { get; set; }

        [Display(Name = "Description EN")]
        public string DescriptionEn { get; set; }

        [Display(Name = "Title RU")]
        public string TitleRu { get; set; }

        [Display(Name = "Description RU")]
        public string DescriptionRu { get; set; }

        [Display(Name = "Author")]
        public string AuthorName { get; set; }

        [Display(Name = "Date Created")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Images")]
        public List<ImageModel> Images { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            //string langCodeParam = null;

            string bg = GlobalConstants.Langues[0].ToString();
            string en = GlobalConstants.Langues[1].ToString();
            string ru = GlobalConstants.Langues[2].ToString();

            configuration.CreateMap<Product, ProductModel>()
                 .ForMember(m => m.CategoryId, opt => opt.MapFrom(u => u.Category.Id))
                 .ForMember(m => m.AuthorName, opt => opt.MapFrom(u => u.Author.UserName))
                 .ForMember(m => m.LangCode, opt => opt.MapFrom(u => u.ProductLangs.FirstOrDefault(x => x.LangCode == bg).LangCode))
                 .ForMember(m => m.TitleBg, opt => opt.MapFrom(u => u.ProductLangs.FirstOrDefault(x => x.LangCode == bg).Title))
                 .ForMember(m => m.DescriptionBg, opt => opt.MapFrom(u => u.ProductLangs.FirstOrDefault(x => x.LangCode == bg).Description))
                 .ForMember(m => m.TitleEn, opt => opt.MapFrom(u => u.ProductLangs.FirstOrDefault(x => x.LangCode == en).Title))
                 .ForMember(m => m.DescriptionEn, opt => opt.MapFrom(u => u.ProductLangs.FirstOrDefault(x => x.LangCode == en).Description))
                 .ForMember(m => m.TitleRu, opt => opt.MapFrom(u => u.ProductLangs.FirstOrDefault(x => x.LangCode == ru).Title))
                 .ForMember(m => m.DescriptionRu, opt => opt.MapFrom(u => u.ProductLangs.FirstOrDefault(x => x.LangCode == ru).Description));
        }
    }
}