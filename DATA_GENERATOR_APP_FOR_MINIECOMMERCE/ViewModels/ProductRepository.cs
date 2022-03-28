using DATA_GENERATOR_APP_FOR_MINIECOMMERCE.Models;

namespace DATA_GENERATOR_APP_FOR_MINIECOMMERCE.ViewModels
{
    public class ProductRepository : IProductRepository
    {
        DataBaseContext _context;
        static Random rnd = new Random();
        string[] NAMES = { "LEXUS", "CIVI X", "TOYOTA", "GARANDE", "TESLA", "FERRARII", "KIA", "MG","MG SC", "KIA ","PASSO", "BALENO","LIANA" ,"TOYOTA GARANDE","TESLA X","FORD RAPTOR","FERRARI TESTOROSSA","JEEP GLADIATOR","ROLLS ROYCE","AUDI","MERCEDES","HONDA","V8 PRADO","FORD","MEHRAN",
               "FX MINI","CARRY PICKER","VITZ","PREMIO","MARK X","MARK Z","FX PRO","Volvo", "BMW", "Mazda" ,"Volkswagen Beetle","Dodge Vipe","Ford Cortina","Chevrolet Tornado","Ford Lobo","Seat Tarraco","Suzuki Samurai","Lamborghini Diablo","Knockout","GLI","COROLLA","Roadrunner","Swoosh","Black Jack","High Roller","MPG","Zeus","Everest","Nessie","Liz Lemon","Elle Woods"};
        public static string RandomString(int length)
        {
            const string chars = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before the final copy is";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
        public ProductRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<int> GenerateProducts(List<ProductModel> pm, byte[] img)
        {
            foreach (var items in pm)
            {
                items.Image = img;
                items.ProductName = NAMES[rnd.Next(NAMES.Length)];
                items.ProductDescription = RandomString(150);
                items.ProductID = 0;
                await _context.Products.AddAsync(items);
                await _context.SaveChangesAsync();
                int lastProductID = _context.Products.Max(item => item.ProductID);
                var multipleimages = new MultipleImagesModel()
                {
                    ProductId = lastProductID,
                    Image = img

                };
                _context.multipleImages.Add(multipleimages);
            }
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
