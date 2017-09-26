using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagnostic_Application.Models {
    public class TestEntry {

        public int Id { get; set; }
        public string PatientName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MobileNo { get; set; }
        public int TestId { get; set; }
        public string BillNo { get; set; }
        public decimal TotalAmount { get; set; }

        //public DateTime DueDate { get; set; }
        public decimal UnitPrice { get; set; }
    }
}