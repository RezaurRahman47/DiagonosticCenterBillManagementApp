using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Diagnostic_Application.View.View_Model;

namespace Diagnostic_Application.DAL {
    public class UnPaidBillGatway {


        //connection string
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticBD"].ConnectionString;


        public List<UnpaidBillWiseModel> UnpaidBillReport(string fromDate, string toDate) {

            SqlConnection con = new SqlConnection(connectionString);
            string query = @"select * from patient WHERE paymentStatus=0 ORDER BY created_at DESC";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<UnpaidBillWiseModel> unpaBillViewModels = new List<UnpaidBillWiseModel>();
            while (reader.Read()) {
                UnpaidBillWiseModel unpaidViewModel = new UnpaidBillWiseModel();

                unpaidViewModel.PatientName = (reader["patient_name"].ToString());
                unpaidViewModel.BillNo = reader["bill_no"].ToString();
                unpaidViewModel.MobileNo = reader["mobile"].ToString();
                unpaidViewModel.TotalAmount = Convert.ToDecimal(reader["dueAmount"].ToString());
                unpaBillViewModels.Add(unpaidViewModel);
            }
            reader.Close();
            con.Close();
            return unpaBillViewModels;
        }
    }
}
