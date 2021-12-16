using Microsoft.EntityFrameworkCore;
using HW11.Services.Database.Models;

namespace HW11.Services.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<CalculatingExpression> CalculatingExpressions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}