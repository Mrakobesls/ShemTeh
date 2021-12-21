using ShemTeh.Business.Models;

namespace ShemTeh.Business.Servises
{
    public interface ITestAssigneeService
    {
        int Add(TestAssigneeDto entity);

        TestAssigneeDto Read(int testId, int userId);

        List<TestAssigneeDto> ReadAll();

        void Delete(int testId, int userId);

        void Update(TestAssigneeDto entity);
    }
}
