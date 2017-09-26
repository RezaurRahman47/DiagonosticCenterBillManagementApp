using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diagnostic_Application.DAL;
using Diagnostic_Application.Models.View_Model;
using Diagnostic_Application.View.View_Model;

namespace Diagnostic_Application.BLL {
    public class TestWiseReportManager {
        TestWiseReportGetway _tesWiseReportGetway = new TestWiseReportGetway();
        public List<TestWiseReport> GetAllTypeWiseReport(string fromDate, string toDate){

            return _tesWiseReportGetway.GetDateWiseTestReport(fromDate, toDate);
        }
    }
}