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
        public int CustomerID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public double Zip { get; set; }

        public DateTime PickupDate {get; set; }

        public string Username { get; set; }

        public string Password { get; set; }


    }
}