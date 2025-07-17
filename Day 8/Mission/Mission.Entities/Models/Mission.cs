using System.ComponentModel.DataAnnotations;

namespace Mission.Entities.Models
{
    public class Mission
    {
        [Key]
        public int Id { get; set; }

        public int CountryId { get; set; }
        public int CityId { get; set; }

        public string MissionTitle { get; set; }

        public int MissionThemeId { get; set; }

        public string MissionDescription { get; set; }

        public int TotalSeats { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string MissionImages { get; set; }

        public string MissionSkillId { get; set; }

        public virtual MissionTheme MissionTheme { get; set; }

        public virtual Country Country { get; set; }

        public virtual City City { get; set; }
    }
}
