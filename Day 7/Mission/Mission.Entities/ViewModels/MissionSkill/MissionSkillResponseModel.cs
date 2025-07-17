namespace Mission.Entities.ViewModels.MissionSkill
{
    public class MissionSkillResponseModel : UpsertMissionSkillRequestModel
    {
        public MissionSkillResponseModel() { }

        public MissionSkillResponseModel(Models.MissionSkill missionSkill) 
        {
            Id = missionSkill.Id;
            SkillName = missionSkill.SkillName;
            Status = missionSkill.Status;
        }
    }
}
