using Diagnostic_Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Diagnostic_Application.DAL {
    public class TestTypeGetway {


        //connection string
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticBD"].ConnectionString;


        public int SaveTestType(TestType testType) {


            int rowAffected;
            SqlConnection connection = new SqlConnection(connectionString);

            // Insert Query
            string query = "INSERT INTO TestType (name, created_at) VALUES('" + testType.TestTypeName + "', GETDATE())";
            
            // Execute
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            rowAffected = command.ExecuteNonQuery();
            // Close Connection
            connection.Close();

            return rowAffected;
        }


        public bool IsTestTypeExists(TestType testType){

            SqlConnection connection = new SqlConnection(connectionString);

            // Insert Query
            string query = "SELECT * FROM TestType WHERE name='"+ testType.TestTypeName +"'";

            // Execute
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows){
                return true;
            }


            connection.Close();
            return false;
        }


        public List<TestType> GetAllType(){

            List<TestType> testTypeList = new List<TestType>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM TestType ORDER BY name ASC";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            //if any row exists
            if (reader.HasRows){
                while (reader.Read()){
                    TestType testType = new TestType();
                    testType.Id = int.Parse(reader["id"].ToString());
                    testType.TestTypeName = reader["name"].ToString();

                    testTypeList.Add(testType);
                }

                reader.Close();
            }

            connection.Close();
            return testTypeList;
        }
    }
    
}