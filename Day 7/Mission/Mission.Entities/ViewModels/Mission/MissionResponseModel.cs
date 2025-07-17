namespace Mission.Entities.ViewModels.Mission
{
    public class MissionResponseModel
    {
        public int Id { get; set; }
        public string MissionTitle { get; set; }
        public string MissionThemeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
