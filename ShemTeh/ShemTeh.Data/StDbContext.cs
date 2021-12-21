using Microsoft.EntityFrameworkCore;
using ShemTeh.Data.Models;

namespace ShemTeh.Data
{
    public class StDbContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<TestAssignee> TestAssignees { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MRAKOBESPC\\SQLEXPRESS01;DataBase=ShemTeh;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestAssignee>()
                .HasKey(k => new { k.UserId, k.TestId });
            modelBuilder.Entity<TestResult>()
                .HasKey(k => new { k.UserId, k.TestId });

            modelBuilder.Entity<Role>()
                .HasData(new Role[] { 
                    new Role { Id = 1, Name = "Admin" }, 
                    new Role { Id = 2, Name = "Teacher" }, 
                    new Role { Id = 3, Name = "Student" } 
                });
        }
    }
}