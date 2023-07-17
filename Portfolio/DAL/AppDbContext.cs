using Microsoft.EntityFrameworkCore;

namespace Portfolio.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }
    }
}
