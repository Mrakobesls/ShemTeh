using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShemTeh.Data.Models
{
    public class Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int TestOwnerId { get; set; }
        //[ForeignKey("TestOwnerId")]
        //public virtual User TestOwner { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<TestAssignee> TestAssignees { get; set; }
        public virtual ICollection<TestResult> TestResults { get; set; }
    }
}
