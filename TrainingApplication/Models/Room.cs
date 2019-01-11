using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingApplication.Models
{
    public class Room
    {
        [Key]
        public int roomNo { get; set; }
        public string roomName { get; set; }
        public virtual CreateNewTrainingProgram CreateNewTrainingProgram { get; set; }
        public virtual CreateNewMeetingProgram CreateNewMeetingProgram { get; set; }
    }
}