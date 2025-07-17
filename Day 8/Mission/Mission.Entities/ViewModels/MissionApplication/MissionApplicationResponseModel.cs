namespace Mission.Entities.ViewModels.MissionApplication
{
    public class MissionApplicationResponseModel
    {
        public int Id { get; set; }
        public string MissionTitle { get; set; }

        public string MissionTheme { get; set; }

        public string UserName { get; set; }

        public DateTime AppliedDate { get; set; }

        public bool Status { get; set; }
    }
}
