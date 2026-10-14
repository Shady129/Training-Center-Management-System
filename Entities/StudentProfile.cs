using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TrainingCenter.ConsoleApp.Entities
{
    public partial class StudentProfile
    {
      
        [Key]
        public int StudentId { get; set; }

       
        public string? Address { get; set; }

  
        public string? City { get; set; }

        public string? Country { get; set; }


        public string? Bio { get; set; }

        public string? LinkedInUrl { get; set; }


        public virtual Student Student { get; set; } = null!;
    }
}
