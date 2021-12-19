using ShemTeh.Business.Models;

namespace ShemTeh.Business.Servises
{
    public interface ITestService : IGenericService<TestDto>
    {
        int TestsCount();
        List<TestDto> GetAllTestsPage(int pageSize, int page);
        TestDto ReadByName(string name);
    }
}
