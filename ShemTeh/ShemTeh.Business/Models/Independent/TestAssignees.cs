namespace ShemTeh.Business.Models.Independent
{
    public class TestAssignees
    {
        public int TestId { get; set; }
        public List<TestAssignee> Assignees { get; set; }
    }
    public class TestAssignee
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAssigned { get; set; }
    }
}
