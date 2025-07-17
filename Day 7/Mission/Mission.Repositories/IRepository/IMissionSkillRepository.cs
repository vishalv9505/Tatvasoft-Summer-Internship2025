using Mission.Entities.ViewModels.MissionSkill;

namespace Mission.Repositories.IRepository
{
    public interface IMissionSkillRepository
    {
        Task AddMissionSkillAsync(UpsertMissionSkillRequestModel model);

        Task<List<MissionSkillResponseModel>> GetMissionSkillListAsync();

        Task<MissionSkillResponseModel?> GetMissionSkillByIdAsync(int missionSkillId);
        Task<bool> UpdateMissionSkillAsync(UpsertMissionSkillRequestModel model);

        Task<bool> DeleteMissionSkill(int id);
    }
}
