using ShemTeh.Data.Models;
using ShemTeh.Data.Repositories;
using ShemTeh.Data.Repositories.Interfaces;
using ShemTeh.Data.UnitOfWork.Interfaces;
using System;

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


        public UnitOfWork(StDbContext context)
        {
            _context = context;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
