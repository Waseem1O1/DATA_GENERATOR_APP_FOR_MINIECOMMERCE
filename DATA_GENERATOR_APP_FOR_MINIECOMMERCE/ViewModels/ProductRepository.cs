using DATA_GENERATOR_APP_FOR_MINIECOMMERCE.Models;

namespace DATA_GENERATOR_APP_FOR_MINIECOMMERCE.ViewModels
{
    public class ProductRepository : IProductRepository
    {
        DataBaseContext _context;
        static Random rnd = new Random();
        string[] NAMES = { "LEXUS", "CIVI X", "TOYOTA", "GRANDE", "TESLA", "FERRARI", "KIA", "MG","MG SC", "KIA ","PASSO", "BALENO","LIANA" ,"TOYOTA GARANDE","TESLA X","FORD RAPTOR","FERRARI TESTOROSSA","JEEP GLADIATOR","ROLLS ROYCE","AUDI","MERCEDES","HONDA","V8 PRADO","FORD","MEHRAN",
               "FX MINI","CARRY PICKER","VITZ","PREMIO","MARK X","MARK Z","FX PRO","Volvo", "BMW", "Mazda" ,"Volkswagen Beetle","Dodge Vipe","Ford Cortina","Chevrolet Tornado","Ford Lobo","Seat Tarraco","Suzuki Samurai","Lamborghini Diablo","Knockout","GLI","COROLLA","Roadrunner","Swoosh","Black Jack","High Roller","MPG","Zeus","Everest","Nessie","Liz Lemon","Elle Woods"};
        decimal[] Prices = {12000000, 13000000, 65888888, 100000, 6000000, 300000000, 800000, 1000000,6000000, 7000000,3000000000, 91000000,12000000 ,13000000000,67000000,3000000,500700000,30060000,66363636,54545555,7788778,5454464646,99889999,0988888888,
               12000000000,874000000,765000000,3100000000,7699999,87000000,12000000,5000000, 12000000, 500000000,10000000,198000000,30000000000,50000000000,12000000000,100000000000,2000000000,400000000000,6000000000,700000000000,800000000,900000000,1000000000000,11000000000000,1200000000,13000000000,14000000000,1500000000000,1600000000,1700000000000};
        public static string RandomString(int length)
        {
            const string chars = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before the final copy is being private used.";
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
                items.Price = Prices[rnd.Next(Prices.Length)];
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
