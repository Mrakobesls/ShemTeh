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

        public List<TestDto> StudentTests(int studentId)
        {
            return _uow.GetContext().Tests.Include(t => t.TestAssignees)
                .Where(t => t.TestAssignees.Any(ta => ta.UserId == studentId && ta.CurrentAttempts < ta.PossibleAttempts))
                .Select(t => (TestDto)t).ToList();
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
            Test entityDb = entity;
            _uow.GetContext().Entry(entityDb);
            _uow.Tests.Update(entityDb);

            _uow.SaveChanges();
        }

        public int TestsCount(int userId)
        {
            return _uow.Tests.ReadAll().Where(t => t.TestOwnerId == userId).Count();
        }

        public List<TestDto> GetAllTestsPage(int pageSize, int page, int userId)
        {
            return _uow.Tests.ReadAll().Where(t => t.TestOwnerId == userId)
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
                            Name = qa.IsCorrect ? qa.Name + "." : qa.Name
                        }).ToList()
                    }).ToList()
                }).First();
        }

        public Models.Independent.TestAssignees GetTestAssignees(int testId)
        {
            return new Models.Independent.TestAssignees()
            {
                TestId = testId,
                Assignees = _uow.GetContext().Users
                .Include(u => u.TestAssignees)
                .Where(u => u.RoleId == 3)
                .Select(ta => new Models.Independent.TestAssignee()
                {
                    UserId = ta.Id,
                    FirstName = ta.FirstName,
                    LastName = ta.LastName,
                    IsAssigned = ta.TestAssignees.Any(u => u.UserId == ta.Id)
                }).ToList()
            };
        }

        public Models.Independent.TestResults GetTestResults(int testId)
        {
            return new Models.Independent.TestResults()
            {
                TestId = testId,
                Results = _uow.GetContext().TestResults
                .Include(u => u.User)
                .Select(ta => new Models.Independent.TestResult()
                {
                    UserId = ta.User.Id,
                    FirstName = ta.User.FirstName,
                    LastName = ta.User.LastName,
                    Percent = (int)(100 * ta.CorrectAnswersPercent),
                    DateTimeUtc = ta.DateTimeUtc
                }).ToList()
            };
        }

    }
}
