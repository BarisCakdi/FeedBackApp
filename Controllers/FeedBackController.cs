using FeedBackApp.Data;
using Microsoft.AspNetCore.Mvc;

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

      
    }
}
