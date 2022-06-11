using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.Json;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly ECommerceDbContext _db;
        public ProductController(ECommerceDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Preset> presets = _db.Presets
                .Include(preset => preset.Preset_Attributes)
                .ThenInclude(preset => preset.Attribute)
                .ToList();

            List<Product> products = _db.Products
                .Include(product => product.Discount)
                .Include(product => product.Preset)
                .ThenInclude(preset => preset.Preset_Attributes)
                .ThenInclude(preset => preset.Attribute)
                .Include(product => product.Product_Attributes)
                .ToList();

            List<Discount> discounts = _db.Discounts.ToList();
            
            ViewBag.Products = products;
            ViewBag.Presets = presets;
            ViewBag.Discounts = discounts;

            return View();
        }

        [HttpPost]
        public IActionResult AddForm(Preset preset)
        {
            preset = _db.Presets.Find(preset.Id);

            List<Preset_Attribute> preset_Attributes =
                (from presets in _db.Preset_Attributes.Include(preset => preset.Attribute).ToList()
                where presets.Preset == preset
                select presets).ToList();
            preset.Preset_Attributes = preset_Attributes;

            List<Discount> discounts = _db.Discounts.ToList();

            ViewBag.Preset = preset;
            ViewBag.Discounts = discounts;

            return View();
        }

        [HttpPost]
        public IActionResult Add(string Attributes, string Price, Preset preset, Discount discount, Product product)
        {
            if(_db.Discounts.Any(d => d.Id == discount.Id))
            {
                discount = _db.Discounts.Find(discount.Id);
                product.Discount = discount;

                decimal price = 0;
                product.Preset = _db.Presets.Find(preset.Id);
                Decimal.TryParse(Price, NumberStyles.Any, CultureInfo.InvariantCulture, out price);
                product.Price = price;

                List<AttributeDTO> attributeDTOs = JsonSerializer.Deserialize<List<AttributeDTO>>(Attributes);

                List<Product_Attribute> product_Attributes = new List<Product_Attribute>();
                Models.Attribute attribute;
                List<Models.Attribute> attributes = new List<Models.Attribute>();
                Product_Attribute product_Attribute;

                for (int i = 0; i < attributeDTOs.Count; i++)
                {
                    attribute = (from attr in _db.Attributes
                        .Include(a => a.Product_Attributes)
                        .ToList()
                                 where attr.Id == Convert.ToInt32(attributeDTOs[i].AttributeId)
                                 select attr).ToList()[0];
                    product_Attribute = new Product_Attribute { Attribute = attribute, Value = attributeDTOs[i].Value, Product = product };
                    product_Attributes.Add(product_Attribute);
                    attribute.Product_Attributes.Add(product_Attribute);
                    attributes.Add(attribute);
                }
                product.Product_Attributes = product_Attributes;

                _db.Products.Add(product);
                _db.SaveChanges();
            }            

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(string Attributes, string Price, Product product, Discount discount)
        {
            if(_db.Products.Any(p => p.Id == product.Id) && _db.Discounts.Any(d => d.Id == discount.Id))
            {
                //product = _db.Products.Find(product.Id);                
                string name = product.Name;
                product = (from prod in _db.Products
                          .Include(prod => prod.Product_Attributes)
                          .ToList()
                           where prod.Id == product.Id
                           select prod).ToList()[0];
                product.Name = name;

                discount = _db.Discounts.Find(discount.Id);
                product.Discount = discount;

                decimal price = 0;
                Decimal.TryParse(Price, NumberStyles.Any, CultureInfo.InvariantCulture, out price);
                product.Price = price;

                List<AttributeDTO> attributeDTOs = JsonSerializer.Deserialize<List<AttributeDTO>>(Attributes);

                //List<Product_Attribute> product_Attributes = new List<Product_Attribute>();
                Models.Attribute attribute;
                for (int i = 0; i < attributeDTOs.Count; i++)
                {
                    attribute = _db.Attributes.Find(Convert.ToInt32(attributeDTOs[i].AttributeId));
                    //product_Attributes.Add(new Product_Attribute { Attribute = attribute, Product = product, Value = attributeDTOs[i].Value });
                    for (int j = 0; j < product.Product_Attributes.Count; j++)
                    {
                        if (product.Product_Attributes[j].Attribute.Id == Convert.ToInt32(attributeDTOs[i].AttributeId))
                        {
                            product.Product_Attributes[j].Value = attributeDTOs[i].Value;
                            break;
                        }
                    }
                }

                //product.Product_Attributes = product_Attributes;
                _db.Products.Update(product);
                _db.SaveChanges();
            }            

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(Product product)
        {
            if(_db.Products.Any(p => p.Id == product.Id))
            {
                product = _db.Products.Find(product.Id);
                _db.Products.Remove(product);
                _db.SaveChanges();
            }            

            return RedirectToAction("Index");
        }
    }
}
