using Microsoft.EntityFrameworkCore;
using ProductDetails.Model;

namespace ProductDetails.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
      public DbSet<Issues> Issues { get; set; } 
      public DbSet<IssueDetail> IssueDetails { get; set; }
    }
}
