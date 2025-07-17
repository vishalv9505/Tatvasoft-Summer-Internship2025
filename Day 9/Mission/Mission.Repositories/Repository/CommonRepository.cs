using Mission.Entities;
using Mission.Entities.ViewModels;
using Mission.Repositories.IRepository;

namespace Mission.Repositories.Repository
{
    public class CommonRepository(MissionDbContext dbContext) : ICommonRepository
    {
        private readonly MissionDbContext _dbContext = dbContext;

        public List<DropDownResponseModel> CountryList()
        {
            var countries = _dbContext.Countries
                .OrderBy(c => c.CountryName)
                .Select(c => new DropDownResponseModel(c.Id, c.CountryName))
                .ToList();

            return countries;
        }

        public List<DropDownResponseModel> CityList(int countryId)
        {
            var cities = _dbContext.Cities
                .Where(c => c.CountryId == countryId)
                .OrderBy(c => c.CityName)
                .Select(c => new DropDownResponseModel(c.Id, c.CityName))
                .ToList();

            return cities;
        }

        //public List<DropDownResponseModel> MissionCountryList()
        //{
        //    var countries = _dbContext.Missions
        //        .Select(m => new DropDownResponseModel(m.CountryId, m.Country.CountryName))
        //        .Distinct()
        //        .ToList();

        //    return countries;
        //}

        //public List<DropDownResponseModel> MissionCityList()
        //{
        //    var cities = _dbContext.Missions
        //        .Where(m => !m.IsDeleted)
        //        .Select(m => new DropDownResponseModel(m.CityId, m.City.CityName))
        //        .Distinct()
        //        .ToList();

        //    return cities;
        //}

        public List<DropDownResponseModel> MissionThemeList()
        {
            var missionThemes = _dbContext.MissionThemes
                .Where(mt => mt.Status == "active")
                .Select(mt => new DropDownResponseModel(mt.Id, mt.ThemeName))
                .Distinct()
                .ToList();

            return missionThemes;
        }

        public List<DropDownResponseModel> MissionSkillList()
        {
            var missionSkill = _dbContext.MissionSkills
                .Where(ms => ms.Status == "active")
                .Select(ms => new DropDownResponseModel(ms.Id, ms.SkillName))
                .ToList();

            return missionSkill;
        }

        //public List<DropDownResponseModel> MissionTitleList()
        //{
        //    var missionSkill = _dbContext.Missions
        //        .Where(m => !m.IsDeleted)
        //        .Select(m => new DropDownResponseModel(m.Id, m.MissionTitle))
        //        .ToList();

        //    return missionSkill;
        //}
    }
}
