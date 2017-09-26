using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Diagnostic_Application.Models;

namespace Diagnostic_Application.DAL {
    public class TestSetupGateway {

        //connection string
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticBD"].ConnectionString;

        public List<TestType> GetAllTestType(){
            
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM TestType";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<TestType> testTypeList = new List<TestType>();

            if (reader.HasRows)
            {
                while (reader.Read()){
                    TestType testType = new TestType();
                    testType.Id = int.Parse(reader["id"].ToString());
                    testType.TestTypeName = reader["testname"].ToString();

                    testTypeList.Add(testType);
                }

                reader.Close();
            }

            connection.Close();
            return testTypeList;

        }


        public int SaveTestSetup(TestSetup testSetup){

            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO TestSetup VALUES('"+ testSetup.TestName + "', "+ testSetup.Fee +","+ testSetup.TestTypeId +", GETDATE())";  

            Console.Write(query);
            
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public bool IsTestNameExists(TestSetup testSetup){

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM TestSetup WHERE testname='" + testSetup.TestName + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows){
                return true;
            }
            reader.Close();

            connection.Close();
            return false;
        }


        public List<TestSetupViewModel> GetAllTestSetup(){
            
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select testname,fee,name from TestSetup_view";
            SqlCommand command = new SqlCommand(query, connection);

            List<TestSetupViewModel> testSetupViewModelList = new List<TestSetupViewModel>();
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows){
                while (reader.Read()){
                    TestSetupViewModel testSetupViewModel = new TestSetupViewModel();
                    testSetupViewModel.TestName = reader["testname"].ToString();
                    testSetupViewModel.Fee = Convert.ToDecimal(reader["fee"].ToString());
                    testSetupViewModel.Name = reader["name"].ToString();

                    testSetupViewModelList.Add(testSetupViewModel);
                }

                reader.Close();
            }

            connection.Close();

            return testSetupViewModelList;
        }

    }
}