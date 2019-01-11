using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingApplication.Models;

namespace TrainingApplication.DAL
{
    public class ProgramInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<Programinfo>
    {
        protected override void Seed(Programinfo context)
        {
            var trainingprogram = new List<CreateNewTrainingProgram>
            {
                new CreateNewTrainingProgram{topic="AAA",description="aaaa",date=DateTime.Parse("2005-09-01"),
                startTime=TimeSpan.Parse("01:00"),endTime=TimeSpan.Parse("01:00"),trainerName="aaa",attendeeLimit=24}
            };

            trainingprogram.ForEach(t => context.createNewTrainingPrograms.Add(t));
            context.SaveChanges();

          
            var meetingprogram = new List<CreateNewMeetingProgram>
            {
                new CreateNewMeetingProgram{topic="AAA",description="aaaa",date=DateTime.Parse("2005-09-01"),
                startTime=TimeSpan.Parse("01:00"),endTime=TimeSpan.Parse("01:00"),trainerName="aaa",attendeeLimit=24}
            };
            meetingprogram.ForEach(m => context.createNewMeetingPrograms.Add(m));
            context.SaveChanges();

            var room = new List<Room>
            {
                new Room{ roomNo=1,roomName="aaaa"}
            };

            room.ForEach(r => context.Rooms.Add(r));
            context.SaveChanges();

            var newuserregistration = new List<NewUserRegistration>
            {
                new NewUserRegistration{ Username="AAAA",Password="aaaa@123",ConfirmPassword="aaaa@123",Email="aaa@easternenterprise.com",
                    CreatedDate =DateTime.Parse("2005-09-01"),LastLoginDate=DateTime.Parse("2005-09-01")}
            };

            newuserregistration.ForEach(n => context.newUserRegistrations.Add(n));
            context.SaveChanges();
        }
    }
}