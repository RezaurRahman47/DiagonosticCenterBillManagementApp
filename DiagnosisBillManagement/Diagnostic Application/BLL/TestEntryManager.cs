using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diagnostic_Application.DAL;
using Diagnostic_Application.Models;

namespace Diagnostic_Application.BLL {
    public class TestEntryManager {

        TestEntryGetway _testEntryGetway = new TestEntryGetway();

        public List<TestSetup> GetAllTestSetup(){
            return _testEntryGetway.GetAllTestSetup();
        }

        public int SavePatient(Patient patient){
            //bool isTestNameExists = _testEntryGetway.IsTestNameExists(testSetup);
            return _testEntryGetway.SavePatient(patient);
        }


        public TestSetup GetTestSetup(string testID){
            return _testEntryGetway.GetTestSetup(testID);
        }


        public string SavePatientInformation(PatientTest patientTest){

            int rowAffected = _testEntryGetway.SavePatientTestInformation(patientTest);
            if (rowAffected > 0){
                return "success";
            }
            else{
                return "failed";
            }
        }


    }
}