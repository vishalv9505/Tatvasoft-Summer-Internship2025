using System.ComponentModel.DataAnnotations;

namespace Mission.Entities.Models
{
    public class MissionApplication
    {
        [Key]
        public int Id { get; set; }

        public int MissionId { get; set; }

        public int UserId { get; set; }

        public DateTime AppliedDate { get; set; }

        public bool Status { get; set; } = false;

        public bool IsDelete { get; set; } = false;

        public virtual Mission Mission { get; set; }

        public virtual User User { get; set; }
    }
}
