using Mission.Entities.ViewModels.Mission;
using Mission.Repositories.IRepository;
using Mission.Services.IService;

namespace Mission.Services.Service
{
    public class MissionService(IMissionRepository missionRepository) : IMissionService
    {
        private readonly IMissionRepository _missionRepository = missionRepository;

        public async Task AddMissionRequestAsync(AddMissionRequestModel model)
        {
            await _missionRepository.AddMissionRequestAsync(model);
            return;
        }

        public async Task<List<ClientMissionResponseModel>> GetClientSideMissionList(int userId)
        {
            return await _missionRepository.GetClientSideMissionList(userId);
        }

        public async Task<List<MissionResponseModel>> GetMissionList()
        {
            return await _missionRepository.GetMissionList();
        }

        public Task<MissionRequestViewModel?> GetMissionById(int id)
        {
            return _missionRepository.GetMissionById(id);
        }

        public async Task<bool> UpdateMission(MissionRequestViewModel model)
        {
            return await _missionRepository.UpdateMission(model);
        }

        public async Task<bool> DeleteMission(int missionId)
        {
            return await _missionRepository.DeleteMission(missionId);
        }
    }
}
