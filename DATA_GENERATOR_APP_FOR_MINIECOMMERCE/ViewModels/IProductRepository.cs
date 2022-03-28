using DATA_GENERATOR_APP_FOR_MINIECOMMERCE.Models;

namespace DATA_GENERATOR_APP_FOR_MINIECOMMERCE.ViewModels
{
    public interface IProductRepository
    {
        Task<int> GenerateProducts(List<ProductModel> pm, byte[] img);
    }
}
