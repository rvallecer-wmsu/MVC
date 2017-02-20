using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectSop.Areas.Security.Models
{
    public class UserView
   {
        public Guid Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Min of 5 characters")]
        [MaxLength(10, ErrorMessage = "Max of 10 characters")]
        public string Firstname { get; set; }

        [Required, Display(Name = "Last name")]

        public string Lastname{get; set;}

        public int? Age {get; set;}

        public string Gender {get; set;}
   }
}