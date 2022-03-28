using Microsoft.EntityFrameworkCore;

namespace DATA_GENERATOR_APP_FOR_MINIECOMMERCE.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<MultipleImagesModel> multipleImages { get; set; }
    }
}
