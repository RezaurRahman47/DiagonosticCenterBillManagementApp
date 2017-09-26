using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Diagnostic_Application.Models.View_Model;
using Diagnostic_Application.View.View_Model;

namespace Diagnostic_Application.DAL {
    public class TestWiseReportGetway {


        //connection string
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticBD"].ConnectionString;

        public List<TestWiseReport> GetDateWiseTestReport(string startDate, string endDate) {
            SqlConnection connection = new SqlConnection(connectionString);

            //string query = @"SELECT ts.testname, count(pt.id) as TotalCount, sum(ts.fee) as TotalFee FROM patient p, patientTest pt, testSetup ts WHERE
            //                    pt.patientID = p.id and
            //                    pt.testSetupID = ts.id and
            //                    pt.created_at BETWEEN '"+ startDate +"' AND '"+ endDate +"' GROUP BY ts.testname";

            string query = @"SELECT ts.testname
                                ,count(pt.id) as TotalCount,
	                             count(pt.id) * sum(DISTINCT ts.fee) as TotalFee FROM testSetup ts 
                            LEFT JOIN patientTest pt on pt.testSetupID = ts.id and 
                            pt.created_at BETWEEN '"+ startDate +"' AND '"+ endDate +"' GROUP BY ts.testname";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<TestWiseReport> testWiseReportList = new List<TestWiseReport>();
            while (reader.Read()) {

                TestWiseReport testWiseReport = new TestWiseReport();

                testWiseReport.TestName = reader["testname"].ToString();
                testWiseReport.TotalCount = Convert.ToInt32(reader["TotalCount"].ToString());
                testWiseReport.TotalFee = Convert.ToDecimal(reader["TotalFee"].ToString());

                testWiseReportList.Add(testWiseReport);
            }



            reader.Close();
            connection.Close();

            return testWiseReportList;

        }
    }
}