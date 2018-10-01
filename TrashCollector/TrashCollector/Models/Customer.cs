using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public double CustomerZip { get; set; }

        public string DayOfWeek {get; set; }
        public DateTime PickupStartDate { get; set; }

        public DateTime PickupEndDate { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }


    }
}