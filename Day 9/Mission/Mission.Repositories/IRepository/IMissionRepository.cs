using Mission.Entities.ViewModels.Mission;
using Mission.Entities.ViewModels.MissionApplication;

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

        Task<(bool result, string message)> ApplyMission(ApplyMissionRequestModel model);

        Task<List<MissionApplicationResponseModel>> GetMissionApplicationList();

        Task<bool> MissionApplicationApprove(MissionApplicationResponseModel model);

        Task<bool> MissionApplicationDelete(MissionApplicationResponseModel model);
    }
}
