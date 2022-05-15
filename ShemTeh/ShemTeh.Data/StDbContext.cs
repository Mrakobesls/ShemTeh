using Microsoft.EntityFrameworkCore;
using System.Configuration;
using ShemTeh.Data.Models;

namespace ShemTeh.Data
{
    public class StDbContext : DbContext
    {
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Theme> Themes { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<TestAssignee> TestAssignees { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["SchemTechConnectionString"].ConnectionString;
            //optionsBuilder.UseSqlServer("Server=tcp:schemtech-appdbserver.database.windows.net,1433;Initial Catalog=SchemTech.App_db;Persist Security Info=False;User ID=Mrakobes;Password=541MaX71;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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

            modelBuilder.Entity<QuestionType>()
                    .HasData(new QuestionType[] {
                    new QuestionType { Id = 1, Name = "RadioButton" },
                    new QuestionType { Id = 2, Name = "CheckBox" }
                    });

            modelBuilder.Entity<User>()
                    .HasData(new User[] {
                    new User { Id = 1, 
                        Login = "Teacher", 
                        Password = "10000.E1oWoDmucer3gKs31Cd1NA==.acfwsZcyNgPBDPw7KDCwtPp6g7lVZCYfVBMJppZtaQQ=", 
                        FirstName = "Teacher", 
                        LastName = "Teacher", 
                        Group = 0,
                        RoleId = 2}
                    });
        }
    }
}