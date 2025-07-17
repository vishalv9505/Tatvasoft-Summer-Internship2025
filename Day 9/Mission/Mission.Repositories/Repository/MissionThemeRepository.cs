using Microsoft.EntityFrameworkCore;
using Mission.Entities;
using Mission.Entities.Models;
using Mission.Entities.ViewModels.MissionTheme;
using Mission.Repositories.IRepository;

namespace Mission.Repositories.Repository
{
    public class MissionThemeRepository(MissionDbContext missionDbContext) : IMissionThemeRepository
    {
        private readonly MissionDbContext _missionDbContext = missionDbContext;

        public async Task<bool> AddMissionTheme(MissionTheme missionTheme)
        {
            _missionDbContext.MissionThemes.Add(missionTheme);
            await _missionDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMissionTheme(int missionThemeId)
        {
            var missionThemeExistingInDb = await _missionDbContext.MissionThemes.FindAsync(missionThemeId);

            if (missionThemeExistingInDb == null)
                return false;

            _missionDbContext.Remove(missionThemeExistingInDb);
            await _missionDbContext.SaveChangesAsync();
            return true;
        }

        public Task<List<MissionThemeViewModel>> GetAllMissionTheme()
        {
            return _missionDbContext.MissionThemes
                .Select(m => new MissionThemeViewModel()
                {
                    Id = m.Id,
                    Status = m.Status,
                    ThemeName = m.ThemeName,
                })
                .ToListAsync();
        }

        public Task<MissionThemeViewModel?> GetMissionThemeById(int missionThemeId)
        {
            return _missionDbContext.MissionThemes
                .Where(m => m.Id == missionThemeId)
                .Select(m => new MissionThemeViewModel()
                {
                    Id = m.Id,
                    Status = m.Status,
                    ThemeName = m.ThemeName,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateMissionTheme(MissionTheme missionTheme)
        {
            var missionThemeExistingInDb = await _missionDbContext.MissionThemes.FindAsync(missionTheme.Id);

            if (missionThemeExistingInDb == null)
                return false;

            missionThemeExistingInDb.ThemeName = missionTheme.ThemeName;
            missionThemeExistingInDb.Status = missionTheme.Status;
            await _missionDbContext.SaveChangesAsync();

            return true;
        }
    }
}
