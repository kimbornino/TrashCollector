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
        public string CustomerZip { get; set; }

        [Display(Name = "Day for Pickup (Monday-Friday)")]
        public string DayOfWeek {get; set; }

        [Display(Name = "Start Pickups (mm/dd/yy)")]
        public string PickupStartDate { get; set; }

        [Display(Name = "End/Suspend Pickups (mm/dd/yy)")]
        public string PickupEndDate { get; set; }

        [Display(Name= "Create One Time Pickup: Enter day this week")]
        public string CustomPickUp { get; set; }

        [Display(Name = "Was trash collected?")]
        public bool PickupCompleted { get; set; }

        [Display(Name = "Select 'Customer' or 'Employee'")]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Customer Bill")]
        public double BillAmount { get; set; }

    }
}