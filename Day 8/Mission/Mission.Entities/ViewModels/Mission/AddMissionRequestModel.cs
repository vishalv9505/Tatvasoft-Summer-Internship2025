namespace Mission.Entities.ViewModels.Mission
{
    public class AddMissionRequestModel
    {
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
    }
}
