using ShemTeh.Data.Models;
using ShemTeh.Data.Repositories;

namespace ShemTeh.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<QuestionType> QuestionsTypes { get; }
        IGenericRepository<Test> Tests { get; }
        IGenericRepository<Question> Questions { get; }
        IGenericRepository<QuestionAnswer> QuestionAnswers { get; }
        IGenericRepository<TestAssignee> TestAssignees { get; }
        IGenericRepository<TestResult> TestResults { get; }
        IGenericRepository<User> Users { get; }
        IGenericRepository<Role> Roles { get; }

        void SaveChanges();
        StDbContext GetContext();
    }
}
