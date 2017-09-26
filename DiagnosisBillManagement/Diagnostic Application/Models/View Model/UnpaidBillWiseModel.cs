using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagnostic_Application.View.View_Model {
    public class UnpaidBillWiseModel {
        public string PatientName { get; set; }
        public string BillNo { get; set; }
        public string MobileNo { get; set; }
        public decimal TotalAmount { get; set; }
    }
}