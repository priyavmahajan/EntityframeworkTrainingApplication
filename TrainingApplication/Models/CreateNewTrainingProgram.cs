using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingApplication.Models
{
    public class CreateNewTrainingProgram
    {
        [Key]
        public int trainingID { get; set; }
        [Required]
       [Display(Name = "Topic ")]
        public string topic { get; set; }
        [Required]
       [Display(Name = "Description ")]

        public string description { get; set; }
        [Required]
       [Display(Name = " Date ")]
        public DateTime date { get; set; }
        [Required]
       [Display(Name = "Start Time ")]
        public TimeSpan startTime { get; set; }
        [Required]
       [Display(Name = "End Time ")]
        public TimeSpan endTime { get; set; }
       
        public virtual ICollection<Room> Rooms  { get; set; }

        [Required]
       [Display(Name = "TrainerName ")]
        public string trainerName { get; set; }
        [Required]
       [Display(Name = "Attendee Limit ")]
        public int attendeeLimit { get; set; }
    }
}