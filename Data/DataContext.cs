using Microsoft.EntityFrameworkCore;
using Vidly.Models;

namespace Vidly.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Employees> Employee { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



        }
    }
}
