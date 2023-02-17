using eCommerce.ProductAPI.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.ProductAPI.Models
{

    [Table("product")]
    public class Product : BaseEntity
    {

        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column("price")]
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [Column("description")]
        [StringLength(550)]
        public string Description { get; set; }

        [Column("category_name")]
        [StringLength(70)]
        public string CategoryName { get; set; }

        [Column("image_url")]
        [StringLength(300)]
        public string ImageURL { get; set; }
    }
}