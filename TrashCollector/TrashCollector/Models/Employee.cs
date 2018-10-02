using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Employee
    {
        
        public int EmployeeID { get; set; }

        public string Name { get; set; }

        public double EmployeeZip { get; set; }

        //check this
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


        public IEnumerable<Customer> Customers { get; set; }
    }
}