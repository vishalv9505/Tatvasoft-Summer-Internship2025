using Mission.Entities.ViewModels.MissionTheme;

namespace Mission.Services.IService
{
    public interface IMissionThemeService
    {
        Task<List<MissionThemeViewModel>> GetAllMissionTheme();

        Task<MissionThemeViewModel?> GetMissionThemeById(int missionThemeId);

        Task<bool> AddMissionTheme(MissionThemeViewModel model);

        Task<bool> UpdateMissionTheme(MissionThemeViewModel model);

        Task<bool> DeleteMissionTheme(int missionThemeId);
    }
}
