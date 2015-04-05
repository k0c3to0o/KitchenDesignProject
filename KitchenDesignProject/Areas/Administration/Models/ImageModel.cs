namespace KitchenDesignProject.Areas.Administration.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using KitchenDesignProject.Infrastructure.Mapping;
    using KitchenDesignProject.Models;
    public class ImageModel : IMapFrom<Image>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public byte[] Content { get; set; }
        public string PostersUrl { get; set; }
        public string FileExtension { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ImageModel, Image>()
                                .ForMember(m => m.Id, opt => opt.MapFrom(vm => vm.Id))
                                .ForMember(m => m.Content, opt => opt.MapFrom(vm => vm.Content))
                                .ForMember(m => m.ProductId, opt => opt.MapFrom(vm => vm.ProductId))
                                .ForMember(m => m.FileExtension, opt => opt.MapFrom(vm => vm.FileExtension))
                                .ForMember(m => m.PostersUrl, opt => opt.MapFrom(vm => vm.PostersUrl));
        }

    }
}