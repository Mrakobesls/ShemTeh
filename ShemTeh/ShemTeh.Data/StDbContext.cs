using Microsoft.EntityFrameworkCore;
using ShemTeh.Data.Models;

namespace ShemTeh
{
    public class StDbContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MRAKOBESPC\\SQLEXPRESS01;DataBase=ShemTeh;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}