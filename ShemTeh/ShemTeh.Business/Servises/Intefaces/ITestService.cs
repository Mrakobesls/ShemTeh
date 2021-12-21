using ShemTeh.Business.Models;
using ShemTeh.Business.Models.Independent;

namespace ShemTeh.Business.Servises
{
    public interface ITestService : IGenericService<TestDto>
    {
        int TestsCount();
        List<TestDto> GetAllTestsPage(int pageSize, int page);
        TestDto ReadByName(string name);
        TestToPass GetTestToPass(int testId);
        List<TestDto> StudentTests(int studentId);
        TestAssignees GetTestAssignees(int testId);
        TestResults GetTestResults(int testId);
    }
}
