using ShemTeh.Data.Models;
using ShemTeh.Data.Repositories;

namespace ShemTeh.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private StDbContext _context;

        public IGenericRepository<QuestionType> _questionTypes;
        public IGenericRepository<QuestionType> QuestionsTypes => _questionTypes ??= new GenericRepository<QuestionType>(_context);

        public IGenericRepository<Test> _tests;
        public IGenericRepository<Test> Tests => _tests ??= new GenericRepository<Test>(_context);

        public IGenericRepository<Question> _questions;
        public IGenericRepository<Question> Questions => _questions ??= new GenericRepository<Question>(_context);

        public IGenericRepository<QuestionAnswer> _questionAnswer;
        public IGenericRepository<QuestionAnswer> QuestionAnswers => _questionAnswer ??= new GenericRepository<QuestionAnswer>(_context);

        public IGenericRepository<TestAssignee> _testAssignees;
        public IGenericRepository<TestAssignee> TestAssignees => _testAssignees ??= new GenericRepository<TestAssignee>(_context);

        public IGenericRepository<TestResult> _testResults;
        public IGenericRepository<TestResult> TestResults => _testResults ??= new GenericRepository<TestResult>(_context);

        public IGenericRepository<User> _users;
        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);

        public IGenericRepository<Role> _roles;
        public IGenericRepository<Role> Roles => _roles ??= new GenericRepository<Role>(_context);

        public UnitOfWork(StDbContext context)
        {
            _context = context;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public StDbContext GetContext()
        {
            return _context;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public void DetachAllEntities()
        {
            _context.ChangeTracker.Clear();
        }
    }
}
