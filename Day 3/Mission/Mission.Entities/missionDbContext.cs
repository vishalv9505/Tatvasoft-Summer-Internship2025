using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mission.Entities.Models;

namespace Mission.Entities
{
    public class MissionDbContext(DbContextOptions<MissionDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Tatvasoft",
                EmailAddress = "admin@tatvasoft.com",
                Password = "Admin",
                PhoneNumber = "1234567890",
                UserType = "Admin",
                // UserImage = string.Empty,

            });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
