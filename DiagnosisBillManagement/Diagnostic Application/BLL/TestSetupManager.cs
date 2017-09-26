using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diagnostic_Application.DAL;
using Diagnostic_Application.Models;

namespace Diagnostic_Application.BLL {
    public class TestSetupManager {

        TestSetupGateway _testSetupGateway = new TestSetupGateway();
        TestTypeGetway _testTypeGetway = new TestTypeGetway();

        public List<TestType> GetAllTestType()
        {
            return _testTypeGetway.GetAllType();
        }

        public string SaveTestSetup(TestSetup testSetup){

            if (testSetup.TestName == "" && testSetup.Fee == null && testSetup.TestTypeId == null){
                return "empty";
            }


            bool isTestNameExists = _testSetupGateway.IsTestNameExists(testSetup);
            if (isTestNameExists){

                return "exists";
            }


            int rowAffected = _testSetupGateway.SaveTestSetup(testSetup);
            if (rowAffected > 0){
                return "success";

            } else{
                return "falied";
            }

        }

        public List<TestSetupViewModel> GetAllTestSetup()
        {
            return _testSetupGateway.GetAllTestSetup();
        }
        
    }
}