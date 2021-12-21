using ShemTeh.Business.Models;
using ShemTeh.Data.Models;
using ShemTeh.Data.UnitOfWork;

namespace ShemTeh.Business.Servises
{
    public class TestResultService : ITestResultService
    {
        private IUnitOfWork _uow;
        public TestResultService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }


        public int Add(TestResultDto entity)
        {
            TestResult entityDb = entity;
            _uow.TestResults.Create(entityDb);

            _uow.SaveChanges();

            return 0;
        }

        public TestResultDto Read(int id)
        {
            return _uow.TestResults.Read(id);
        }

        public List<TestResultDto> ReadAll()
        {
            return _uow.TestResults.ReadAll()
                .Select(c => (TestResultDto)c).ToList();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TestResultDto entity)
        {
            _uow.TestResults.Update(entity);

            _uow.SaveChanges();
        }
    }
}
