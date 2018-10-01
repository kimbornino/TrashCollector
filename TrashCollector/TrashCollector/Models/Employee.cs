using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Test]

        
        public int EmployeeID { get; set; }

        public string Name { get; set; }

        public double EmployeeZip { get; set; }

        //check this
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public int Customer { get; set; }

    }
}