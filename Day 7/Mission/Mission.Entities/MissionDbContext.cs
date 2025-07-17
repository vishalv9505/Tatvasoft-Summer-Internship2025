using Microsoft.EntityFrameworkCore;
using Mission.Entities.Models;

namespace Mission.Entities
{
    public class MissionDbContext(DbContextOptions<MissionDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        public DbSet<MissionSkill> MissionSkills { get; set; }

        public DbSet<MissionTheme> MissionThemes { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Models.Mission> Missions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Tatva",
                EmailAddress = "admin@tatvasoft.com",
                Password = "admin",
                PhoneNumber = "01234567890",
                UserType = "admin",
            });

            modelBuilder.Entity<Country>().HasData(new Country() { Id = 1, CountryName = "India" });
            modelBuilder.Entity<Country>().HasData(new Country() { Id = 2, CountryName = "USA" });
            modelBuilder.Entity<Country>().HasData(new Country() { Id = 3, CountryName = "UK" });
            modelBuilder.Entity<Country>().HasData(new Country() { Id = 4, CountryName = "Russia" });
            
            modelBuilder.Entity<City>().HasData(new City() { Id = 1, CountryId = 1, CityName = "Ahmedabad" });
            modelBuilder.Entity<City>().HasData(new City() { Id = 2, CountryId = 1, CityName = "Rajkot" });
            modelBuilder.Entity<City>().HasData(new City() { Id = 3, CountryId = 1, CityName = "Surat" });
            modelBuilder.Entity<City>().HasData(new City() { Id = 4, CountryId = 1, CityName = "Jamnagar" });
            modelBuilder.Entity<City>().HasData(new City() { Id = 5, CountryId = 2, CityName = "New York" });
            modelBuilder.Entity<City>().HasData(new City() { Id = 6, CountryId = 2, CityName = "California" });
            modelBuilder.Entity<City>().HasData(new City() { Id = 7, CountryId = 2, CityName = "Texas" });
            modelBuilder.Entity<City>().HasData(new City() { Id = 8, CountryId = 3, CityName = "London" });
            modelBuilder.Entity<City>().HasData(new City() { Id = 9, CountryId = 3, CityName = "Manchester" });
            modelBuilder.Entity<City>().HasData(new City() { Id = 10, CountryId = 3, CityName = "Birmingham" });
            modelBuilder.Entity<City>().HasData(new City() { Id = 11, CountryId = 4, CityName = "Moscow" });
            modelBuilder.Entity<City>().HasData(new City() { Id = 12, CountryId = 4, CityName = "Saint Petersburg" });
            modelBuilder.Entity<City>().HasData(new City() { Id = 13, CountryId = 4, CityName = "Yekaterinburg" });            

            base.OnModelCreating(modelBuilder);
        }
    }
}
