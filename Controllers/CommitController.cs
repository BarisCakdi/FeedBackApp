using FeedBackApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace FeedBackApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CommitController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommitController(AppDbContext context)
        {
            _context = context;
        }
    }
}
