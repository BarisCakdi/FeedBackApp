using System.Security.Claims;
using FeedBackApp.Data;
using FeedBackApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeedBackApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UploadController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UploadController(AppDbContext context)
        {
            _context = context;
        }
        
        // [Authorize]
        // [HttpPost("/VoteFeedback/{feedbackId}")]
        // public IActionResult VoteFeedback(int feedbackId)
        // {
        //     var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //
        //     if (userId == null)
        //     {
        //         return Unauthorized("Kullanıcı oturumu bulunamadı");
        //     }
        //
        //     using (var transaction = _context.Database.BeginTransaction())
        //     {
        //         try
        //         {
        //             var feedback = _context.FeedBacks.FirstOrDefault(x => x.Id == feedbackId);
        //             if (feedback == null)
        //             {
        //                 return NotFound("Feedback bulunamadı");
        //             }
        //
        //             var existingVote = _context.Uploads.FirstOrDefault(v => v.FeedBackId == feedbackId && v.UserId == userId);
        //             if (existingVote != null)
        //             {
        //                 _context.Uploads.Remove(existingVote);
        //                 feedback.UploadsCount--;
        //                 _context.FeedBacks.Update(feedback);
        //
        //                 _context.SaveChanges();
        //                 transaction.Commit();
        //                 return Ok("Oy kaldırıldı");
        //             }
        //
        //             var vote = new Upload()
        //             {
        //                 UserId = userId,
        //                 FeedBackId = feedbackId,
        //             };
        //
        //             _context.Uploads.Add(vote);
        //             feedback.UploadsCount++;
        //             _context.FeedBacks.Update(feedback);
        //
        //             _context.SaveChanges();
        //             transaction.Commit();
        //             return Ok("Oy eklendi");
        //         }
        //         catch
        //         {
        //             transaction.Rollback();
        //             return StatusCode(500, "Bir hata oluştu, lütfen tekrar deneyiniz.");
        //         }
        //     }
        // }
        //
        
        [Authorize]
        [HttpPost("/VoteFeedback/{feedbackId}")]
        public IActionResult VoteFeedback (int feedbackId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var feedback = _context.FeedBacks.FirstOrDefault(x => x.Id == feedbackId);
        
            if (feedback == null)
            {
                return NotFound("Feedback bulunamadı");
            }
            
            var existingVote = _context.Uploads.FirstOrDefault(v =>v.FeedBackId == feedbackId && v.UserId == userId);
        
            if (existingVote != null)
            {
                _context.Uploads.Remove(existingVote);
                feedback.UploadsCount--;
                _context.FeedBacks.Update(feedback);
        
                return Ok("Oy kaldırıldı");
            }
        
            var vote = new Upload()
            {
                UserId = userId,
                FeedBackId = feedbackId,
            };
            
            _context.Uploads.Add(vote);
            feedback.UploadsCount++;
            _context.FeedBacks.Update(feedback);
            _context.SaveChanges();
            return Ok("Oy eklendi");
        
        
        }
    }
}
