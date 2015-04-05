namespace KitchenDesignProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public byte[] Content { get; set; }

        [MaxLength(500)]
        public string PostersUrl { get; set; }

        public string FileExtension { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
