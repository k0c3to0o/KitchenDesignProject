using System;
namespace KitchenDesignProject.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Testimonial
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string ClientName { get; set; }

        [StringLength(50)]
        public string Position { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
    }
}
