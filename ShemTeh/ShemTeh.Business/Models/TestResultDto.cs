using ShemTeh.Data.Models;

namespace ShemTeh.Business.Models
{
    public class TestResultDto
    {
        public int TestId { get; set; }
        public int UserId { get; set; }
        public int AttemptNumber { get; set; }
        public double CorrectAnswersPercent { get; set; }
        public DateTime DateTimeUtc { get; set; }

        public static implicit operator TestResultDto(TestResult testResult)
        {
            return testResult is null
                ? null
                : new TestResultDto
                {
                    TestId = testResult.TestId,
                    UserId = testResult.UserId,
                    AttemptNumber = testResult.AttemptNumber,
                    CorrectAnswersPercent = testResult.CorrectAnswersPercent,
                    DateTimeUtc = testResult.DateTimeUtc
                };
        }

        public static implicit operator TestResult(TestResultDto testResultDto)
        {
            return testResultDto is null
                ? null
                : new TestResult
                {
                    TestId = testResultDto.TestId,
                    UserId = testResultDto.UserId,
                    AttemptNumber = testResultDto.AttemptNumber,
                    CorrectAnswersPercent = testResultDto.CorrectAnswersPercent,
                    DateTimeUtc = testResultDto.DateTimeUtc
                };
        }
    }
}
