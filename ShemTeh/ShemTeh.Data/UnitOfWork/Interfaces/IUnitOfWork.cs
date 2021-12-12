using ShemTeh.Data.Models;
using ShemTeh.Data.Repositories.Interfaces;

namespace ShemTeh.Data.UnitOfWork.Interfaces
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
