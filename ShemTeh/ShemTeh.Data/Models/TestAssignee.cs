using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShemTeh.Data.Models
{
    public class TestAssignee
    {
        public int TestId { get; set; }
        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [Required]
        public int PossibleAttempts { get; set; }
        [Required]
        public int CurrentAttempts { get; set; }
    }
}
