using Microsoft.EntityFrameworkCore;

namespace FeedBackApp.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }
    }
}
