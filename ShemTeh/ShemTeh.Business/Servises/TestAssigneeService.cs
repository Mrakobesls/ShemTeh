using ShemTeh.Business.Models;
using ShemTeh.Data.Models;
using ShemTeh.Data.UnitOfWork;

namespace ShemTeh.Business.Servises
{
    public class TestAssigneeService : ITestAssigneeService
    {
        private IUnitOfWork _uow;
        public TestAssigneeService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }


        public int Add(TestAssigneeDto entity)
        {
            TestAssignee entityDb = entity;
            _uow.TestAssignees.Create(entityDb);

            _uow.SaveChanges();

            return 0;
        }

        public TestAssigneeDto Read(int testId, int userId)
        {
            return _uow.GetContext().Find<TestAssignee>(new int[] { testId, userId });
        }

        public List<TestAssigneeDto> ReadAll()
        {
            return _uow.TestAssignees.ReadAll()
                .Select(c => (TestAssigneeDto)c).ToList();
        }

        public void Delete(int testId, int userId)
        {
            _uow.GetContext().Remove(new int[] { testId, userId } );
        }

        public void Update(TestAssigneeDto entity)
        {
            _uow.TestAssignees.Update(entity);

            _uow.SaveChanges();
        }
    }
}
