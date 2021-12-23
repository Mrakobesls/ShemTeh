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


        public void Add(TestAssigneeDto entity)
        {
            _uow.TestAssignees.Create(entity);

            _uow.SaveChanges();
        }

        public TestAssigneeDto Read(params int[] ids)
        {
            return _uow.GetContext().Find<TestAssignee>(ids[1], ids[0]);
        }

        public List<TestAssigneeDto> ReadAll()
        {
            return _uow.TestAssignees.ReadAll()
                .Select(c => (TestAssigneeDto)c).ToList();
        }

        public void Delete(params int[] ids)
        {
            _uow.GetContext().Remove(ids);
        }

        public void Update(TestAssigneeDto entity)
        {
            //TestAssignee entityDb = entity;
            //_uow.GetContext().Entry(entityDb);
            //_uow.TestAssignees.Update(entityDb);

            var temp = _uow.GetContext().TestAssignees.First(ta => ta.UserId == entity.UserId && ta.TestId == entity.TestId);
            temp.PossibleAttempts = entity.PossibleAttempts;
            temp.CurrentAttempts = entity.CurrentAttempts;

            _uow.SaveChanges();
        }
    }
}
