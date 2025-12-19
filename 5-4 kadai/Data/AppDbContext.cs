using Microsoft.EntityFrameworkCore;
using SharedModels;   // ← Employee.cs の namespace に合わせる ここにエラー　ｃｓ０２３４

namespace benkyou5_4.WebAPI.Data   // ← WebAPI プロジェクトの namespace に合わせる
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }　　// cs0246
    }
}



