using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
