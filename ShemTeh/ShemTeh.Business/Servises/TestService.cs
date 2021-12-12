using ShemTeh.Business.Models;
using ShemTeh.Data.UnitOfWork.Interfaces;

namespace ShemTeh.Business.Servises.Intefaces
{
    public class TestService : ITestService
    {
        private IUnitOfWork _uow;
        public TestService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }


        public void Add(TestDto entity)
        {
            throw new NotImplementedException();
        }

        public TestDto Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<TestDto> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TestDto entity)
        {
            throw new NotImplementedException();
        }

        public int TestsCount()
        {
            return _uow.Tests.ReadAll().Count();
        }

        public List<TestDto> GetAllTestsPage(int pageSize, int page)
        {
            return _uow.Tests.ReadAll().Skip((page - 1) * pageSize).Take(pageSize).Select(c => new TestDto()
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }
    }
}
