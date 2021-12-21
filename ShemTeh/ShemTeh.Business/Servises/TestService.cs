using Microsoft.EntityFrameworkCore;
using ShemTeh.Business.Models;
using ShemTeh.Data.Models;
using ShemTeh.Data.UnitOfWork;

namespace ShemTeh.Business.Servises
{
    public class TestService : ITestService
    {
        private IUnitOfWork _uow;
        public TestService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }


        public int Add(TestDto entity)
        {
            Test entityDb = entity;
            _uow.Tests.Create(entityDb);

            _uow.SaveChanges();

            return entityDb.Id;
        }

        public TestDto Read(int id)
        {
            return _uow.Tests.Read(id);
        }

        public List<TestDto> ReadAll()
        {
            return _uow.Tests.ReadAll()
                .Select(c => (TestDto)c).ToList();
        }

        public TestDto ReadByName(string name)
        {
            return _uow.Tests.ReadAll().FirstOrDefault(x => x.Name == name);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TestDto entity)
        {
            _uow.Tests.Update(entity);

            _uow.SaveChanges();
        }

        public int TestsCount()
        {
            return _uow.Tests.ReadAll().Count();
        }

        public List<TestDto> GetAllTestsPage(int pageSize, int page)
        {
            return _uow.Tests.ReadAll()
                .Skip((page - 1) * pageSize).Take(pageSize)
                .Select(t => (TestDto)t).ToList();
        }

        public Models.Independent.TestToPass GetTestToPass(int testId)
        {
            return _uow.GetContext().Tests
                .Include(t => t.Questions).ThenInclude(q => q.QuestionAnswers)
                .Where(t => t.Id == testId)
                .Select(t => new Models.Independent.TestToPass()
                {
                    TestId = t.Id,
                    Name = t.Name,
                    Questions = t.Questions.Select(q => new Models.Independent.Question
                    {
                        QuestionId = q.Id,
                        Name = q.Name,
                        QuestionAnswers = q.QuestionAnswers.Select(qa => new Models.Independent.QuestionAnswer()
                        {
                            QuestionAnswerId = qa.Id,
                            Name = qa.Name

                        }).ToList()
                    }).ToList()
                }).First();
        }
    }
}
