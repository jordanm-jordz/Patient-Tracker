using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomingoRoofWorks.Models
{
    public class EmployeeModel
    {
        [Display(Name = "EmpId")]

        public String EmpId { get; set; }

        [Required(ErrorMessage = "Please enter a job card id")]

        public int JobCardId { get; set; }

        [Required(ErrorMessage = "Please enter the Employee names ")]

        public String EmpNames { get; set; }

    }
}