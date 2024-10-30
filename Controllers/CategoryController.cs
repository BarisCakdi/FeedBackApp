using FeedBackApp.Data;
using FeedBackApp.Helpers;
using FeedBackApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using FeedBackApp.DTOs;
using FeedBackApp.Model;

namespace FeedBackApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> GetCategoryBySlug(string slug)
        {

            var category = _context.Categories
                .FirstOrDefaultAsync(c => c.Slug == slug);
                

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] dtoCategory model)
        {
            if (_context.Categories.Any(c => c.Name == model.Name))
            {
                return BadRequest("Bu isimde bir kategori zaten var.");
            }

            model.Slug = await GenerateUniqueSlugAsync(model.Name, _context);
            _context.Categories.Add(model);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);

                if (category == null)
                {
                    return NotFound();
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return Ok("Silindi");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Silinemedi: " + e.Message);
            }
        }

        private async Task<string> GenerateUniqueSlugAsync(string name, AppDbContext context)
        {
            var slug = SlugHelper.GenerateSlug(name);
            var slugExists = await context.Categories.AnyAsync(c => c.Slug == slug);

            var suffix = 1;
            while (slugExists)
            {
                slug = $"{SlugHelper.GenerateSlug(name)}-{suffix++}";
                slugExists = await context.Categories.AnyAsync(c => c.Slug == slug);
            }

            return slug;
        }
    }
}