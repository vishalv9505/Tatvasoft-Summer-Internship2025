using Mission.Entities.ViewModels.MissionSkill;
using Mission.Repositories.IRepository;
using Mission.Services.IService;

namespace Mission.Services.Service
{
    public class MissionSkillService(IMissionSkillRepository missionSkillRepository) : IMissionSkillService
    {
        private readonly IMissionSkillRepository _missionSkillRepository = missionSkillRepository;

        public async Task AddMissionSkillAsync(UpsertMissionSkillRequestModel model)
        {
            await _missionSkillRepository.AddMissionSkillAsync(model);
            return;
        }

        public async Task<bool> DeleteMissionSkill(int id)
        {
            return await _missionSkillRepository.DeleteMissionSkill(id);
        }

        public async Task<MissionSkillResponseModel?> GetMissionSkillByIdAsync(int missionSkillId)
        {
            return await _missionSkillRepository.GetMissionSkillByIdAsync(missionSkillId);
        }

        public async Task<List<MissionSkillResponseModel>> GetMissionSkillListAsync()
        {
            return await _missionSkillRepository.GetMissionSkillListAsync();
        }

        public async Task<bool> UpdateMissionSkillAsync(UpsertMissionSkillRequestModel model)
        {
            return await _missionSkillRepository.UpdateMissionSkillAsync(model);
        }
    }
}
