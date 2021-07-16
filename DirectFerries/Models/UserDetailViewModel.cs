using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DirectFerries.Models
{
    public class UserDetailViewModel
    {
        [Required(ErrorMessage ="Date Of Birth Required!")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Full Name Required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Full Name Required!")]
        public string LastName { get; set; }
    }
}