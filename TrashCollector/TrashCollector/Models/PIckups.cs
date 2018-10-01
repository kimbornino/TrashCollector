using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Pickups
    {
        public int PickupID { get; set; }   

        public int CustomerID { get; set; }

        public int EmployeeID { get; set; }

        public bool ConfirmPickup { get; set; }

    }
}