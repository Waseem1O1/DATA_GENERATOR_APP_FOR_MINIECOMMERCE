using System.ComponentModel.DataAnnotations;

namespace DATA_GENERATOR_APP_FOR_MINIECOMMERCE.Models
{
    public class MultipleImagesModel
    {
        [Key]
        public int? ProductId { get; set; }
        public byte[] Image { get; set; }
    }
}
