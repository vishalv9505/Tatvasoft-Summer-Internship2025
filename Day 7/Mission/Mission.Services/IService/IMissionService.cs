using Mission.Entities.ViewModels.Mission;

namespace Mission.Services.IService
{
    public interface IMissionService
    {
        Task AddMissionRequestAsync(AddMissionRequestModel model);

        Task<List<MissionResponseModel>> GetMissionList();

        Task<MissionRequestViewModel?> GetMissionById(int id);

        Task<bool> UpdateMission(MissionRequestViewModel model);
        Task<bool> DeleteMission(int missionId);
        Task<List<ClientMissionResponseModel>> GetClientSideMissionList(int userId);
    }
}
