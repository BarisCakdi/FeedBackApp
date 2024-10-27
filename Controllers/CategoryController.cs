using FeedBackApp.Data;
using FeedBackApp.DTOs;
using FeedBackApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace FeedBackApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("/GetCategories")]
        public IActionResult GetCategories()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }

        [HttpPost("/SaveCategory")]
        public IActionResult SaveCategory(dtoCategory model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Eksik veya hatalı giriş yaptınız." });
            }

            var data = new Category();

            if (model.Id is not 0)
            {
                data = _context.Categories.Find(model.Id);
                data.Name = model.Name;

                _context.Categories.Update(data);
            }
            else
            {
                data.Name = model.Name;
                _context.Categories.Add(data);
            }

            _context.SaveChanges();

            return Ok($"Kategori Başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public string DeleteClient(int id)
        {
            try
            {
                var category = _context.Categories.Find(id);
                _context.Categories.Remove(category);
                _context.SaveChanges();

                return "Silindi";
            }
            catch (Exception e)
            {
                return "Silinemedi." + e.Message;
            }
        }
    }
}
