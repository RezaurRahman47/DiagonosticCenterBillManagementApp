using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diagnostic_Application.Models.View_Model;
using Diagnostic_Application.View.View_Model;

namespace Diagnostic_Application.DAL {
    public class TypeWiseManager {


        TypeWiseReportGetway testGateway = new TypeWiseReportGetway();

        internal bool ValidateInput(string startDate, string endDate) {
            if (startDate == String.Empty) {
                throw new Exception("Select a Date");
            } else if (endDate == String.Empty) {
                throw new Exception("Select a Date");
            } else if (Convert.ToDateTime(startDate) > DateTime.Now) {
                throw new Exception("Search Date Cannot Go Beyond Current Date!");
            } else if (Convert.ToDateTime(endDate) > DateTime.Now) {
                throw new Exception("Search Date Cannot Go Beyond Current Date!");
            }

            return true;
        }

        internal List<TypeWiseTestReport> GetTypeWiseTestReport(string startDate, string endDate)
        {

            return testGateway.GetTypeWiseTestReport(startDate, endDate);
        }

    }
}