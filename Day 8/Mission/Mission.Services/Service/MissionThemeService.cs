using Mission.Entities.Models;
using Mission.Entities.ViewModels.MissionTheme;
using Mission.Repositories.IRepository;
using Mission.Services.IService;

namespace Mission.Services.Service
{
    public class MissionThemeService(IMissionThemeRepository missionThemeRepository) : IMissionThemeService
    {
        private readonly IMissionThemeRepository _missionThemeRepository = missionThemeRepository;
        public Task<bool> AddMissionTheme(MissionThemeViewModel model)
        {
            var missionTheme = new MissionTheme()
            {
                Id = model.Id,
                Status = model.Status,
                ThemeName = model.ThemeName,
            };
            return _missionThemeRepository.AddMissionTheme(missionTheme);
        }

        public Task<bool> DeleteMissionTheme(int missionThemeId)
        {
            return _missionThemeRepository.DeleteMissionTheme(missionThemeId);
        }

        public Task<List<MissionThemeViewModel>> GetAllMissionTheme()
        {
            return _missionThemeRepository.GetAllMissionTheme();
        }

        public Task<MissionThemeViewModel?> GetMissionThemeById(int missionThemeId)
        {
            return _missionThemeRepository.GetMissionThemeById(missionThemeId);
        }

        public Task<bool> UpdateMissionTheme(MissionThemeViewModel model)
        {
            var missionTheme = new MissionTheme()
            {
                Id = model.Id,
                Status = model.Status,
                ThemeName = model.ThemeName,
            };
            return _missionThemeRepository.UpdateMissionTheme(missionTheme);
        }
    }
}
