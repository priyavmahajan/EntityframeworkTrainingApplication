using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TrainingApplication.Models;

namespace TrainingApplication.DAL
{
    public class Programinfo:DbContext
    {
        public Programinfo() : base("Programinfo")
        {
        }
        public DbSet<CreateNewTrainingProgram> createNewTrainingPrograms { get; set; }
        public DbSet<CreateNewMeetingProgram> createNewMeetingPrograms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<NewUserRegistration> newUserRegistrations { get; set; }
      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<TrainingApplication.Models.UserLogin> UserLogins { get; set; }
    }
}