using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sovanny_Yun_CST356_Lab3.Models.View
{
    public class UserViewModel
    {
        public int Id { get; set; }
        
        [MaxLength(32)]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [MaxLength(32)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [MaxLength(32)]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Year In School")]
        public int YearInSchool { get; set; }
    }
}