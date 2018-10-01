using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    
    public class Payment
    {
        [Key]

        public int PaymentID { get; set; }
        public int EmployeeID { get; set; }

        public double Fee { get; set; }

        public bool CollectedFee { get; set; }

    }
}