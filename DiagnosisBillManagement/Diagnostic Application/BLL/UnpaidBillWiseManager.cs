using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diagnostic_Application.DAL;
using Diagnostic_Application.View.View_Model;

namespace Diagnostic_Application.BLL {
    public class UnpaidBillWiseManager {
        UnPaidBillGatway _unPaidBillGatway = new UnPaidBillGatway();

        public List<UnpaidBillWiseModel> UnpaidBillReport(string fromDate, string toDate) {
            return _unPaidBillGatway.UnpaidBillReport(fromDate, toDate);
        }
    }
}