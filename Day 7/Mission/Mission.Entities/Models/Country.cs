using System.ComponentModel.DataAnnotations;

namespace Mission.Entities.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string CountryName { get; set; }
    }
}
