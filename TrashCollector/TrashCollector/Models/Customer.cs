using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        [Display(Name = "Zip Code")]
        public double CustomerZip { get; set; }

        [Display(Name = "Day for Pickup (Monday-Friday)")]
        public string DayOfWeek {get; set; }

        public DateTime PickupStartDate { get; set; }

        public DateTime PickupEndDate { get; set; }

        [Display(Name = "Select 'Customer' or 'Employee'")]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Your Bill")]
        public double BillAmount { get; set; }

    }
}