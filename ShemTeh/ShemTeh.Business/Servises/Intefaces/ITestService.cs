using ShemTeh.Business.Models;

namespace ShemTeh.Business.Servises
{
    public interface ITestService : IGenericService<TestDto>
    {
        void Add(TestDto entity);
        TestDto Read(int id);
        List<TestDto> ReadAll();
        void Delete(int id);
        void Update(TestDto entity);
        int TestsCount();
        List<TestDto> GetAllTestsPage(int pageSize, int page);
    }
}
