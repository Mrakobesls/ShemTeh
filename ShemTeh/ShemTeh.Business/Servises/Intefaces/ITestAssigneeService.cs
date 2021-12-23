using ShemTeh.Business.Models;

namespace ShemTeh.Business.Servises
{
    public interface ITestAssigneeService
    {
        void Add(TestAssigneeDto entity);

        TestAssigneeDto Read(params int[] ids);

        List<TestAssigneeDto> ReadAll();

        void Delete(params int[] ids);

        void Update(TestAssigneeDto entity);
    }
}
