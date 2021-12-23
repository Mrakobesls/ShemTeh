using ShemTeh.Business.Models;

namespace ShemTeh.Business.Servises
{
    public interface ITestResultService
    {
        void Add(TestResultDto entity);

        TestResultDto Read(params int[] ids);

        List<TestResultDto> ReadAll();

        void Delete(params int[] ids);

        void Update(TestResultDto entity);
    }
}
