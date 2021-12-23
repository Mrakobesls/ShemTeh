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

        public void Add(TestResultDto entity)
        {
            _uow.TestResults.Create(entity);

            _uow.SaveChanges();
        }

        public TestResultDto Read(params int[] ids)
        {
            return _uow.GetContext().Find<TestResult>(ids[1], ids[0]);
        }

        public List<TestResultDto> ReadAll()
        {
            return _uow.TestResults.ReadAll()
                .Select(c => (TestResultDto)c).ToList();
        }

        public void Delete(params int[] ids)
        {
            _uow.GetContext().Remove(ids);
        }

        public void Update(TestResultDto entity)
        {
            _uow.TestResults.Update(entity);

            _uow.SaveChanges();
        }
    }
}
