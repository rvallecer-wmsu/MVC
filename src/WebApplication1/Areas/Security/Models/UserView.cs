using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Areas.Security.Models
{
    public class UserView
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Minimum of 5 characters")]
        [MaxLength(10, ErrorMessage = "Maximum of 10 characters")]
        public string FirstName {  get; set;   }

        [Required, Display(Name = "Family Name")]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public string Gender { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
    }
}