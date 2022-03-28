using System.ComponentModel.DataAnnotations;

namespace DATA_GENERATOR_APP_FOR_MINIECOMMERCE.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
    }
}
