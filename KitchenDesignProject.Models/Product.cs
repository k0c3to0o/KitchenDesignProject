namespace KitchenDesignProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Product
    {
        private ICollection<ProductLangs> productLangs;
        private ICollection<Image> images;
        public Product()
        {
            this.productLangs = new HashSet<ProductLangs>();
            this.images = new HashSet<Image>();
        }

        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string AuthorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual User Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductLangs> ProductLangs
        {
            get { return this.productLangs; }
            set { this.productLangs = value; }
        }
        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
    }
}
