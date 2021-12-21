using ShemTeh.Data.Models;

namespace ShemTeh.Business.Models
{
    public class TestAssigneeDto
    {
        public int TestId { get; set; }
        public int UserId { get; set; }
        public int PossibleAttempts { get; set; }
        public int CurrentAttempts { get; set; }

        public static implicit operator TestAssigneeDto(TestAssignee testAssignee)
        {
            return testAssignee is null
                ? null
                : new TestAssigneeDto
                {
                    TestId = testAssignee.TestId,
                    UserId = testAssignee.UserId,
                    PossibleAttempts = testAssignee.PossibleAttempts,
                    CurrentAttempts = testAssignee.CurrentAttempts
                };
        }

        public static implicit operator TestAssignee(TestAssigneeDto testAssigneeDto)
        {
            return testAssigneeDto is null
                ? null
                : new TestAssignee
                {
                    TestId = testAssigneeDto.TestId,
                    UserId = testAssigneeDto.UserId,
                    PossibleAttempts = testAssigneeDto.PossibleAttempts,
                    CurrentAttempts = testAssigneeDto.CurrentAttempts
                };
        }
    }
}
