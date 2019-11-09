using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo.Crud_CodeFirst.Models.Code_First_Details
{
    public class PersonalDetails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        [StringLength(10,ErrorMessage = "Max Length : 10") , MinLength(3, ErrorMessage = "Min Length : 3")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        [StringLength(10,ErrorMessage = "Max Length : 10") , MinLength(3, ErrorMessage = "Min Length : 3")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Age Is Required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Mail Is Required")]
        [StringLength(30, ErrorMessage = "Max Length : 30"), MinLength(5, ErrorMessage = "Min Length : 5")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Mail { get; set; }
    }
}