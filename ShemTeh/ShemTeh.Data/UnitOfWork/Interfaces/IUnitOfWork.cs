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

        void SaveChanges();
    }
}
