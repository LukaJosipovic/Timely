using Microsoft.EntityFrameworkCore;
using Timely.Models;

namespace Timely.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
    }
}
