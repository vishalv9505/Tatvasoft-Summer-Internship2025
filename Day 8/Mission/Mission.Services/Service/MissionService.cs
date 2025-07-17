using Mission.Entities.ViewModels.Mission;
using Mission.Entities.ViewModels.MissionApplication;
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

        public async Task<(bool result, string message)> ApplyMission(ApplyMissionRequestModel model)
        {
            return await _missionRepository.ApplyMission(model);
        }

        public async Task<List<MissionApplicationResponseModel>> GetMissionApplicationList()
        {
            return await _missionRepository.GetMissionApplicationList();
        }

        public async Task<bool> MissionApplicationApprove(MissionApplicationResponseModel model)
        {
            return await _missionRepository.MissionApplicationApprove(model);
        }

        public async Task<bool> MissionApplicationDelete(MissionApplicationResponseModel model)
        {
            return await _missionRepository.MissionApplicationDelete(model);
        }
    }
}
