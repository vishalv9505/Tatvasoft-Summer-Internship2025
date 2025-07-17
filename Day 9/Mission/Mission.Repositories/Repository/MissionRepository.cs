using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mission.Entities;
using Mission.Entities.Models;
using Mission.Entities.ViewModels.Mission;
using Mission.Entities.ViewModels.MissionApplication;
using Mission.Repositories.IRepository;

namespace Mission.Repositories.Repository
{
    public class MissionRepository(MissionDbContext dbContext) : IMissionRepository
    {
        private readonly MissionDbContext _dbContext = dbContext;

        public async Task AddMissionRequestAsync(AddMissionRequestModel model)
        {
            var mission = new Entities.Models.Mission()
            {
                CityId = model.CityId,
                CountryId = model.CountryId,
                MissionDescription = model.MissionDescription,
                MissionImages = model.MissionImages,
                MissionSkillId = model.MissionSkillId,
                MissionThemeId = model.MissionThemeId,
                MissionTitle = model.MissionTitle,
                StartDate = model.StartDate.Date.ToUniversalTime(),
                EndDate = model.EndDate.Date.ToUniversalTime(),
                TotalSeats = model.TotalSeats,
            };

            _dbContext.Missions.Add(mission);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<MissionResponseModel>> GetMissionList()
        {
            var query = _dbContext.Missions.Select(m => new MissionResponseModel()
            {
                Id = m.Id,
                MissionTitle = m.MissionTitle,
                StartDate = m.StartDate,
                EndDate = m.EndDate,
                MissionThemeName = m.MissionTheme.ThemeName
            }).AsQueryable();

            return await query.ToListAsync();
        }

        public async Task<MissionRequestViewModel?> GetMissionById(int id)
        {
            return await _dbContext.Missions.Where(m => m.Id == id).Select(m => new MissionRequestViewModel()
            {
                Id = m.Id,
                CityId = m.CityId,
                CountryId = m.CountryId,
                EndDate = m.EndDate,
                MissionDescription = m.MissionDescription,
                MissionImages = m.MissionImages,
                MissionSkillId = m.MissionSkillId,
                MissionThemeId = m.MissionThemeId,
                MissionTitle = m.MissionTitle,
                StartDate = m.StartDate,
                TotalSeats = m.TotalSeats,
            }).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateMission(MissionRequestViewModel mission)
        {
            var missionInDb = _dbContext.Missions.Find(mission.Id);

            if (missionInDb == null)
                return false;

            missionInDb.MissionTitle = mission.MissionTitle;
            missionInDb.MissionDescription = mission.MissionDescription;
            missionInDb.CityId = mission.CityId;
            missionInDb.CountryId = mission.CountryId;
            missionInDb.MissionSkillId = mission.MissionSkillId;
            missionInDb.MissionThemeId = mission.MissionThemeId;
            missionInDb.MissionImages = $"{missionInDb.MissionImages},{mission.MissionImages}";
            missionInDb.StartDate = mission.StartDate.ToUniversalTime();
            missionInDb.EndDate = mission.EndDate.ToUniversalTime();
            missionInDb.TotalSeats = mission.TotalSeats;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMission(int missionId)
        {
            var missionInDb = _dbContext.Missions.Find(missionId);

            if (missionInDb == null)
                return false;

            _dbContext.Missions.Remove(missionInDb);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ClientMissionResponseModel>> GetClientSideMissionList(int userId)
        {
            try
            {
                var response = _dbContext.Missions.Select(m => new ClientMissionResponseModel()
                {
                    Id = m.Id,
                    MissionTitle = m.MissionTitle,
                    MissionDescription = m.MissionDescription,
                    CountryId = m.CountryId,
                    CityId = m.CityId,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    TotalSeats = m.TotalSeats,
                    MissionThemeId = m.MissionThemeId,
                    MissionSkillId = m.MissionSkillId,
                    MissionImages = m.MissionImages,
                    CountryName = m.Country.CountryName,
                    CityName = m.City.CityName,
                    MissionThemeName = m.MissionTheme.ThemeName,
                    MissionSkillName = string.Join(",", _dbContext.MissionSkills
                     .Where(ms => m.MissionSkillId.Contains(ms.Id.ToString()))
                     .Select(ms => ms.SkillName)
                     .ToList()),
                    //MissionStatus = m.RegistrationDeadLine < dateToCompare ? "Closed" : "Available",
                    MissionApplyStatus = _dbContext.MissionApplications.Any(ma => !ma.IsDelete && ma.MissionId == m.Id && ma.UserId == userId) ? "Applied" : "Apply",
                    MissionApproveStatus = _dbContext.MissionApplications.Any(ma => !ma.IsDelete && ma.MissionId == m.Id && ma.UserId == userId && ma.Status) ? "Approved" : "Applied",
                }).ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(bool result, string message)> ApplyMission(ApplyMissionRequestModel model)
        {
            var mission = _dbContext.Missions.Find(model.MissionId);

            if (mission == null)
                return (false, "Not Found");

            if (mission.TotalSeats <= 0)
                return (false, "You can apply on this mission because seats are already full");

            var missionApplication = new MissionApplication()
            {
                MissionId = model.MissionId,
                UserId = model.UserId,
                AppliedDate = model.AppliedDate.ToUniversalTime(),
            };

            mission.TotalSeats--;

            _dbContext.MissionApplications.Add(missionApplication);

            await _dbContext.SaveChangesAsync();
            return (true, "Mission Applied Successfully");
        }

        public async Task<List<MissionApplicationResponseModel>> GetMissionApplicationList()
        {
            return await _dbContext.MissionApplications.Where(m => !m.IsDelete)
                .Select(m => new MissionApplicationResponseModel()
                {
                    Id = m.Id,
                    MissionTitle = m.Mission.MissionTitle,
                    MissionTheme = m.Mission.MissionTheme.ThemeName,
                    UserName = m.User.FirstName + " " + m.User.LastName,
                    AppliedDate = m.AppliedDate,
                    Status = m.Status,
                }).ToListAsync();
        }

        public async Task<bool> MissionApplicationApprove(MissionApplicationResponseModel model)
        {
            var missionApplication = _dbContext.MissionApplications.Find(model.Id);

            if (missionApplication == null)
                return false;

            missionApplication.Status = true;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MissionApplicationDelete(MissionApplicationResponseModel model)
        {
            var missionApplication = _dbContext.MissionApplications
                .Include(m => m.Mission).FirstOrDefault(m => m.Id == model.Id);

            if (missionApplication == null)
                return false;

            missionApplication.IsDelete = true;

            missionApplication.Mission.TotalSeats++;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
