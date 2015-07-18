using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Enter First Name")]
        public string FirstName { get; set; }

        [StringLength(10, ErrorMessage = "Last name should not be longer than 10 characters")]
        public string LastName { get; set; }


        public int Salary { get; set; }
    }
}