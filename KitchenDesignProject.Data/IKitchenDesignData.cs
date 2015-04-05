using System;
namespace KitchenDesignProject.Data
{
    using System;
    using System.Data.Entity;
    using KitchenDesignProject.Models;
    public interface IKitchenDesignData
    {
        DbContext Context { get; }
        IRepository<Category> Categories { get; }
        IRepository<Product> Products { get; }
        IRepository<Image> Images { get; }
        IRepository<ProductLangs> ProductLangs { get; }
        IRepository<User> Users { get; }
        IRepository<Testimonial> Testimonials { get; }
        void Dispose();
        int SaveChanges();
    }
}
