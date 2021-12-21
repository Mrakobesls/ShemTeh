namespace ShemTeh.Business.Models.Independent
{
    public class TestResults
    {
        public int TestId { get; set; }
        public List<TestResult> Results { get; set; }
    }
    public class TestResult
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Percent { get; set; }
        public DateTime DateTimeUtc { get; set; }
    }
}
