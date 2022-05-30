using Corporate.Models;
using Microsoft.EntityFrameworkCore;

namespace Corporate.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<AboutCarts> AboutCarts { get; set; }
        public DbSet<PortfolioCategory> PortfolioCategories { get; set; }
        public DbSet<PortfolioItem> PortfolioItems { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientComment> ClientComments { get; set; }
    }
}
