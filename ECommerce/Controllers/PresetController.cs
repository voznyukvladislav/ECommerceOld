using ECommerce.Models;
using ECommerce.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class PresetController : Controller
    {
        private readonly ECommerceDbContext _db;
        public PresetController(ECommerceDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            List<Models.Attribute> attributes = _db.Attributes.ToList();
            List<Preset> presets = _db.Presets.Include(attribute => attribute.Preset_Attributes).ToList();
            List<SubCategory> subCategories = _db.SubCategories.ToList();

            ViewBag.Attributes = attributes;
            ViewBag.Presets = presets;
            ViewBag.SubCategories = subCategories;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Preset preset, string CheckedListJson, SubCategory subCategory)
        {
            List<string> attributeIdListDTO = JsonSerializer.Deserialize<List<string>>(CheckedListJson);
            List<Models.Attribute> attributes = new List<Models.Attribute>();
            List<Preset_Attribute> preset_Attributes = new List<Preset_Attribute>();
            for (int i = 0; i < attributeIdListDTO.Count; i++)
            {
                attributes.Add(_db.Attributes.Find(Convert.ToInt32(attributeIdListDTO[i])));

                preset_Attributes.Add(new Preset_Attribute() { Attribute = attributes[i], Preset = preset });
            }

            preset.Preset_Attributes = preset_Attributes;

            subCategory = _db.SubCategories.Find(subCategory.Id);
            preset.SubCategory = subCategory;

            _db.Presets.Add(preset);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Preset preset, string CheckedListJson)
        {
            if(_db.Presets.Any(p => p.Id == preset.Id))
            {
                List<string> attributeIdListDTO = JsonSerializer.Deserialize<List<string>>(CheckedListJson);
                List<Models.Attribute> attributes = new List<Models.Attribute>();
                List<Preset_Attribute> preset_Attributes = new List<Preset_Attribute>();
                for (int i = 0; i < attributeIdListDTO.Count; i++)
                {
                    attributes.Add(_db.Attributes.Find(Convert.ToInt32(attributeIdListDTO[i])));

                    preset_Attributes.Add(new Preset_Attribute() { Attribute = attributes[i], Preset = preset });
                }

                preset.Preset_Attributes = preset_Attributes;

                _db.Presets.Update(preset);
                _db.SaveChanges();
            }            

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(Preset preset)
        {
            if(_db.Presets.Any(p => p.Id == preset.Id))
            {
                preset = _db.Presets.Find(preset.Id);
                _db.Presets.Remove(preset);
                _db.SaveChanges();
            }            

            return RedirectToAction("Index");
        }
    }
}
