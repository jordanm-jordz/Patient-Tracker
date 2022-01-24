using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomingoRoofWorks.Models
{
    public class InvoiceModel
    {

        [Display(Name = "JobCardId")]
        public int JobCardId { get; set; }

        [Required(ErrorMessage = "Please enter the Sub total  ")]

        public double SubTotal { get; set; }

        [Required(ErrorMessage = "Please enter a Vat number")]

        public double Vat { get; set; }

        [Required(ErrorMessage = "Please enter a the total amount")]

        public double Total { get; set; }
    }
}