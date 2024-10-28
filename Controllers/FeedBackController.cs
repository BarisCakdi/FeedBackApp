using FeedBackApp.Data;
using FeedBackApp.DTOs;
using FeedBackApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var feedBack = _context.FeedBacks
                .Include(x => x.Category)
                .Include(x => x.Commits)
                .OrderByDescending(x => x.UploadsCount)
                .ToList();

            if (!feedBack.Any())
            {
                return NotFound("Henüz herhangi bir geri bildirim bulunmamaktadır.");
            }

            return Ok(feedBack);
        }

        [HttpPost]
        public IActionResult Save([FromBody] dtoFeedBack model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Eksik veya hatalı giriş yapıldı" });
            }
            var data = new FeedBack();

            if (model.Id == 0)
            {
                data.Title = model.Title;
                data.Description = model.Description;
                data.CategoryId = model.CategoryId;
                data.UpdateStatus = UpdateStatus.Planed;
                _context.FeedBacks.Add(data);
                _context.SaveChanges();
            }
            else
            {
                data = _context.FeedBacks.Find(model.Id);
                data.Title = model.Title;
                data.Description = model.Description;
                data.CategoryId = model.CategoryId;
                data.UpdateStatus = (UpdateStatus)model.UpdateStatus;
                _context.FeedBacks.Update(data);
            }
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

            _context.FeedBacks.Remove(invoice);// remove değiştir
            _context.SaveChanges();

            return Ok("Feed başarıyla silindi.");
        }



      
    }
}
