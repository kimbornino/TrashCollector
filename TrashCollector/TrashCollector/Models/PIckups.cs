using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Pickups
    {
        [Key]
        public int PickupID { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public bool ConfirmPickup { get; set; }

        //[ForeignKey("PickupDay")]
        //public Customer DayofWeek { get; set; }
        public string PickupDay { get; set; }

        public string  CustomPickup { get; set; }

    }
}