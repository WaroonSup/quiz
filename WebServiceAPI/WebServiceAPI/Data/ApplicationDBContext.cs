using Microsoft.EntityFrameworkCore;
using WebServiceAPI.Models;

namespace WebServiceAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }


        public DbSet<Order> Orders { get; set; }
    }
}
