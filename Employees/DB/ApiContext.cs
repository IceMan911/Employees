using Employees.DBModels;
using Microsoft.EntityFrameworkCore;

namespace Employees.DB
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Employee> employees { get; set; }

    }
}
