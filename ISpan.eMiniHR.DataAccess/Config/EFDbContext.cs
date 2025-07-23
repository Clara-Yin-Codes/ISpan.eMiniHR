using ISpan.eMiniHR.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ISpan.eMiniHR.DataAccess.Config
{
    public class EFDbContext : DbContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<UsersEntity> Users { get; set; }
        public DbSet<ProgramPermissionsEntity> ProgramPermissions { get; set; }
        //public DbSet<DeptsDto> Depts { get; set; }
        //public DbSet<JobGradesDto> JobGrades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connStr = SqlDB.ConnectionString;
                optionsBuilder.UseSqlServer(connStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeEntity>().ToTable("Employee"); // 顯示指定資料表名稱
            modelBuilder.Entity<UsersEntity>().ToTable("Users");
            modelBuilder.Entity<ProgramPermissionsEntity>().HasKey(p => new { p.ProgSysId, p.EmpId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
