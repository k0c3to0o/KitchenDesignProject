namespace KitchenDesignProject.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using KitchenDesignProject.Models;
    public class KitchenDesignData : IKitchenDesignData
    {
        private readonly DbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        public KitchenDesignData(DbContext context)
        {
            this.context = context;
        }
        public IRepository<Image> Images
        {
            get { return this.GetRepository<Image>(); }
        }
        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }
        public IRepository<Product> Products
        {
            get
            {
                return this.GetRepository<Product>();
            }
        }
        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }
        public IRepository<ProductLangs> ProductLangs
        {
            get
            {
                return this.GetRepository<ProductLangs>();
            }
        }
        public IRepository<Testimonial> Testimonials
        {
            get
            {
                return this.GetRepository<Testimonial>();
            }
        }
        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }
        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
