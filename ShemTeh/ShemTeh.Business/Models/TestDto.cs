using ShemTeh.Data.Models;

namespace ShemTeh.Business.Models
{
    public class TestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TestOwnerId { get; set; }

        public static implicit operator TestDto(Test test)
        {
            return test is null
                ? null
                : new TestDto
                {
                    Id = test.Id,
                    Name = test.Name,
                    TestOwnerId = test.TestOwnerId
                };
        }


        public static implicit operator Test(TestDto testDto)
        {
            return testDto is null
                ? null
                : new Test
                {
                    Id = testDto.Id,
                    Name = testDto.Name,
                    TestOwnerId = testDto.TestOwnerId
                };
        }
    }
}
