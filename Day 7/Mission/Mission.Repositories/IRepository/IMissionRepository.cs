using Mission.Entities.ViewModels.Mission;

namespace Mission.Repositories.IRepository
{
    public interface IMissionRepository
    {
        Task AddMissionRequestAsync(AddMissionRequestModel model);

        Task<List<MissionResponseModel>> GetMissionList();

        Task<MissionRequestViewModel?> GetMissionById(int id);

        Task<bool> UpdateMission(MissionRequestViewModel mission);
        Task<bool> DeleteMission(int missionId);
        Task<List<ClientMissionResponseModel>> GetClientSideMissionList(int userId);
    }
}
