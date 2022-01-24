using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomingoRoofWorks.Models
{
    public class JobCardModel
    {
        [Display(Name = "JobCardId")]
        public int JobCardId { get; set; }

        [Required(ErrorMessage = "Please enter the j9b type")]

        public String JobType { get; set; }

        [Required(ErrorMessage = "Please enter the daily rate ")]

        public double DailyRate { get; set; }

        [Required(ErrorMessage = "Please enter the Number of days  ")]

        public int NumOfDays { get; set; }


    }
}