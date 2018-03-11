﻿using System.ComponentModel.DataAnnotations;

namespace Sovanny_Yun_CST356_Lab3.Models.View
{
    public class MajorViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Major")]
        public string Subject { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        [Display(Name = "Expected Graduate")]
        public int YearOfGraduate { get; set; }
        [Display(Name = "User ID")]
        public int UserId { get; set; }

    }
}