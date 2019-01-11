//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainingApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class NewUserRegistration
    {
        [Key]
        public int UserId { get; set; }
        [Required]
       
        [StringLength(150)]
        [Display(Name = "User Name: ")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(150, MinimumLength = 6)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(150)]
        [Display(Name = "Email Address: ")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Created Date: ")]
        public System.DateTime CreatedDate { get; set; }
        [Required]
        [Display(Name = "Last Login Date: ")]
        public Nullable<System.DateTime> LastLoginDate { get; set; }
    }
}