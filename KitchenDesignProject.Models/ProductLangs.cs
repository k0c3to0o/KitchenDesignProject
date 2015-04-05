namespace KitchenDesignProject.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductLangs
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string LangCode { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
