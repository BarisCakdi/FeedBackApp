using FeedBackApp.Data;
using FeedBackApp.DTOs;
using FeedBackApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;

namespace FeedBackApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CommitController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommitController(AppDbContext context)
        {
            _context = context;
        }
        

        


        // Yeni bir Commit ekleme
        [HttpPost]
        public IActionResult AddCommit([FromBody] dtoCommit model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Eksik veya hatalı giriş yapıldı" });
            }

            var userId = (User.FindFirstValue(ClaimTypes.NameIdentifier));
            var username = User.FindFirstValue(ClaimTypes.Name);

            var data = new Commit();
            {
                data.Description = model.Description;
                data.UserId = userId;
                data.UserName = username;
                data.FeedBackId = model.FeedBackId;
                data.CommitId = model.CommitId; // Üst Commit ID (üst yorum varsa)
                data.Created = DateTime.UtcNow;
            }


            _context.Commits.Add(data);
            _context.SaveChanges();

            return Ok(new { message = "Yorum başarıyla eklendi" });
        }

        // Commit güncelleme
        [HttpPut("{id}")]
        public IActionResult UpdateCommit(int id, [FromBody] dtoCommit model)
        {
            var commit = _context.Commits.Find(id);

            if (commit == null)
            {
                return NotFound("Yorum bulunamadı.");
            }

            commit.Description = model.Description;
            commit.UserId = model.UserId;
            commit.FeedBackId = model.FeedBackId;
            commit.CommitId = model.CommitId;

            _context.Commits.Update(commit);
            _context.SaveChanges();

            return Ok(new { message = "Yorum başarıyla güncellendi" });
        }

        // Commit silme
        [HttpDelete("{id}")]
        public IActionResult DeleteCommit(int id)
        {
            var commit = _context.Commits.Find(id);

            if (commit == null)
            {
                return NotFound("Yorum bulunamadı.");
            }

            _context.Commits.Remove(commit);
            _context.SaveChanges();

            return Ok(new { message = "Yorum başarıyla silindi" });
        }
    }
}