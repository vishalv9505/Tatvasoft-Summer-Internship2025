using Mission.Entities.ViewModels.MissionSkill;

namespace Mission.Services.IService
{
    public interface IMissionSkillService
    {
        Task AddMissionSkillAsync(UpsertMissionSkillRequestModel model);

        Task<List<MissionSkillResponseModel>> GetMissionSkillListAsync();

        Task<MissionSkillResponseModel?> GetMissionSkillByIdAsync(int missionSkillId);
        Task<bool> UpdateMissionSkillAsync(UpsertMissionSkillRequestModel model);

        Task<bool> DeleteMissionSkill(int id);
    }
}
