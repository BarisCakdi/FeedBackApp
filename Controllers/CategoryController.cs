using FeedBackApp.Data;
using FeedBackApp.Helpers;
using FeedBackApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using FeedBackApp.DTOs;
using FeedBackApp.Model;
using Microsoft.AspNetCore.Authorization;

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
        [HttpGet("/Category")]
        public IActionResult Category()
        {
            var feedBack = _context.Categories
                .Select(x => new
                {
                    x.Id,
                    x.Name
                })
                .ToArray();

            if (!feedBack.Any())
            {
                return NotFound("Henüz herhangi bir kategori bildirim bulunmamaktadır.");
            }

            return Ok(feedBack);
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> GetCategoryBySlug(string slug)
        {
            var category = await _context.Categories
                .Include(c => c.FeedBacks)
                .FirstOrDefaultAsync(c => c.Slug == slug);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        [Authorize]
        [HttpPost("/Category")]
        public async Task<IActionResult> AddCategory([FromBody] dtoCategory model)
        {
            if (_context.Categories.Any(c => c.Name == model.Name))
            {
                return BadRequest("Bu isimde bir kategori zaten var.");
            }

            var category = new Category
            {
                Name = model.Name,
                Slug = await GenerateUniqueSlug(model.Name) // Benzersiz slug oluşturma
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(category);
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

        private async Task<string> GenerateUniqueSlug(string name)
        {
            var slug = SlugHelper.GenerateSlug(name);
            var slugExists = await _context.Categories.AnyAsync(c => c.Slug == slug);

            var suffix = 1;
            while (slugExists)
            {
                slug = $"{SlugHelper.GenerateSlug(name)}-{suffix++}";
                slugExists = await _context.Categories.AnyAsync(c => c.Slug == slug);
            }

            return slug;
        }
    }
}
