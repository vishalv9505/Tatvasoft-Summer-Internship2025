using Mission.Entities.Models;
using Mission.Entities.ViewModels.MissionTheme;

namespace Mission.Repositories.IRepository
{
    public interface IMissionThemeRepository
    {
        Task<List<MissionThemeViewModel>> GetAllMissionTheme();

        Task<MissionThemeViewModel?> GetMissionThemeById(int missionThemeId);

        Task<bool> AddMissionTheme(MissionTheme missionTheme);

        Task<bool> UpdateMissionTheme(MissionTheme missionTheme);

        Task<bool> DeleteMissionTheme(int missionThemeId);
    }
}
