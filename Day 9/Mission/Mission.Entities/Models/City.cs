using System.ComponentModel.DataAnnotations;

namespace Mission.Entities.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        public int CountryId { get; set; }
        public string CityName { get; set; }
    }
}
