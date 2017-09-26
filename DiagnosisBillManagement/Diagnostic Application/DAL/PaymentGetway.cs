using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Diagnostic_Application.Models;

namespace Diagnostic_Application.DAL {
    public class PaymentGetway {

        //connection string
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticBD"].ConnectionString;

        public int UpdatePaymentWithStatus(string billNo, decimal dueAmount, int status){
            
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE Patient SET paymentStatus='"+ status +"',dueAmount="+ dueAmount +" WHERE bill_no='"+ billNo +"'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        


        public bool IsPatientTestExists(int patientID, int testID) {
            string query = "SELECT * FROM PatientTest WHERE PatientId=" + patientID + " AND TestId=" + patientID;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isPatientTestExist = false;
            if (reader.HasRows) {
                isPatientTestExist = true;
            }
            reader.Close();
            connection.Close();
            return isPatientTestExist;
        }

        //----------bill------------start
        public bool IsBillNoExists(string billNo) {
            string query = "SELECT * FROM Patient WHERE bill_no='" + billNo + "'";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            bool isBillNoExists = false;

            if (reader.HasRows) {
                isBillNoExists = true;
            }
            reader.Close();
            connection.Close();
            return isBillNoExists;
        }



        public TestEntry SearchByBill(string billNo) {
            //get the total Fee
            string query = @"SELECT sum(fee) as totalFee FROM Patient 
                            INNER JOIN PatientTest ON Patient.id = PatientTest.patientID 
                            INNER JOIN TestSetup ON PatientTest.testSetupID = TestSetup.id 
                            WHERE Patient.bill_no='"+ billNo +"'";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            TestEntry salaryTestEntry = null;

            if (reader.HasRows){
                reader.Read();
                salaryTestEntry = new TestEntry();
                salaryTestEntry.TotalAmount = Convert.ToDecimal(reader["totalFee"].ToString());
            }
            connection.Close();

            //check due payment using bill number



            return salaryTestEntry;
        }

        //check patient due amount.
        public Patient GetPatientInfoUsingBillNo(string billNo) {
            //get the total Fee
            string query = @"SELECT * FROM patient WHERE bill_no ='" + billNo + "'";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Patient patient = new Patient();

            if (reader.HasRows) {
                reader.Read();
                patient.DueAmount = Convert.ToDecimal(reader["dueAmount"].ToString());
                patient.DueDate = Convert.ToDateTime(reader["created_at"].ToString());
            }
            connection.Close();
            

            return patient;
        }

        //----------------end----------
        public bool IsMobileNoExists(string mobilNo)
        {
            string query = "SELECT * FROM Patient WHERE mobile='" + mobilNo + "'";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            bool isBillNoExists = false;

            if (reader.HasRows)
            {
                isBillNoExists = true;
            }
            reader.Close();
            connection.Close();
            return isBillNoExists;
        }



        public TestEntry SearchByMobile(string mobileNo)
        {
            //get the total Fee
            string query = @"SELECT sum(fee) as totalFee FROM Patient 
                            INNER JOIN PatientTest ON Patient.id = PatientTest.patientID 
                            INNER JOIN TestSetup ON PatientTest.testSetupID = TestSetup.id 
                            WHERE Patient.mobile='" + mobileNo+ "'";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            TestEntry salaryTestEntry = null;

            if (reader.HasRows)
            {
                reader.Read();
                salaryTestEntry = new TestEntry();
                salaryTestEntry.TotalAmount = Convert.ToDecimal(reader["totalFee"].ToString());
            }
            connection.Close();

            //check due payment using mobile number



            return salaryTestEntry;
        }

        //check patient due amount.
        public Patient GetPatientInfoUsingmobileNo(string mobileNo)
        {
            //get the total Fee
            string query = @"SELECT * FROM patient WHERE mobile ='" + mobileNo + "'";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Patient patient = new Patient();

            if (reader.HasRows)
            {
                reader.Read();
                patient.DueAmount = Convert.ToDecimal(reader["dueAmount"].ToString());
                patient.DueDate = Convert.ToDateTime(reader["created_at"].ToString());
            }
            connection.Close();


            return patient;
        }


        public int SavePatientTests(int patientId, int testId, string requestDate) {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO PatientTests(PatientId,TestId,RequestDate) VALUES(" + patientId + "," + testId + ",'" + requestDate + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<TestSetup> GetAllSetup(string billNoOrMob) {
            SqlConnection con = new SqlConnection(connectionString);
            string query = @"SELECT TestSetup.TestName,TestSetup.Fee FROM Patient  
                                INNER JOIN PatientTest ON Patient.Id = PatientTest.PatientId 
                                INNER JOIN TestSetup ON PatientTest.TestSetupId = TestSetup.Id  
                            WHERE Patient.BillNo='" + billNoOrMob + "' or Patient.Mobile='" + billNoOrMob + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            List<TestSetup> testSetups = new List<TestSetup>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows) {
                while (reader.Read()) {
                    TestSetup testSetup = new TestSetup();
                    testSetup.TestName = reader["TestName"].ToString();
                    testSetup.Fee = Convert.ToDecimal(reader["Fee"]);
                    testSetups.Add(testSetup);
                }
                reader.Close();
            }
            con.Close();
            return testSetups;
        }
    }
}