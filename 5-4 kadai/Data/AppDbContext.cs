using Microsoft.EntityFrameworkCore;
using benkyou5_4.Models;   // ← Employee.cs の namespace に合わせる

namespace benkyou5_4.WebAPI.Data   // ← WebAPI プロジェクトの namespace に合わせる
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}



