using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Pickups
    {
        public int PickupID { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public int Customer { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public int Employee { get; set; }

        public bool ConfirmPickup { get; set; }

        [ForeignKey("PickupDay")]
        public string DayofWeek { get; set; }
        public string Day { get; set; }

        public string  CustomPickup { get; set; }

    }
}