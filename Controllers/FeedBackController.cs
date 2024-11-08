using FeedBackApp.Data;
using FeedBackApp.DTOs;
using FeedBackApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FeedBackApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FeedBackController : ControllerBase
    {
        private readonly AppDbContext _context;

        
        public FeedBackController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("/FeedBack")]
        public IActionResult FeedBack()
        {
            var feedBacks = _context.FeedBacks
                .OrderByDescending(x => x.UploadsCount)
                .Select(f => new
                {
                    Category =
                        f.CategoryId,
                    f.Category.Name,
                    f.Id,
                    f.Title,
                    f.Description,
                    f.UploadsCount,
                    f.UpdateStatus,
                    Commit =
                        f.Commits,
                })
                .ToList();

            if (!feedBacks.Any())
            {
                return NotFound("Henüz herhangi bir geri bildirim bulunmamaktadır.");
            }

            return Ok(feedBacks);
        }


        [HttpGet("/FeedBack/{id}")]
        public IActionResult GetFeedbackById(int id)
        {
            var feedBack = _context.FeedBacks
                .Include(x => x.Category)
                .Include(x => x.Commits)
                .FirstOrDefault(x => x.Id == id);

            if (feedBack == null)
            {
                return NotFound("Bu ID'ye sahip geri bildirim bulunamadı.");
            }

            return Ok(feedBack);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Save([FromBody] dtoFeedBack model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Eksik veya hatalı giriş yapıldı" });
            }

            // Kullanıcı ID'sini elde et
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest(new { message = "Geçersiz kullanıcı" });
            }

            var data = new FeedBack();


            data.Title = model.Title;
            data.Description = model.Description;
            data.CategoryId = model.CategoryId;
            // data.Category.Name = categoryName;
            data.UpdateStatus = UpdateStatus.Planed;
            data.UserId = userId; // Kullanıcı ID'sini ekle
            _context.FeedBacks.Add(data);
            _context.SaveChanges();


            return Ok(new { messsage = "Feed Eklendi" });
        }

        [Authorize]
        [HttpPut]
        public IActionResult Update([FromBody] dtoFeedBack model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Eksik veya hatalı giriş yapıldı" });
            }

            // Kullanıcı ID'sini elde et
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest(new { message = "Geçersiz kullanıcı" });
            }

            var data = new FeedBack();

            if (model.Id != 0)
            {
                data = _context.FeedBacks.Find(model.Id);
                data.Title = model.Title;
                data.Description = model.Description;
                data.CategoryId = model.CategoryId;
                data.UpdateStatus = UpdateStatus.Planed;
                data.UserId = userId; // Kullanıcı ID'sini ekle
                _context.FeedBacks.Update(data);
            }

            _context.SaveChanges();


            return Ok(new { messsage = "Feed Eklendi" });
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var invoice = _context.FeedBacks.FirstOrDefault(x => x.Id == id);

            if (invoice == null)
            {
                return NotFound("Feed bulunamadı.");
            }

            _context.FeedBacks.Remove(invoice); // remove değiştir
            _context.SaveChanges();

            return Ok("Feed başarıyla silindi.");
        }
    }
}