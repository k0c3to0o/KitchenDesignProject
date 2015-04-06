namespace KitchenDesignProject.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity.EntityFramework;

    using KitchenDesignProject.Models;
    using System.Data.Entity;
    using KitchenDesignProject.Data.Migrations;
    public class KitchenDesignDbContext : IdentityDbContext<User>
    {
        public KitchenDesignDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Product> Products { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<ProductLangs> ProductLangs { get; set; }
        public virtual IDbSet<Image> Images { get; set; }
        public virtual IDbSet<Testimonial> Testimonials { get; set; }
        public static KitchenDesignDbContext Create()
        {
            return new KitchenDesignDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<KitchenDesignDbContext,Configuration>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
