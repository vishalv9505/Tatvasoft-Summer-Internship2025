using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.ViewModels.Mission
{
    public class ClientMissionResponseModel
    {
        public int Id { get; set; }

        public string MissionTitle { get; set; }

        public string MissionDescription { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int? TotalSeats { get; set; }

        public DateTime? RegistrationDeadLine { get; set; }

        public int MissionThemeId { get; set; }

        public string MissionSkillId { get; set; }

        public string MissionImages { get; set; }

        public string CountryName { get; set; }

        public string CityName { get; set; }

        public string MissionThemeName { get; set; }

        public string MissionSkillName { get; set; }

        public string MissionStatus { get; set; }

        public string MissionApplyStatus { get; set; }

        public string MissionApproveStatus { get; set; }

        public string MissionDateStatus { get; set; }

        public string MissionDeadLineStatus { get; set; }
    }
}
