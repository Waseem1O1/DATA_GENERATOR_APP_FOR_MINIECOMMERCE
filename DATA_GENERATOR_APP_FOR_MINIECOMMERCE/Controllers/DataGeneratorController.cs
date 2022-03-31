using DATA_GENERATOR_APP_FOR_MINIECOMMERCE.Models;
using DATA_GENERATOR_APP_FOR_MINIECOMMERCE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DATA_GENERATOR_APP_FOR_MINIECOMMERCE.Controllers
{
    public class DataGeneratorController : Controller
    {
        private readonly IDataGenerator<ProductModel> _contactsGeneratorService;
        public IProductRepository _ProductRepository { get; }

        public DataGeneratorController(IDataGenerator<ProductModel> dataGeneratorService, IProductRepository ProductRepository)
        {
            _contactsGeneratorService = dataGeneratorService;
            _ProductRepository = ProductRepository;
        }
        [HttpGet]
        public ActionResult GenerateData()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GenerateData(IFormFile image, int noOfRecords)
        {
            //Type type = Type.GetType(Modelname);
            //object instance = Activator.CreateInstance(type);
            byte[] img = null;
            if (image != null)
            {
                if (image.Length > 0)
                {
                    if (noOfRecords > 0)
                    {
                        var fileName = Path.GetFileName(image.FileName);
                        var fileExtension = Path.GetExtension(fileName);
                        var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
                        using (var target = new MemoryStream())
                        {
                            image.CopyTo(target);
                            img = target.ToArray();
                        }
                        var data = _contactsGeneratorService.Collection(noOfRecords);

                        var product = await _ProductRepository.GenerateProducts(data, img);
                        ViewBag.success = data.Count + "Product(s) Generated Successfully";
                    }
                    else
                    {
                        ViewBag.danger1 = " Please Enter Positive Number";
                    }
                }
            }
            else
            {
                ViewBag.danger = " Please Choose a file";

            }

            return View();
        }
    }
}
